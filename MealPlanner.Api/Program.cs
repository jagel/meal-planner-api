using MealPlanner.Api.DependencyInjections;
using MealPlanner.Domain.Recipes.Interfaces;
using MealPlanner.Domain.Recipes.Services;
using MealPlanner.Infrastructure.DataProvider.Context;
using MealPlanner.Infrastructure.DataProvider.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


//Configuration.GetValue<string>("db") TODO: create ConfigurationProvider
var dbConnectionStr = builder.Configuration["connectionString:dbConnection"];
builder.Services.AddDbContext<DbMealPlannerContext>(options => options.UseMySql(dbConnectionStr, ServerVersion.AutoDetect(dbConnectionStr)));


// Add services to the container.
builder.Services.AddStandardServicesApp();

// Recipe
builder.Services.AddTransient<IRecipeRepository, RecipeRepository>();
builder.Services.AddTransient<IRecipeService, RecipeService>();
builder.Services.AddTransient<IRecipeValidation, RecipeValidation>();


builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerDocument(document =>
{
    document.Title = "Api.Meals.Planner";
    document.DocumentName = "v0.1";
    document.Description = "API Meals planner";
    document.Version = "beta";//"0.0.1";
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi3();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
