using MealPlanner.Api.Models.Recipes;
using MealPlanner.Data.Builders;
using MealPlanner.Data.Globals;
using MealPlanner.Domain.Recipes.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MealPlanner.Api.Controllers
{
    /// <summary>
    /// The main CarrierController class.
    /// Responsible for all CRUD operations on the Configuration entity.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class RecipeController : BaseController
    {
        private readonly ILogger<RecipeController> _logger;
        private readonly IRecipeService _recipeService;

        public RecipeController(ILogger<RecipeController> logger, IRecipeService recipeService)
        {
            _logger = logger;
            _recipeService = recipeService;
        }

        /// <summary>
        /// Get recipe record by Id.
        /// </summary>
        /// <remarks>
        /// This endpoint will retreive a recipe row filtered by configuration Id
        /// </remarks>
        /// <param name="recipeId">Recipe Id</param>
        /// <returns>Returns Recipe record by recipe Id</returns>
        [HttpGet("getRecipeById/{recipeId}", Name = "[controller].GetRecipeById")]
        [ProducesResponseType(typeof(ModelResponse<Recipe>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ModelResponse<Recipe>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ModelResponse<Recipe>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRecipeById([FromRoute] int recipeId)
        {
            if (recipeId <= 0)
                ModelState.AddModelError("recipeId", "recipe id invalid");

            if (ModelState.ErrorCount > 0)
                return BadRequest(ModelState);

            var recipe = await _recipeService.GetById(recipeId);

            var recipeResponse = new ModelResponse<Recipe>()
            {
                Data = recipe
            };

            return new OkObjectResult(recipeResponse);
        }

        /// <summary>
        /// Create recipe.
        /// </summary>
        /// <remarks>
        /// This endpoint will Create a recipe
        /// </remarks>
        /// <param name="recipeCreate">Recipe create model</param>
        /// <returns>Returns Recipe created</returns>
        [HttpPost("createRecipe", Name = "[controller].CreateRecipe")]
        [ProducesResponseType(typeof(ModelResponse<Recipe>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ModelResponse<Recipe>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateRecipe([FromBody] RecipeCreate recipeCreate)
        {
            if (ModelState.ErrorCount > 0)
                return BadRequest(ModelState);

            var recipe = await _recipeService.Create(recipeCreate);

            var recipeResponse = new ModelResponse<Recipe>()
            {
                Data = recipe
            };

            return new OkObjectResult(recipeResponse);
        }

        /// <summary>
        /// Update recipe.
        /// </summary>
        /// <remarks>
        /// This endpoint will Create a recipe
        /// </remarks>
        /// <param name="recipeId">Recipe to be updated</param>
        /// <param name="recipeUpdate">Recipe create model</param>
        /// <returns>Returns Recipe updated</returns>
        [HttpPut("updateRecipe/{recipeId}", Name = "[controller].UpdateRecipe")]
        [ProducesResponseType(typeof(ModelResponse<Recipe>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ModelResponse<Recipe>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateRecipe([FromRoute]int recipeId ,[FromBody] RecipeUpdate recipeUpdate)
        {
            if (recipeId != recipeUpdate.RecipeId)
                ModelState.AddModelError("RecipeId","Recipe id does not match with Recipe to update");

            if (ModelState.ErrorCount > 0)
                return BadRequest(ModelState);

            var recipe = await _recipeService.Update(recipeUpdate);

            var recipeResponse = new ModelResponse<Recipe>()
            {
                Data = recipe
            };

            return new OkObjectResult(recipeResponse);
        }

    }
}
