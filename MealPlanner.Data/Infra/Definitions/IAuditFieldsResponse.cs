namespace JGL.Infra.Globals.Data.Definitions
{
    public interface IAuditFieldsResponse
    {
        /// <summary>
        /// Created By
        /// </summary>
        /// <example>
        /// mail@test.com
        /// </example>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Created By
        /// </summary>
        /// <example>
        /// 01-01-2022
        /// </example>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Created By
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
