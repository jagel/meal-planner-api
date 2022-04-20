namespace JGL.Security.Auth.Domain.Entities
{
    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OrganizationCode { get; set; }
        public int UserOwnerId { get; set; }

        public virtual IEnumerable<OrganizationUser>? OrganizationUsers { get; set; }

    }
}
