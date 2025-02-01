using Microsoft.AspNetCore.Mvc;
using Zyfro.Pro.Server.Api.Controllers.Base;
using Zyfro.Pro.Server.Application.Interfaces;
using Zyfro.Pro.Server.Application.Models.User;
using Zyfro.Pro.Server.Common.Response;

namespace Zyfro.Pro.Server.Api.Controllers
{
    namespace Zyfro.Pro.Server.Api.Controllers
    {
        [Route("api/user")]
        public class UserController : BaseController
        {
            private readonly IUserService _userService;

            public UserController(IUserService userService)
            {
                _userService = userService;
            }

            [HttpGet("getById/{id}")]
            public async Task<IActionResult> GetById(Guid id)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ServiceResponse<string>.ErrorResponse("Invalid request data", 400));

                var response = await _userService.GetByIdAsync(id);

                return StatusCode(response.StatusCode, response);
            }

            [HttpPut("update/{id}")]
            public async Task<IActionResult> Login([FromBody] UpdateUserDto model, Guid id)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ServiceResponse<string>.ErrorResponse("Invalid request data", 400));

                var response = await _userService.UpdateUserAsync(model, id);

                return StatusCode(response.StatusCode, response);
            }

            [HttpDelete("delete/{id}")]
            public async Task<IActionResult> Delete(Guid id)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ServiceResponse<string>.ErrorResponse("Invalid request data", 400));

                var response = await _userService.DeleteUserAsync(id);

                return StatusCode(response.StatusCode, response);
            }
        }
    }

}
