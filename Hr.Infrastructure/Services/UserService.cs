using Hr.Application.Interfaces;
using Hr.Application.Repositories;
using Hr.Application.ViewModels.User;
using Hr.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        private readonly IUnitOfWorkRepo _unitOfWorkRepo;
        public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IUnitOfWorkRepo unitOfWorkRepo)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _unitOfWorkRepo = unitOfWorkRepo;
        }

        public async Task<(bool Succeeded, IEnumerable<string> Errors)> ChangePasswordAsync(UserPasswordVm model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null)
            {
                return (false, new[] { "User not found." });
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, model.Password);

            if (!result.Succeeded)
            {
                return (false, result.Errors.Select(e => e.Description));
            }

            user.LastUpdatedOn = DateTime.UtcNow;
            await _userManager.UpdateAsync(user);

            return (true, Enumerable.Empty<string>());
        }

        public async Task<(bool Succeeded, IEnumerable<string> Errors)> CreateUserAsync(UserFormVm model)
        {
            var user = new AppUser()
            {
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName,
                CreatedOn = DateTime.Now,
            };

            var res = await _userManager.CreateAsync(user, model.Password!);

            if (!res.Succeeded)
            {
                return (false, res.Errors.Select(e => e.Description));
            }

            if (model.SelectedRoles != null && model.SelectedRoles.Any())
            {
                foreach (var roleId in model.SelectedRoles)
                {
                    var role = await _unitOfWorkRepo.Roles.GetByIdAsync(roleId);
                    if (role != null)
                    {
                        user.Roles.Add(role);
                    }
                }
                await _userManager.UpdateAsync(user);
            }

            return (true, Enumerable.Empty<string>());
        }

        public async Task<UserFormVm> FillModel(UserFormVm? model = null)
        {
            var modelVm = model ?? new UserFormVm();
            var roles = await _unitOfWorkRepo.Roles.GetAllAsync();
            modelVm.Roles = roles.Select(r => new SelectListItem { Text = r.Name, Value = r.Id.ToString() }).ToList();
            return modelVm;
        }

        public async Task<UserFormVm?> GetEditUserFormAsync(string id)
        {
            var user = await _userManager.Users.Include(u => u.Roles).FirstOrDefaultAsync(u => u.Id == id);
            if (user == null) return null;
            var modelVm = new UserFormVm()
            {
                Id= user.Id,
                FullName = user.FullName,
                Email = user.Email,
                UserName = user.UserName,
                SelectedRoles = user.Roles.Select(r => r.Id).ToList()
            };
            modelVm = await FillModel(modelVm);
            return modelVm;
            
        }

        public async Task<(bool IsSuccess, string error)> LoginAsync(LoginVm model)
        {
            var user = await _userManager.FindByNameAsync(model.EmailOrUserName)
                       ?? await _userManager.FindByEmailAsync(model.EmailOrUserName);

            if (user == null)
            {
                return (false, "Invalid username/email or password. Please try again.");
            }

            var result = await _signInManager.PasswordSignInAsync(
                user,
                model.Password,
                model.RememberMe,
                lockoutOnFailure: false
            );

            if (!result.Succeeded)
            {
                if (result.IsNotAllowed)
                    return (false, "You are not allowed to sign in. Please confirm your account.");
                if (result.IsLockedOut)
                    return (false, "Your account is locked. Please try again later.");

                return (false, "Invalid username/email or password. Please try again.");
            }

            var fullUser = await _userManager.Users
                .Include(u => u.Roles)
                .ThenInclude(r => r.Permissions) 
                .FirstOrDefaultAsync(u => u.Id == user.Id);

            if (fullUser != null)
            {
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, fullUser.Id),
            new Claim(ClaimTypes.Name, fullUser.UserName ?? ""),
            new Claim(ClaimTypes.Email, fullUser.Email ?? "")
        };

                foreach (var role in fullUser.Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role.Name));

                    if (role.Permissions != null)
                    {
                        foreach (var p in role.Permissions)
                        {
                            if (p.CanAdd) claims.Add(new Claim("Permission", $"{p.PageName}_Add"));
                            if (p.CanEdit) claims.Add(new Claim("Permission", $"{p.PageName}_Edit"));
                            if (p.CanDelete) claims.Add(new Claim("Permission", $"{p.PageName}_Delete"));
                            if (p.CanRead) claims.Add(new Claim("Permission", $"{p.PageName}_Read"));
                        }
                    }
                }

                await _signInManager.SignOutAsync();
                var claimsIdentity = new ClaimsIdentity(claims, IdentityConstants.ApplicationScheme);
                await _signInManager.SignInAsync(fullUser, model.RememberMe);
            }

            return (true, string.Empty);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<(bool Succeeded, IEnumerable<string> Errors)> UpdateUserAsync(UserFormVm model)
        {
            var user = await _userManager.Users
                        .Include(u => u.Roles)
                        .FirstOrDefaultAsync(u => u.Id == model.Id);

            if (user == null)
            {
                return (false, new[] { "User not found." });
            }

            user.FullName = model.FullName;
            user.UserName = model.UserName;
            user.Email = model.Email;
            user.LastUpdatedOn = DateTime.Now;

            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
            {
                return (false, updateResult.Errors.Select(e => e.Description));
            }

            if (!string.IsNullOrEmpty(model.Password))
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var passwordResult = await _userManager.ResetPasswordAsync(user, token, model.Password);

                if (!passwordResult.Succeeded)
                {
                    return (false, passwordResult.Errors.Select(e => e.Description));
                }
            }

            user.Roles.Clear();
            if (model.SelectedRoles != null && model.SelectedRoles.Any())
            {
                foreach (var roleId in model.SelectedRoles)
                {
                    var role = await _unitOfWorkRepo.Roles.GetByIdAsync(roleId);
                    if (role != null)
                    {
                        user.Roles.Add(role);
                    }
                }
            }

            await _userManager.UpdateAsync(user);

            return (true, Enumerable.Empty<string>());
        }
    }

}
