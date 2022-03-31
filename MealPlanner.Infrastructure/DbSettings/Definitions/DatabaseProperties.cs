namespace MealPlanner.Infrastructure.DbSettings.Definitions
{
    public static class DatabaseProperties
    {
        public static class MySQL
        {
            public const int MAXLENGTH_DESCRIPTION = 250;
            public const int MAXLENGTH_GUID = 50;
            public const int MAXLENGTH_SHORTNAME = 50;
            public const int MAXLENGTH = 5000;
            public const int MAXLENGTH_NAME = 100;
            public const int MAXLENGTH_ENUM = 50;


            public const string TYPE_DATETIME = "DATETIME";
            //public const string TYPE_DATETIME = "datetime2";
        }
    }
}
