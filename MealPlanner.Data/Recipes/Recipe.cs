using MealPlanner.Data.Globals;

namespace MealPlanner.Api.Models.Recipes
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
        public string Name { get; set; }


        /// <summary>
        /// Recipe Name
        /// </summary>
        /// <example>
        /// Description
        /// </example>
        public string Description { get; set; }



        /// <summary>
        /// Created By
        /// </summary>
        /// /// <example>
        /// XXXXX-XXXXX-XXXXX-XXXX
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
        /// XXXXX-XXXXX-XXXXX-XXXX
        /// </example>
        public string? UpdatedBy { get; set; }

        /// <summary>
        /// Updated DateTime
        /// </summary>
        /// <example>
        /// 01-01-2022
        /// </example>
        public DateTime? UpdatedDate { get; set; }
    }
}