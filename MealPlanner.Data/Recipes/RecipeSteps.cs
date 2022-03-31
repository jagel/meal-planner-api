using JGL.Globals.Contracts.Validations;
using System.ComponentModel.DataAnnotations;

namespace JGL.Recipes.Contracts.Models.Recipes
{
    /// <summary>
    /// RecipeSteps
    /// </summary>
    public class RecipeSteps
    {
        /// <summary>
        /// Recipe Name
        /// </summary>
        /// <example>
        /// Meatballs
        /// </example>
        [MinLength(1, ErrorMessage = MessagesValidation.ErrorMinLNuberMessage)]
        public int Order { get; set; }

        /// <summary>
        /// In a large pot of salted, boiling water over medium-high heat, cook potatoes until just knife-tender, 7 to 8 minutes. Drain and let cool slightly.
        /// </summary>
        /// <example>
        /// Meatballs
        /// </example>
        [Required(ErrorMessage = MessagesValidation.ErrorRequiredMessage)]
        [MaxLength(DefinitionsValues.MAXLENGTH_DESCRIPTION, ErrorMessage = MessagesValidation.ErrorMaxLengthMessage)]
        public string Description { get; set; }
    }
}
