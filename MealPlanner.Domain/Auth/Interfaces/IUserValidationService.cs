namespace MealPlanner.Domain.Auth.Interfaces
{
    public interface IUserValidationService
    {
        Task ValdateUniqueEmailAsync(string email);
    }
}
