using Zyfro.Pro.Server.Application.Interfaces;
using Zyfro.Pro.Server.Application.Models.User;
using Zyfro.Pro.Server.Domain.Entities;
using Zyfro.Pro.Server.Common.Response;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System;
using System.Linq;
using Zyfro.Pro.Server.Common.Constants;
using Microsoft.EntityFrameworkCore;
using Zyfro.Pro.Server.Common.Helpers;

namespace Zyfro.Pro.Server.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IProDbContext _dbContext;

        public AuthService(IConfiguration configuration, IProDbContext proDbContext)
        {
            _configuration = configuration;
            _dbContext = proDbContext;
        }

        public async Task<ServiceResponse<string>> RegisterAsync(RegisterDto model)
        {
            if (model.Password != model.ConfirmPassword)
                return ServiceResponse<string>.ErrorResponse(ValidatorMessages.PasswordsMustMatch, 400);

            var existingUser = await _dbContext.ApplicationUsers.Where(x=>x.Email == model.Email).FirstOrDefaultAsync();

            if (existingUser != null)
                return ServiceResponse<string>.ErrorResponse(ValidatorMessages.AlreadyExists("User"), 409);

            if(!ValidatorRegex.PasswordRegexValidator().IsMatch(model.Password) || model.Password.Length < 8)
            {
                return ServiceResponse<string>.ErrorResponse("Password must meet complexity requirements. " +
                    "Password must be at least 8 characters long, must include at least one capital letter and at least one symbol", 400);
            }

            var salt = PasswordHasher.GenerateSalt();

            var passwordHashed = AuthHelper.HashPassword(model.Password, salt);
            var user = new ApplicationUser
            {
                Email = model.Email.ToLowerInvariant(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                PasswordHash = passwordHashed,
                Salt = salt
            };

            var result = await _dbContext.ApplicationUsers.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            string secret = _configuration["TokenValidaton:Secret"];
            var token = AuthHelper.GenerateJwtToken(user, secret);
            return ServiceResponse<string>.SuccessResponse(token, "User registered successfully", 200);
        }

        public async Task<ServiceResponse<string>> LoginAsync(LoginDto model)
        {
            var user = await _dbContext.ApplicationUsers
                .Where(x => x.Email.ToLower() == model.Email.ToLower())
                .FirstOrDefaultAsync();

            if (user == null)
                return ServiceResponse<string>.ErrorResponse("Email or Password is wrong", 401);

            if (user.LockoutEndTime != null && user.LockoutEndTime > DateTime.UtcNow)
            {
                return ServiceResponse<string>.ErrorResponse("Your account is locked. Try again later.", 403);
            }

            bool verifyPass = AuthHelper.VerifyPassword(model.Password, user.PasswordHash, user.Salt);

            if (verifyPass)
            {
                user.FailedLoginAttempts = 0;
                user.LockoutEndTime = null;
                await _dbContext.SaveChangesAsync();

                string secret = _configuration["TokenValidaton:Secret"];
                var token = AuthHelper.GenerateJwtToken(user, secret);
                return ServiceResponse<string>.SuccessResponse(token, "User logged in successfully", 200);
            }

            user.FailedLoginAttempts++;

            if (user.FailedLoginAttempts >= 5)
            {
                user.LockoutEndTime = DateTime.UtcNow.AddMinutes(5);
            }

            await _dbContext.SaveChangesAsync();
            return ServiceResponse<string>.ErrorResponse("Email or Password is wrong", 401);
        }        
    }
}
