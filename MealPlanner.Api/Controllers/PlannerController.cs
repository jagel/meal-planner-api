using JGL.Globals.Api.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JGL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
