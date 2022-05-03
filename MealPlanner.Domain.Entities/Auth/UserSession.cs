namespace JGL.Security.Auth.Domain.Entities
{
    public class UserSession
    {
        public int Id { get; set; }
        public string AuthScheme { get; set; }
        public string JWT { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
    }
}
