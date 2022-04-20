using System.Security.Claims;
using JGL.Infra.ErrorManager.Data.Responses;

namespace JGL.Security.Auth.Data.Responses
{
    public class LoginResponse
    {
        public ErrorResponse ErrorResponse { get; set; }
        public bool Authenticated { get { return ErrorResponse == null; } }
        public ClaimsPrincipal ClaimsPrincipal { get; set; }
        public string Jwt { get; set; }

    }
}
