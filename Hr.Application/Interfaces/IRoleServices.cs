using Hr.Application.ViewModels.EmployeesVM;
using Hr.Application.ViewModels.RolesVms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Application.Interfaces
{
    public interface IRoleServices
    {
        RoleFormVm InitModel();
        Task<(bool IsSuccess,string Message)> CreateRole(RoleFormVm model);
        Task<(bool IsSuccess,string Message)> EditRole(RoleFormVm model);
    }
}
