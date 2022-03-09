namespace MealPlanner.Api
{
    public static class Properties
    {
        public static class ConfigurationVariables
        {
            public static string DatabaseConnecion = "connectionString:dbConnection";

            public static class Google
            {
                public static string AuthenticatioinScheme = "ExternalGoogle";
                public static string ClientId = "google.clientId";
                public static string ClientSecret = "google.clientSecret";
            }

            public static class Cors
            {
                public static string Origin = "origin-route";
                public static string PolicyName = "corsapp";

            }
        }

        public static class SwaggerDocumentation
        {
           public static class V0
            {
                 public static string Title = "corsapp";
            public static string DocumentName = "v0.1";
            public static string Description = "API Meals planner";
            public static string Version = "beta";
            }
        }
    }
}
