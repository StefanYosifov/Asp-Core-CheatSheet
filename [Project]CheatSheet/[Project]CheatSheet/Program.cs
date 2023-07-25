using _Project_CheatSheet.Common.Caching;
using _Project_CheatSheet.Common.UserService;
using _Project_CheatSheet.Common.UserService.Interfaces;
using _Project_CheatSheet.Extensions;
using _Project_CheatSheet.Features.Identity.Interfaces;
using _Project_CheatSheet.Infrastructure.Data;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.RegisterApplicationServices(typeof(IAuthenticateService));

builder.Services.AddScoped<ICurrentUser, CurrentUser>();
builder.Services.AddScoped<ICacheService, CacheService>();


builder.Services.AddDbContext<CheatSheetDbContext>(options =>
        options.UseSqlServer(connectionString))
    .RegisterIdentity()
    .RegisterJwtAuthentication(builder.Configuration);

builder.Services
    .RegisterMongoDb(builder.Configuration);
builder.Services
    .RegisterAutoMapper(builder.Configuration);

builder.Services.RegisterAwsService(builder.Configuration);

builder.Services
    .RegisterPolicies()
    .RegisterCors(builder.Configuration)
    .RegisterSwagger();

builder.Services.AddMemoryCache();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddControllers();


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