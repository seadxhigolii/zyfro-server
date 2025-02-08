using System.Threading.Tasks;

namespace Zyfro.Pro.Server.Application.Interfaces.AWS
{
    public interface ISecretService
    {
        Task<(string accessKey, string secretKey)> GetSecret();
    }
}
