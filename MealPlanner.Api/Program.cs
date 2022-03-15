using MealPlanner.Api.DependencyInjections;
using MealPlanner.Api.Middelwares;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

//Database configuration
builder.Services.AddMySQLDatabase(builder.Configuration);

//Authentication configuration
//builder.Services.AddAuthenticationConfiguration(builder.Configuration);

//Global configuration
builder.Services.AddStandardServicesApp();

//Services 
builder.Services.AddAuthenticationDI();
builder.Services.AddRecipeServices();


builder.Services.AddControllers();
//builder.Services.AddControllers( o => { o.Filters.Add(new AuthorizeFilter()); });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocument(DocumentationConfiguration.DocumentationV0);


//services cors
builder.Services.AddCors(p => p.AddPolicy(ConfigVar.Cors.PolicyName, 
    builderCors =>
    {
        var origin = builder.Configuration.GetValue<string>(ConfigVar.Cors.Origin);
        builderCors.WithOrigins(origin);
        //builderCors.AllowAnyMethod();
        //builderCors.AllowCredentials();
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
app.UseCors(ConfigVar.Cors.PolicyName);

//app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.UseMiddleware<ExceptionMiddleware>();


app.Run();
