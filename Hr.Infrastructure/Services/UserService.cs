using Hr.Application.Interfaces;
using Hr.Application.ViewModels.User;
using Hr.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Infrastructure.Services
{
    internal class UserService : IUserService
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<(bool IsSuccess, string error)> LoginAsync(LoginVm model)
        {
            var user = await _userManager.FindByNameAsync(model.EmailOrUserName)
                       ?? await _userManager.FindByEmailAsync(model.EmailOrUserName);

            if (user == null)
            {
                return (false, "Invalid username/email or password. Please try again.");
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!isPasswordValid)
            {
                return (false, "Invalid username/email or password. Please try again.");
            }

            var claims = new List<Claim>
                {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName ?? string.Empty),
                new Claim("FullName", user.FullName ?? string.Empty),
                new Claim("RoleId", user.RoleId?.ToString() ?? "0")
                };

            var claimsIdentity = new ClaimsIdentity(claims, IdentityConstants.ApplicationScheme);

            await _signInManager.SignOutAsync();
            await _signInManager.Context.SignInAsync(IdentityConstants.ApplicationScheme, new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties
            {
                IsPersistent = model.RememberMe
            });

            return (true, string.Empty);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }

}
