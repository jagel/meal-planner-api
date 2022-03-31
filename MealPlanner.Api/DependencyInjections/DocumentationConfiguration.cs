using NSwag;
using NSwag.Generation.AspNetCore;
using NSwag.Generation.Processors;
using NSwag.Generation.Processors.Security;

namespace MealPlanner.Api.DependencyInjections
{
    public static class DocumentationConfiguration
    {
        public static void DocumentationV0(AspNetCoreOpenApiDocumentGeneratorSettings document)
        {
            document.Title = "Meal managger API";
            document.DocumentName = "v0.1";
            document.Description = "API Meals planner";
            document.Version = "beta";
            //document.DocumentProcessors.Add(AddJWTToken());
        }

        private static IDocumentProcessor AddJWTToken() =>
        new SecurityDefinitionAppender("JWT Token",
                    new OpenApiSecurityScheme
                    {
                        Type = OpenApiSecuritySchemeType.ApiKey,
                        Name = "Authorization",
                        Description = "Copy 'Bearer ' + valid JWT token into field",
                        In = OpenApiSecurityApiKeyLocation.Header
                    }
                );
    }
}
