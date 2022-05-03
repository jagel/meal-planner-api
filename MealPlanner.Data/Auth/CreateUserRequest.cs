using JGL.Globals.Contracts.Validations;
using MealPlanner.Data.Auth.CustomValidations;
using MealPlanner.Data.Auth.Definitions;
using System.ComponentModel.DataAnnotations;

namespace JGL.Security.Auth.Data.Requests
{
    /// <summary>
    /// Recipe returns recipe model.
    /// </summary>
    public class CreateUserRequest
    {
        /// <summary>
        /// email
        /// </summary>
        /// <example>
        /// mail@examplle.com
        /// </example>
        [Required(ErrorMessage = MessagesValidation.ErrorRequiredMessage)]
        public string Email { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        /// <example>
        /// jagel
        /// </example>
        [Required(ErrorMessage = MessagesValidation.ErrorRequiredMessage)]
        public string Username { get; set; }


        /// <summary>
        /// Name
        /// </summary>
        /// <example>
        /// Javier
        /// </example>
        [Required(ErrorMessage = MessagesValidation.ErrorRequiredMessage)]
        public string Name { get; set; }


        /// <summary>
        /// Lastname
        /// </summary>
        /// <example>
        /// Garcia
        /// </example>
        [Required(ErrorMessage = MessagesValidation.ErrorRequiredMessage)]
        public string Lastname { get; set; }


        /// <summary>
        /// Password
        /// </summary>
        /// <example>
        /// 12345678
        /// </example>
        [Required(ErrorMessage = MessagesValidation.ErrorRequiredMessage)]
        public string Password { get; set; }

        /// <summary>
        /// Language
        /// </summary>
        /// <example>
        /// es, en
        /// </example>
        [LanguageTypeValidation]
        public string Language { get; set; }
    }
}
