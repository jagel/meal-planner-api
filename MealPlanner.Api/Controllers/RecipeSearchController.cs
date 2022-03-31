using JGL.Globals.Api.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MealPlanner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RecipeSearchController : BaseController
    {
        private readonly ILogger<RecipeSearchController> _logger;

        public RecipeSearchController(ILogger<RecipeSearchController> logger)
        {
            _logger = logger;
        }


        [HttpPut("{recipeId}", Name = "[controller].Put")]
        public async Task<IActionResult> Search()
        {
            var data = await Task.FromResult(Ok($"Done"));
            return data;
        }
    }
}
