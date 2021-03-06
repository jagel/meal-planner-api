using JGL.Infra.ErrorManager.Domain.Exceptions;
using JGL.Infra.ErrorManager.Domain.Interfaces;
using JGL.Security.Auth.Data.Requests;
using JGL.Security.Auth.Data.Responses;
using JGL.Security.Auth.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JGL.Api.Controllers
{
    /// <summary>
    /// The main Account controller class.
    /// Responsible for account and administration.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;
        private readonly IErrorResponseService _errorResponseService;

        public AccountController(ILogger<AccountController> logger,
            IUserService userService,
            IJwtService jwtService, 
            IErrorResponseService errorResponseService)
        {
            _logger = logger;
            _userService = userService;
            _jwtService = jwtService;
            _errorResponseService = errorResponseService;
        }

        /// <summary>
        /// Get user in session information
        /// </summary>
        /// <returns>User in session information</returns>
        [HttpGet("getUser", Name = "[controller].getUser")]
        [ProducesResponseType(typeof(JGLModelResponse<UserSessionResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(JGLModelResponse<UserSessionResponse>), StatusCodes.Status401Unauthorized)]
        [AllowAnonymous]
        public async Task<IActionResult> GetUser()
        {
            try
            {
                var jwt = Request.Cookies[ConfigVar.TokenCookie];
                var token = _jwtService.VerifyToken(jwt);
                int userId = int.Parse(token.Issuer);

                var userSession = await _userService.GetUserSessionByIdAsync(userId);

                var response = new JGLModelResponse<UserSessionResponse>
                {
                    Data = userSession
                };

                return Ok(response);
            }
            catch
            {
                var errorMessages= _errorResponseService.Unauthorized();
                var errorException = new JGLAppException(errorMessages);
                var errorResponse = errorException.GenerateErrorResponse();
                return Ok(errorResponse);
            }
        }

        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="createUserRequest">User request model</param>
        /// <returns>User saved</returns>
        [AllowAnonymous]
        [HttpPost("createAccount", Name = "[controller].CreateAccount")]
        [ProducesResponseType(typeof(JGLModelResponse<UserResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateAccount([FromBody]CreateUserRequest createUserRequest)
        {
            var userSaved = await _userService.CreateUserAsync(createUserRequest);

            var respone = new JGLModelResponse<UserResponse>
            {
                Data = userSaved
            };

            return Ok(respone);
        }


        [HttpPost("changePassword")]
        public IActionResult ChangePassword()
        {
            return Ok();
        }

    }
}
