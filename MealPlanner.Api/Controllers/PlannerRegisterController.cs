using JGL.Globals.Api.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JGL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PlannerRegisterController(ILogger<PlannerRegisterController> logger) : BaseController
    {
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
