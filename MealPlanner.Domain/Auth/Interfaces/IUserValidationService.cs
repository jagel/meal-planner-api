namespace MealPlanner.Domain.Auth.Interfaces
{
    interface IUserValidationService
    {
        Task ValdateUniqueEmail(string email);
    }
}
