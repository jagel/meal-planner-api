using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MealPlanner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
