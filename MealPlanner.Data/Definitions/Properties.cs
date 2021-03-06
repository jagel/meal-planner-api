namespace JGL.Infra.Globals.Data.Definitions 
{ 
    public static class Properties
    {
        public static class ConfigurationVariables
        {
            public static string DatabaseConnecion = "connectionString:dbConnection";
            public static string PrivateToken = "privateTokenKey";
            public static string TokenCookie = "jwt";
            
            public static class Google
            {
                public static string ClientId = "google.clientId";
                public static string ClientSecret = "google.clientSecret";
            }

            public static class Cors
            {
                public static string Origin = "origin-route";
                public static string PolicyName = "corsapp";

            }
        }
    }
}
