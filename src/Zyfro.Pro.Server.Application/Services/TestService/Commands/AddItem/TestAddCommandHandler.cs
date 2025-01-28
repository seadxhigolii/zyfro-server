using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Zyfro.Pro.Server.Application.Services.TestService.Commands.AddItem
{
    public class TestAddCommandHandler : IRequestHandler<TestAddItemCommand>
    {
        public Task Handle(TestAddItemCommand request, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
