using System.ComponentModel.DataAnnotations;
using JGL.Globals.Contracts.Validations;
using JGL.Infra.Globals.Data.Definitions;

namespace JGL.Recipes.Contracts.Models.Recipes
{
    /// <summary>
    /// Recipe filters
    /// </summary>
    public class RecipeFilters
    {
        public bool IncludeProducts { get; set; }
    }
}