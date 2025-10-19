using JGL.Globals.Api.Controllers;
using JGL.Recipes.Contracts.Models.Recipes;
using JGL.Recipes.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JGL.Api.Controllers
{
    /// <summary>
    /// The main SearchController class.
    /// Responsible for all CRUD operations on the Configuration entity.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RecipeSearchController(
        ILogger<RecipeSearchController> logger,
        IRecipeSearchService recipeSearchService) 
        : BaseController
    {
        /// <summary>
        /// Search recipes by query params
        /// </summary>
        /// <param name="recipeSearch">Recipe search query params</param>
        /// <remarks>
        /// This endpoint will retreive a list of recipes filtered query params
        /// </remarks>
        /// <returns>Returns Recipes records</returns>
        [HttpGet("search",Name = "[controller].Search")]
        [ProducesResponseType(typeof(JGLModelResponse<IEnumerable<Recipe>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Search([FromQuery]RecipeSearch recipeSearch)
        {
            var recipes = await recipeSearchService.SearchAsync(recipeSearch);

            var response = new JGLModelResponse<IEnumerable<Recipe>>()
            {
                Data = recipes
            };

            return Ok(response);
        }
    }
}
