using System.ComponentModel.DataAnnotations;
using JGL.Globals.Contracts.Models.Interfaces;
using JGL.Globals.Contracts.Validations;

namespace JGL.Recipes.Contracts.Models.Recipes
{
    /// <summary>
    /// Recipe returns recipe model.
    /// </summary>
    public class RecipeSearch
    {
        /// <summary>
        /// Recipe Name
        /// </summary>
        /// <example>
        /// Meatballs
        /// </example>
        //[MaxLength(DefinitionsValues.MAXLENGTH_NAME, ErrorMessage = MessagesValidation.ErrorMaxLengthMessage)]
        public string Name { get; set; }

    }
}