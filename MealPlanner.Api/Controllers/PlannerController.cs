using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MealPlanner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlannerController : BaseController
    {
        private readonly ILogger<PlannerController> _logger;

        public PlannerController(ILogger<PlannerController> logger)
        {
            _logger = logger;
        }


        [HttpGet("GetTableMetadata")]
        public IActionResult GetTableMetadata()
        {
            return Ok();
        }


        [HttpPut("GetAvailableDays")]
        public IActionResult GetAvailableDays()
        {
            return Ok();
        }

        [HttpPut("UpdateAvailableDays")]
        public IActionResult UpdateAvailableDays()
        {
            return Ok();
        }


        [HttpGet("GetRowData")]
        public IActionResult GetRowData()
        {
            return Ok();
        }

        [HttpGet("AddRowData")]
        public IActionResult AddRowData()
        {
            return Ok();
        }

        [HttpGet("UpdateRowData")]
        public IActionResult UpdateRowData()
        {
            return Ok();
        }
    }
}
