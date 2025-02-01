using System;
using System.Threading.Tasks;
using Zyfro.Pro.Server.Application.Models.User;
using Zyfro.Pro.Server.Common.Response;
using Zyfro.Pro.Server.Domain.Entities;

namespace Zyfro.Pro.Server.Application.Interfaces
{
    public interface IUserService
    {
        Task<ServiceResponse<ApplicationUser>> GetByIdAsync(Guid Id);
        Task<ServiceResponse<bool>> UpdateUserAsync(UpdateUserDto model, Guid Id);
        Task<ServiceResponse<bool>> DeleteUserAsync(Guid Id);
    }
}
