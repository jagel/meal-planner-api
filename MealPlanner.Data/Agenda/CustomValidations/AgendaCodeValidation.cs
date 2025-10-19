using System.ComponentModel.DataAnnotations;
using JGL.Agenda.Contracts.Models.Agendas;

namespace JGL.Agenda.Contracts.CustomValidation
{
    public class AgendaCodeValidation : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var valueName = value as string;
            var agendaValid = Enum.TryParse(typeof(AgendaCodeEnum), value.ToString(), false, out var modelResult);  // Animal.Dog
            if (!agendaValid)
            {
                var errorMessage = "Parameters valid: ";
                var values = Enum.GetNames(typeof(AgendaCodeEnum));

                errorMessage += string.Join(", ", values);
                return new ValidationResult(errorMessage);
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
