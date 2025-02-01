using System.Threading.Tasks;
using System;
using Zyfro.Pro.Server.Application.Interfaces;
using Zyfro.Pro.Server.Application.Models.User;
using Zyfro.Pro.Server.Common.Response;
using Zyfro.Pro.Server.Domain.Entities;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Zyfro.Pro.Server.Common.Helpers;

namespace Zyfro.Pro.Server.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IProDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserService(IProDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<ApplicationUser>> GetByIdAsync(Guid Id)
        {
            var user = await _dbContext.ApplicationUsers.Where(x=>x.Id == Id && x.Deleted == false).FirstOrDefaultAsync();

            if (user == null) {
                return ServiceResponse<ApplicationUser>.ErrorResponse("User does not exist",404);
            }

            return ServiceResponse<ApplicationUser>.SuccessResponse(user,"Success", 200);

        }
        public async Task<ServiceResponse<bool>> UpdateUserAsync(UpdateUserDto model, Guid id)
        {
            var user = await _dbContext.ApplicationUsers.Where(x => x.Id == id && !x.Deleted).FirstOrDefaultAsync();

            if (user == null)
            {
                return ServiceResponse<bool>.ErrorResponse("User does not exist", 404);
            }

            _mapper.Map(model, user);

            user.LastUpdatedAtUtc = DateTime.UtcNow;

            if (!string.IsNullOrEmpty(model.Password))
            {
                user.PasswordHash = AuthHelper.HashPassword(model.Password, user.Salt);
            }

            await _dbContext.SaveChangesAsync();

            return ServiceResponse<bool>.SuccessResponse(true);
        }

        public async Task<ServiceResponse<bool>> DeleteUserAsync(Guid Id)
        {
            var user = _dbContext.ApplicationUsers.Where(x => x.Id == Id && x.Deleted == false).FirstOrDefault();

            if (user == null)
            {
                return ServiceResponse<bool>.ErrorResponse("User does not exist", 404);
            }

            user.Deleted = true;

            _dbContext.ApplicationUsers.Update(user);
            await _dbContext.SaveChangesAsync();

            return ServiceResponse<bool>.SuccessResponse(true, "Success", 200);

        }
    }
}
