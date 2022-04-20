using JGL.Domain.Entities.Globals.Interfaces;

namespace JGL.Infra.Domain.Entities
{
    public class DescriptiveEntity : IAuditEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        //Audit Fields
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
