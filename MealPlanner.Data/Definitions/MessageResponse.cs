namespace MealPlanner.Daa.Definitions
{
    public class MessageResponse
    {

        public static string GETNOTFOUNDMESSAGE(string lang = "en")
        {
            return lang == "en" ? "Item Not Found." : "Elemento no encontrado";
        }
        public static string ENTITYNOTFOUND = "Entity not Found.";
        public static string NOTFOUND = "Not found:";

        public static string UNABLETODELETETITLE = "Delete/Deactivate exception.";
        public static string UNABLETODELETEDETAIL = "An error ocurred in delete/deactivate reaquest.";
        public static string DELETE = "Delete:";


        public static string NOTFOUNDBYENTITY<TEntity>() =>
            $"{typeof(TEntity).Name} not found.";

        public static string DELETEBYENTITY<TEntity>() =>
            $"{typeof(TEntity).Name} unable to delete/deactivate.";
    }
}
