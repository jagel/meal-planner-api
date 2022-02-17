using MealPlanner.Api.Definitions;
using MealPlanner.Api.Models.Recipes;
using MealPlanner.Data.Builders;
using MealPlanner.Data.Globals;
using Microsoft.AspNetCore.Mvc;

namespace MealPlanner.Api.Controllers
{
    /// <summary>
    /// The main CarrierController class.
    /// Responsible for all CRUD operations on the Configuration entity.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : BaseController
    {
        private readonly ILogger<RecipeController> _logger;
        public RecipeController(ILogger<RecipeController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Get recipe record by Id.
        /// </summary>
        /// <remarks>
        /// This endpoint will retreive a recipe row filtered by configuration Id
        /// </remarks>
        /// <param name="recipeId">Recipe Id</param>
        /// <returns>Returns Recipe record by recipe Id</returns>
        [HttpGet("getByRecipeId/{recipeId}", Name = "[controller].GetByRecipeId")]
        [ProducesResponseType(typeof(ModelResponse<Recipe>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ModelResponse<Recipe>), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ModelResponse<Recipe>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByRecipeId([FromRoute] int recipeId)
        {
            var response = new ModelResponse<Recipe>()
            {
                Data = new()
                {
                    RecipeId = 1,
                    Name = "Sandwitch",
                    Description = "Ingredients: xxxx, instructions: xxxx"
                }
            };

            if (response.Data == null)
            {

                response = ErrorResponse.NotFoundErrorResponse(response, GetLanguage());
                return new NotFoundObjectResult(response);
            }

            return new OkObjectResult(response);
        }

        //[HttpPost(Name = "[controller].Post")]

        //public IActionResult Post()
        //{
        //    return Ok();
        //}


        //[HttpPut(Name = "[controller].Put")]
        //public IActionResult Update([FromRoute]int recipeId, [FromBody] object request)
        //{
        //if (recipeId != request.recipeId)
        //    ModelState.AddModelError(nameof(request.ConfigurationId), "ConfigurationId does not match");

        //if (!ModelState.IsValid)
        //    return BadRequest(ModelState);

        //    return Ok();
        //}
    }
}
