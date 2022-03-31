using System.ComponentModel.DataAnnotations;
using JGL.Globals.Contracts.Models.Interfaces;
using JGL.Globals.Contracts.Validations;

namespace JGL.Recipes.Contracts.Models.Recipes
{
    /// <summary>
    /// Recipe returns recipe model.
    /// </summary>
    public class Recipe : IAuditFieldsResponse
    {
        /// <summary>
        /// RecipeId
        /// </summary>
        /// <example>
        /// 1
        /// </example>
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
        public IEnumerable<RecipeSteps> Steps { get; set; }

        /// <summary>
        /// Created By
        /// </summary>
        /// <example>
        /// mail@test.com
        /// </example>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Created By
        /// </summary>
        /// <example>
        /// 01-01-2022
        /// </example>
        public DateTime CreatedDate { get; set; }


        /// <summary>
        /// Created By
        /// </summary>
        /// <example>
        /// mail@test.com
        /// </example>
        public string? UpdatedBy { get; set; }

        /// <summary>
        /// Updated DateTime
        /// </summary>
        /// <example>
        /// 2022-02-18T16:11:07
        /// </example>
        public DateTime? UpdatedDate { get; set; }
    }
}