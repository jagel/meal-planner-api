namespace JGL.Infra.Globals.Domain.Entities.Interfaces
{
    public interface IAuditEntity
    {
        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string? UpdatedBy { get; set; }
    }
}
