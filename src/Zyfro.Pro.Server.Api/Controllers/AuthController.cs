using Microsoft.AspNetCore.Mvc;
using Zyfro.Pro.Server.Api.Controllers.Base;
using Zyfro.Pro.Server.Application.Interfaces;
using Zyfro.Pro.Server.Application.Models.User;
using Zyfro.Pro.Server.Application.Services.TestService.Commands.AddItem;
using Zyfro.Pro.Server.Application.Services.TestService.Queries.Get;
using Zyfro.Pro.Server.Common.Response;

namespace Zyfro.Pro.Server.Api.Controllers
{
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ServiceResponse<string>.ErrorResponse("Invalid request data", 400));

            var response = await _authService.RegisterAsync(model);

            return StatusCode(response.StatusCode, response);
        }
    }
}
