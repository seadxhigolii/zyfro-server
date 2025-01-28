using MediatR;
using System.Collections.Generic;

namespace Zyfro.Pro.Server.Application.Services.TestService.Queries.Get
{
    public class GetItemsQuery : IRequest<IList<GetItemsModel>>
    {
    }
}
