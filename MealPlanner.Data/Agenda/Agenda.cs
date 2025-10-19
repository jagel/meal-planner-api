using JGL.Infra.Globals.Data.Definitions;
using JGL.Agenda.Contracts.CustomValidation;

namespace JGL.Agenda.Contracts.Models.Agendas
{
    public class Agenda : IAuditFieldsResponse
    {
        public int AgendaId { get; set; }

        [AgendaCodeValidation]
        public AgendaCodeEnum AgendaCode { get; set; }

        public string[] DisabledDays { get; set; }

        
        public int MyProperty { get; set; }

        /// <summary>
        /// Created By
        /// </summary>
        /// <example>
        /// mail@test.com
        /// </example>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Created Date
        /// </summary>
        /// <example>
        /// 01-01-2022
        /// </example>
        public DateTime CreatedDate { get; set; }


        /// <summary>
        /// Updated By
        /// </summary>
        /// <example>
        /// mail@test.com
        /// </example>
        public string? UpdatedBy { get; set; }

        /// <summary>
        /// Updated DateTime
        /// </summary>
        /// <example>
        /// 2022-02-18T16:11:07
        /// </example>
        public DateTime? UpdatedDate { get; set; }
    }
}
