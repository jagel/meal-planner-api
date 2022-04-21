using JGL.Infra.Globals.Domain.Entities.Interfaces;

namespace JGL.Infra.Globals.Domain.Entities
{
    public class NameEntity : IAuditEntity, IIdEntity
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
