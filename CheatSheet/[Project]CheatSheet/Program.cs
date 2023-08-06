using _Project_CheatSheet.Common.Caching;
using _Project_CheatSheet.Common.UserService;
using _Project_CheatSheet.Common.UserService.Interfaces;
using _Project_CheatSheet.Extensions;
using _Project_CheatSheet.Features.Identity.Interfaces;
using _Project_CheatSheet.Infrastructure.Data.SQL;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

using _Project_CheatSheet.Infrastructure.Data.SQL.Seed;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");



//Identity

builder.Services.AddDbContext<CheatSheetDbContext>(options =>
        options.UseSqlServer(connectionString))
    .RegisterIdentity()
    .RegisterJwtAuthentication(builder.Configuration);


//Services

builder.Services.RegisterApplicationServices(typeof(IAuthenticateService));
builder.Services.AddScoped<ICurrentUser, CurrentUser>();
builder.Services.AddScoped<ICacheService, CacheService>();
builder.Services.AddScoped<DataSeeder>();

//Data providers
builder.Services
    .RegisterMongoDb(builder.Configuration)
    .RegisterAwsService(builder.Configuration);

//Auto mapper
builder.Services
    .RegisterAutoMapper(builder.Configuration);


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
    await app.RegisterSeedData();
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