﻿using JGL.Globals.Contracts.Validations;
using System.ComponentModel.DataAnnotations;

namespace JGL.Recipes.Contracts.Models.Recipes
{
    /// <summary>
    /// Recipe products saved with recipe.
    /// </summary>
    public class RecipeProductCreate
    {
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
        public int Quantity { get; set; }

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
        [MaxLength(DefinitionsValues.MAXLENGTH_FRACTIONARY, ErrorMessage = MessagesValidation.ErrorMaxLengthMessage)]
        public string MeasureType { get; set; }
    }
}