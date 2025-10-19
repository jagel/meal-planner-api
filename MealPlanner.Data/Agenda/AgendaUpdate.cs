using JGL.Infra.Globals.Data.Definitions;
using JGL.Agenda.Contracts.CustomValidation;
using System.ComponentModel.DataAnnotations;
using JGL.Globals.Contracts.Validations;

namespace JGL.Agenda.Contracts.Models.Agendas
{
    public class AgendaUpdate
    {
        [Required(ErrorMessage = MessagesValidation.ErrorRequiredMessage)]
        public int AgendaId { get; set; }

        [AgendaCodeValidation]
        public string AgendaCode { get; set; }
    }
}
