using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MealPlanner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PlannerRegisterController : BaseController
    {
        private readonly ILogger<PlannerRegisterController> _logger;
        public PlannerRegisterController(ILogger<PlannerRegisterController> logger)
        {
            _logger = logger;
        }

        [HttpGet("getPlannerRegisterPerDay/{day}", Name = "[controller].GetPlannerRegisterPerDay")]
        public IActionResult GetPlannerRegisterPerDay([FromRoute] DateTime day)
        {
            return Ok();
        }

        [HttpGet("GetPlannerRegisterPerWeek/{day}", Name = "[controller].GetPlannerRegisterPerWeek")]
        public IActionResult GetPlannerRegisterPerWeek([FromRoute] DateTime day)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult Put()
        {
            return Ok();
        }
    }
}
