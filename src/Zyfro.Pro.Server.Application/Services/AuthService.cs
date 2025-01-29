using Zyfro.Pro.Server.Application.Interfaces;
using Zyfro.Pro.Server.Application.Models.User;
using Zyfro.Pro.Server.Domain.Entities;
using Zyfro.Pro.Server.Common.Response;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Collections.Generic;
using System;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using Zyfro.Pro.Server.Common.Constants;

namespace Zyfro.Pro.Server.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<ServiceResponse<string>> RegisterAsync(RegisterModel model)
        {
            try
            {
                if (model.Password != model.ConfirmPassword)
                    return ServiceResponse<string>.ErrorResponse(ValidatorMessages.PasswordsMustMatch, 400);

                var existingUser = await _userManager.FindByEmailAsync(model.Email);
                if (existingUser != null)
                    return ServiceResponse<string>.ErrorResponse(ValidatorMessages.AlreadyExists("User"), 409);

                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                {
                    var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                    return ServiceResponse<string>.ErrorResponse(errors, 400);
                }

                var token = await GenerateJwtToken(user);
                return ServiceResponse<string>.SuccessResponse(token, "User registered successfully", 201);
            }
            catch (Exception)
            {
                throw;
            }
        
        }

        public async Task<string> GenerateJwtToken(ApplicationUser user)
        {
            return await Task.Run(() =>
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["TokenValidaton:Secret"]));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName)
                };

                var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.UtcNow.AddHours(5),
                    signingCredentials: credentials
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            });
        }
    }
}
