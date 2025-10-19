using JGL.Agenda.Contracts.Models.Agendas;
using Microsoft.AspNetCore.Mvc;

namespace MealPlanner.Api.Controllers
{
    /// <summary>
    /// Agenda controller
    /// Responsible to manage the agenda settings
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        public AgendaController()
        {

        }

        [HttpGet("getByAgendaCode/{agendaCode}")]
        [ProducesResponseType(typeof(JGLModelResponse<Agenda>), StatusCodes.Status200OK)]
        public IActionResult GetAgendaSettingsByAgendaCode([FromRoute]string agendaCode) 
        {
            return Ok(agendaCode);
        }

        [HttpPut("updateAgenda")]
        public IActionResult UpdateAgenda([FromBody]AgendaUpdate agendaUpdate)
        {
            return Ok(agendaUpdate);
        }
        

    }
}
