using JGL.Domain.Entities.Globals.Interfaces;

namespace JGL.Infra.Domain.Entities
{
    public class NameEntity : IAuditEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        //Audit Fields
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
