using MealPlanner.Api.DependencyInjections;
using MealPlanner.Domain.Recipes.Interfaces;
using MealPlanner.Domain.Recipes.Services;
using MealPlanner.Infrastructure.DataProvider.Context;
using MealPlanner.Infrastructure.DataProvider.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


//Configuration.GetValue<string>("db") TODO: create ConfigurationProvider
var dbConnectionStr = builder.Configuration["connectionString:dbConnection"];
builder.Services.AddDbContext<DbMealPlannerContext>(options => options.UseMySql(dbConnectionStr, ServerVersion.AutoDetect(dbConnectionStr)));

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        //options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
    })
    .AddCookie()
    .AddCookie("ExternalGoogle")
    .AddGoogle(options =>
    {
        options.SignInScheme = "ExternalGoogle";
        options.ClientId = builder.Configuration["google.clientId"];
        options.ClientSecret = builder.Configuration["google.clientSecret"];
    });

// Add services to the container.
builder.Services.AddStandardServicesApp();

builder.Services.AddAuthenticationSevices();

// Recipe
builder.Services.AddTransient<IRecipeRepository, RecipeRepository>();
builder.Services.AddTransient<IRecipeService, RecipeService>();
builder.Services.AddTransient<IRecipeValidation, RecipeValidation>();


builder.Services.AddControllers( o => 
    o.Filters.Add(new AuthorizeFilter())
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerDocument(document =>
{
    document.Title = "Api.Meals.Planner";
    document.DocumentName = "v0.1";
    document.Description = "API Meals planner";
    document.Version = "beta";//"0.0.1";
});

//services cors
var originRoute = builder.Configuration["origin-route"];
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins(originRoute).AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi3();
}

app.UseHttpsRedirection();

//app cors
app.UseCors("corsapp");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
