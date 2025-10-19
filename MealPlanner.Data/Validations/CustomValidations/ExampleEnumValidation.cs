using System.ComponentModel.DataAnnotations;

namespace JGL.Globals.Contracts.Validations.CustomValidation
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    sealed public class ExampleEnumValidation : ValidationAttribute
    {
   
        public ExampleEnumValidation(Type enumType)
        {

        }


        public override bool IsValid(object value)
        {
            return true;
        }


        public override string FormatErrorMessage(string name)
        {
            return "hello";
        }

    }
}



