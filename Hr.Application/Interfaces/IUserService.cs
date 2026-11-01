using Hr.Application.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Application.Interfaces
{
    public interface IUserService
    {
        Task<(bool IsSuccess, string error)> LoginAsync(LoginVm model);
        Task LogoutAsync();
        Task<UserFormVm> FillModel(UserFormVm? model=null);
        Task<(bool Succeeded, IEnumerable<string> Errors)> CreateUserAsync(UserFormVm model);
        Task<UserFormVm?> GetEditUserFormAsync(string id);
        Task<(bool Succeeded, IEnumerable<string> Errors)> UpdateUserAsync(UserFormVm model);
        Task<(bool Succeeded, IEnumerable<string> Errors)> ChangePasswordAsync(UserPasswordVm model);

    }
}
