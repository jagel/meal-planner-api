namespace JGL.Security.Auth.Domain.Entities
{
    public enum EUserStatus
    {
        Active,
        Inactive,
    }

    public class OrganizationUser
    {
        public int Id { get; set; }
        public EUserStatus UserStatus { get; set; }

        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
