namespace _Project_CheatSheet.Extensions
{
    using System.Reflection;
    using System.Text;

    using _Project_CheatSheet.Common.Exceptions;
    using _Project_CheatSheet.Common.UserService.Interfaces;
    using _Project_CheatSheet.Infrastructure.Data;
    using _Project_CheatSheet.Infrastructure.Data.Models;
    using _Project_CheatSheet.Infrastructure.Data.Models.Enums;
    using _Project_CheatSheet.Infrastructure.MongoDb.Services;
    using _Project_CheatSheet.Infrastructure.MongoDb.Store;

    using Amazon;
    using Amazon.Extensions.NETCore.Setup;
    using Amazon.Runtime;
    using Amazon.S3;

    using AutoMapper;

    using Common.Mapping;

    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.OpenApi.Models;

    using MongoDB.Driver;

    public static class BuilderCustomExtensionMethods
    {
        public static void RegisterApplicationServices(this IServiceCollection serviceCollection, Type serviceInterface)
        {
            var assembly = Assembly.GetAssembly(serviceInterface);
            CustomException.ThrowIfNull(assembly);

            var serviceClassType = assembly
                .GetTypes()
                .Where(s => s.Name.ToLower().EndsWith("service") && !s.IsInterface && !s.IsAbstract)
                .ToArray();

            foreach (var implementationType in serviceClassType)
            {
                var interfaceType = implementationType.GetInterface($"I{implementationType.Name}");
                CustomException.ThrowIfNull(interfaceType);
                serviceCollection.AddScoped(interfaceType, implementationType);
            }
        }

        public static IServiceCollection RegisterIdentity(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddIdentity<User, IdentityRole>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 2;
                })
                .AddEntityFrameworkStores<CheatSheetDbContext>();

            return serviceCollection;
        }

        public static IServiceCollection RegisterJwtAuthentication(this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            serviceCollection
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidAudience = configuration["JWT:ValidAudience"],
                        ValidIssuer = configuration["JWT:ValidIssuer"],
                        IssuerSigningKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
                    };
                });
            return serviceCollection;
        }

        public static IServiceCollection RegisterAwsService(this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            var awsOptions = new AWSOptions
            {
                Credentials = new BasicAWSCredentials(configuration["AWS:AccessKey"], configuration["AWS:SecretKey"]),
                Region = RegionEndpoint.EUWest2
            };
            serviceCollection.AddDefaultAWSOptions(awsOptions);
            serviceCollection.AddAWSService<IAmazonS3>();
            return serviceCollection;
        }

        public static IServiceCollection RegisterAutoMapper(this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            serviceCollection.AddScoped(provider => new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new MapperProfile(provider.GetService<ICurrentUser>()));
                })
                .CreateMapper());
            serviceCollection.AddAutoMapper(typeof(Program));

            return serviceCollection;
        }

        public static IServiceCollection RegisterMongoDb(this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            serviceCollection.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));

            serviceCollection.AddSingleton<IMongoDbSettings>(s =>
                s.GetRequiredService<IOptions<MongoDbSettings>>().Value);

            serviceCollection.AddSingleton<IMongoClient>(s =>
                new MongoClient(configuration["MongoDbSettings:ConnectionString"]));

            serviceCollection.AddScoped<ICourseDetailsService, CourseDetailsService>();
            return serviceCollection;
        }

        public static IServiceCollection RegisterPolicies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAuthorization(options =>
            {
                options.AddPolicy("ElevatedRights", policy =>
                {
                    policy.RequireRole(
                        ApplicationRolesEnum.Administrator.ToString(),
                        ApplicationRolesEnum.Moderator.ToString()
                    );
                });
            });
            return serviceCollection;
        }

        public static IServiceCollection RegisterCors(this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            serviceCollection.AddCors(options =>
            {
                var frontEnd = configuration["FrontEnd"];
                options.AddDefaultPolicy(corsBuilder =>
                {
                    corsBuilder
                        .WithOrigins(frontEnd)
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            return serviceCollection;
        }

        public static IServiceCollection RegisterSwagger(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo { Title = "Cheat sheet swagger API", Version = "v1" });
            });
            return serviceCollection;
        }
    }
}