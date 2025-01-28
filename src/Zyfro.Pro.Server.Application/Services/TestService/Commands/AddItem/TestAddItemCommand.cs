using MediatR;

namespace Zyfro.Pro.Server.Application.Services.TestService.Commands.AddItem
{
    public class TestAddItemCommand : IRequest
    {
        public string Name { get; set; }
    }
}
