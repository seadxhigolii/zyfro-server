using System.Threading.Tasks;
using Zyfro.Pro.Server.Application.Models.User;
using Zyfro.Pro.Server.Common.Response;
using Zyfro.Pro.Server.Domain.Entities;

namespace Zyfro.Pro.Server.Application.Interfaces
{
    public interface IAuthService
    {
        Task<ServiceResponse<string>> RegisterAsync(RegisterDto model);
        Task<ServiceResponse<string>> LoginAsync(LoginDto model);
        Task<string> GenerateJwtToken(ApplicationUser user);
    }
}
