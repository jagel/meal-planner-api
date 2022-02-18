namespace MealPlanner.Api.Models.Recipes
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
        public int RecipeId { get; set; }

        /// <summary>
        /// Recipe Name
        /// </summary>
        /// <example>
        /// Meatballs
        /// </example>
        public string Name { get; set; }


        /// <summary>
        /// Recipe Name
        /// </summary>
        /// <example>
        /// Description
        /// </example>
        public string Description { get; set; }
    }
}