namespace MealPlanner.Data.Globals
{
    public interface IAuditFieldsResponse
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
