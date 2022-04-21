using JGL.Globals.Contracts.Validations;
using System.ComponentModel.DataAnnotations;

namespace JGL.Recipes.Contracts.Models.Recipes
{
    /// <summary>
    /// Recipe products response.
    /// </summary>
    public class RecipeProduct
    {
        /// <summary>
        /// Recipe product Id
        /// </summary>
        /// <example>
        /// 1
        /// </example>
        public int RecipeProductId { get; set; }

        /// <summary>
        /// Product name
        /// </summary>
        /// <example>
        /// Lemon
        /// </example>
        [Required(ErrorMessage = MessagesValidation.ErrorRequiredMessage)]
        [MaxLength(DefinitionsValues.MAXLENGTH_NAME, ErrorMessage = MessagesValidation.ErrorMaxLengthMessage)]

        public string Name { get; set; }

        /// <summary>
        /// Integer unit
        /// </summary>
        /// <example>
        /// 1
        /// </example>
        public int Amount { get; set; }

        /// <summary>
        /// Fractionary value
        /// </summary>
        /// <example>
        /// 1/2
        /// </example>
        [MaxLength(DefinitionsValues.MAXLENGTH_FRACTIONARY, ErrorMessage = MessagesValidation.ErrorMaxLengthMessage)]
        public string Fractionary { get; set; }

        /// <summary>
        /// Meassure type in catalog
        /// </summary>
        /// <example>
        /// Cups
        /// </example>
        public string MeasureType { get; set; }
    }
}
