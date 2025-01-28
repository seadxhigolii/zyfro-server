using Zyfro.Pro.Server.Application.Services.TestService.Queries.Get;
using Zyfro.Pro.Server.UnitTest.Base;
using System.Threading.Tasks;
using Xunit;

namespace Zyfro.Pro.Server.UnitTest
{
    public class UnitTest1 : UnitContext
    {
        [Fact]
        public async Task Test1()
        {
            var query = new GetItemsQuery();

            var result = await Mediator.Send(query);

            Assert.NotNull(result);
        }
    }
}