namespace JGL.Security.Auth.Domain.Interfaces
{
    public interface ISecurityService
    {
        bool IsPasswordHashValid(string password, byte[] passwordHash, byte[] passwordSalt);
        (byte[] passwordHash, byte[] passwordSalt) CreatePasswordHash(string password);
    }
}
