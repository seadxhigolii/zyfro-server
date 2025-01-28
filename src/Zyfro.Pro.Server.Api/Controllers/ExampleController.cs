using Zyfro.Pro.Server.Api.Controllers.Base;
using Zyfro.Pro.Server.Application.Services.TestService.Commands.AddItem;
using Zyfro.Pro.Server.Application.Services.TestService.Queries.Get;
using Microsoft.AspNetCore.Mvc;

namespace Zyfro.Pro.Server.Api.Controllers
{
    [Route("api/examples")]
    public class ExampleController : BaseController
    {
        [HttpPost(":add")]
        public async Task<IActionResult> AddItem([FromBody] TestAddItemCommand command)
        {
            await Mediator.Send(command);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetItems([FromQuery] GetItemsQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }
    }
}
