﻿using JGL.Security.Auth.Data.Requests;
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

        public AccountController(ILogger<AccountController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet("getUser", Name = "[controller].getUser")]
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
                var errorResponse = new JGLModelResponse<UserSessionResponse>
                {
                    ErrorResponse = new Infra.ErrorManager.Data.Responses.ErrorResponse { Title = "Unauthorized"}
                };
                return Unauthorized(errorResponse);
            }
        }

        [HttpPost("createAccount", Name = "[controller].CreateAccount")]
        [ProducesResponseType(typeof(JGLModelResponse<UserResponse>), StatusCodes.Status200OK)]
        [AllowAnonymous]
        public async Task<IActionResult> CreateAccount(CreateUserRequest createUserRequest)
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
