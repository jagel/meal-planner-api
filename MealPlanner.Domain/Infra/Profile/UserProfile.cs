namespace MealPlanner.Domain.Infra.Profile
{
    public class UserProfile : IUserProfile
    {
        public string GetUserEmail()
        {
            var userEmail = "user@test.com";
            return userEmail;
        }
    }
}
