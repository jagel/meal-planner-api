namespace JGL.Infra.Globals.API.Definitions
{
    public static class CodeResponse
    {
        public static string SUCCESSS = "200";

        public static string DUPLICATED = "520";
        public static string DUPLICATED_MESSAGE = "{1} duplicated for '{0}'. Duplication Error: '{2}' already exist";

        public static string NOTFOUND = "521";
        public static string NOTFOUND_MESSAGE = "{0} not found";

        public static string UNAUTHORIZED = "401";
        public static string UNAUTHORIZED_MESSAGE = "Unauthorized";

    }
}
