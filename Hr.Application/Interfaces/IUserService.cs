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
    }
}
