using _Project_CheatSheet.Common.Caching;
using _Project_CheatSheet.Common.Mapping;
using _Project_CheatSheet.Common.UserService;
using _Project_CheatSheet.Common.UserService.Interfaces;
using _Project_CheatSheet.Features.Category.Interfaces;
using _Project_CheatSheet.Features.Category.Services;
using _Project_CheatSheet.Features.Comment.Interfaces;
using _Project_CheatSheet.Features.Comment.Services;
using _Project_CheatSheet.Features.Course.Interfaces;
using _Project_CheatSheet.Features.Course.Services;
using _Project_CheatSheet.Features.Identity.Interfaces;
using _Project_CheatSheet.Features.Identity.Services;
using _Project_CheatSheet.Features.Issue.Interfaces;
using _Project_CheatSheet.Features.Issue.Services;
using _Project_CheatSheet.Features.Likes.Interfaces;
using _Project_CheatSheet.Features.Likes.Services;
using _Project_CheatSheet.Features.Profile.Interfaces;
using _Project_CheatSheet.Features.Profile.Services;
using _Project_CheatSheet.Features.Resources.Interfaces;
using _Project_CheatSheet.Features.Resources.Services;
using _Project_CheatSheet.Features.Statistics.Interfaces;
using _Project_CheatSheet.Features.Statistics.Services;
using _Project_CheatSheet.Features.Topics.Interfaces;
using _Project_CheatSheet.Features.Topics.Services;
using _Project_CheatSheet.Features.Videos.Interfaces;
using _Project_CheatSheet.Features.Videos.Services;
using _Project_CheatSheet.Infrastructure.Data;
using _Project_CheatSheet.Infrastructure.Data.Models;
using _Project_CheatSheet.Infrastructure.MongoDb.Services;
using _Project_CheatSheet.Infrastructure.MongoDb.Store;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using System.Text;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped<IAuthenticateService, AuthenticateService>();
builder.Services.AddScoped<IResourceService, ResourceService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ILikeService, LikeService>();
builder.Services.AddScoped<IStatisticsService, StatisticService>();
builder.Services.AddScoped<IProfileService, ProfileService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ITopicService, TopicService>();
builder.Services.AddScoped<IVideoService, VideoService>();
builder.Services.AddScoped<IIssueService, IssueService>();
builder.Services.AddScoped<ICourseServiceMongo, CourseServiceMongo>();

builder.Services.AddScoped<ICurrentUser, CurrentUser>();
builder.Services.AddScoped<ICacheService, CacheService>();
builder.Services.AddMemoryCache();

builder.Services.AddDbContext<CheatSheetDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<CheatSheetDbContext>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ElevatedRights", policy =>
    {
        policy.RequireRole("Administrator", "Moderator");
    });
});

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped(provider => new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new MapperProfile(provider.GetService<ICurrentUser>()));
}).CreateMapper());

builder.Services.Configure<IdentityOptions>(options =>
{
    // Default Password settings.
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 2;
});

builder.Services.AddControllers();

var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();

builder.Services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));
builder.Services.AddSingleton<IMongoDbSettings>(s => s.GetRequiredService<IOptions<MongoDbSettings>>().Value);
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("MongoDbSettings:ConnectionString")));
builder.Services.AddScoped<ICourseDetailsService, CourseDetailsService>();


builder.Services.AddCors(options =>
{
    var frontEnd = configuration.GetValue<string>("FrontEnd");

    options.AddDefaultPolicy(corsBuilder => { corsBuilder.WithOrigins(frontEnd).AllowAnyMethod().AllowAnyHeader(); });
});

builder.Services.AddAuthentication(options =>
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
            ValidAudience = configuration["JWT:ValidAudience"],
            ValidIssuer = configuration["JWT:ValidIssuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"])),
            ValidateIssuerSigningKey = true
        };
    });

builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new OpenApiInfo { Title = "Cheat sheet swagger API", Version = "v1" });
});

builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(s => { s.SwaggerEndpoint("/swagger/swagger.json", "Cheat sheet swagger API"); });
}

app.UseCors();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(e => { e.MapControllers(); });

await app.RunAsync();