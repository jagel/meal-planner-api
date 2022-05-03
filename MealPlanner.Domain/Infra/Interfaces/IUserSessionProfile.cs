using MealPlanner.Data.Auth.Definitions;

namespace JGL.Infra.Globals.API.Domain.Interfaces
{
    public interface IUserSessionProfile
    {
        public string GetUserEmail();
        public string GetUserInSession();
        public ELanguageType GetUserLanguage();
    }
}
