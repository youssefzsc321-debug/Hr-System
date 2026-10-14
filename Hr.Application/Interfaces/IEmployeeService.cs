using Hr.Application.ViewModels.EmployeesVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<FormVm> PrepareFormVmAsync(FormVm model = null);
        Task<(bool IsSuccess, Dictionary<string, string> FillErrors)> CreateEmployeeAsync(FormVm model);
        Task<(bool IsSuccess, Dictionary<string, string> FillErrors)> UpdateEmployeeAsync(FormVm model);
        Task<bool> ToggleStatusAsync(int id);
    }
}
