using MealPlanner.Api.DependencyInjections;
using MealPlanner.Api.Middelwares;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

//Database configuration
builder.Services.AddMySQLDatabase(builder.Configuration);

//CORS
builder.Services.AddCors();


//Authentication configuration
builder.Services.AddAuthenticationConfiguration(builder.Configuration);

//Global configuration
builder.Services.AddStandardServicesApp();

//Services 
builder.Services.AddAuthenticationDI();
builder.Services.AddRecipeServices();


//builder.Services.AddControllers();
builder.Services.AddControllers( o => { o.Filters.Add(new AuthorizeFilter()); });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocument(d => DocumentationConfiguration.DocumentationV0(d));


var app = builder.Build();
//

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi3();
}

app.UseHttpsRedirection();

// global cors policy
app.UseCors(x => x
    .WithOrigins("https://localhost:3000","http://localhost:3000")
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials()
); // allow credentials



app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.UseMiddleware<ExceptionMiddleware>();


app.Run();
