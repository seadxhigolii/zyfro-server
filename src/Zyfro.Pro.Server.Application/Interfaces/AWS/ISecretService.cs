using System.Threading.Tasks;

namespace Zyfro.Pro.Server.Application.Interfaces.AWS
{
    public interface ISecretService
    {
        Task<string> GetSecret();
    }
}
