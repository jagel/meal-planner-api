using MealPlanner.Data.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Cryptography;

namespace MealPlanner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        public static User user = new User();
        public AuthController()
        {

        }

        [HttpPost("login", Name = "[controller].login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest userRequest)
        {
            if (userRequest.Email != user.Email)
            {
                return BadRequest("error");
            }
            if (!VerifyPasswordHash(userRequest.Password, user.PasswordHash, user.PasswordSalt))
            {

            }
            return Ok("Completed");
        }


        [HttpPost("register", Name = "[controller].register")]
        public async Task<IActionResult> Register([FromBody] UserLoginRequest UserRequest)
        {
            CreatePasswordHash(UserRequest.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.Email = UserRequest.Email;
            user.Password = UserRequest.Password;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            return Ok(user);
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(User userModel)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Email, userModel.Email)
            };
            //var key =  new SymmetricSecurityKey()
            //var credentian = new SigningCredentials()
            var token = new JwtSecurityToken();
        }
    }

    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
