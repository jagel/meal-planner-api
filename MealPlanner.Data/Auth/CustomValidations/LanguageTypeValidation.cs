using JGL.Globals.Contracts.Validations;
using MealPlanner.Data.Auth.Definitions;
using System.ComponentModel.DataAnnotations;

namespace MealPlanner.Data.Auth.CustomValidations
{
    public class LanguageTypeValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (string.IsNullOrEmpty(value.ToString()))
            {
                ErrorMessage = MessagesValidation.ErrorRequiredMessage;
                return false;
            }

            var ignoreCase = false;
            var validValue = Enum.TryParse(value?.ToString(), ignoreCase, out ELanguageType type);
            
            ErrorMessage = $"Language '{value}' is not valid";
            return validValue;
        }
    }
}
