using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Zyfro.Pro.Server.Api.Controllers.Base
{
    [ApiController]
    [Authorize]
    public abstract class BaseController : ControllerBase
    {

    }
}
