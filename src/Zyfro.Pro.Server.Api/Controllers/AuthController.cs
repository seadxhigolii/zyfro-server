using Microsoft.AspNetCore.Mvc;
using Zyfro.Pro.Server.Api.Controllers.Base;
using Zyfro.Pro.Server.Application.Interfaces;
using Zyfro.Pro.Server.Application.Models.User;
using Zyfro.Pro.Server.Common.Response;

namespace Zyfro.Pro.Server.Api.Controllers
{
    [Route("api/auth")]
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ServiceResponse<string>.ErrorResponse("Invalid request data", 400));

            var response = await _authService.RegisterAsync(model);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ServiceResponse<string>.ErrorResponse("Invalid request data", 400));

            var response = await _authService.LoginAsync(model);

            return StatusCode(response.StatusCode, response);
        }
    }
}
