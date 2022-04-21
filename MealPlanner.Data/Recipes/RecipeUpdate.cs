using JGL.Globals.Contracts.Validations;
using System.ComponentModel.DataAnnotations;

namespace JGL.Recipes.Contracts.Models.Recipes
{
    /// <summary>
    /// Recipe returns recipe model.
    /// </summary>
    public class RecipeUpdate
    {
        /// <summary>
        /// RecipeId
        /// </summary>
        /// <example>1</example>
        [Required(ErrorMessage = MessagesValidation.ErrorRequiredMessage)]
        public int RecipeId { get; set; }

        /// <summary>
        /// Recipe Name
        /// </summary>
        /// <example>
        /// Meatballs
        /// </example>
        [Required(ErrorMessage = MessagesValidation.ErrorRequiredMessage)]
        [MaxLength(DefinitionsValues.MAXLENGTH_NAME, ErrorMessage = MessagesValidation.ErrorMaxLengthMessage)]
        public string Name { get; set; }


        /// <summary>
        /// Recipe Name
        /// </summary>
        /// <example>
        /// Description
        /// </example>
        [MaxLength(DefinitionsValues.MAXLENGTH_DESCRIPTION, ErrorMessage = MessagesValidation.ErrorMaxLengthMessage)]
        public string Description { get; set; }

        /// <summary>
        /// Recipe Steps collection
        /// </summary>
        /// <example>
        /// [{
        ///     order : 1,
        ///     description : 'Add water'
        /// },{
        ///     order : 2,
        ///     description: 'Serve'
        /// }]
        /// </example>
        [MaxLength(DefinitionsValues.MAXLENGTH_DESCRIPTION, ErrorMessage = MessagesValidation.ErrorMaxLengthMessage)]
        public IEnumerable<RecipeSteps> Steps { get; set; }

        /// <summary>
        /// Products collection
        /// </summary>
        public IEnumerable<RecipeProductCreate> Products { get; set; }
    }
}