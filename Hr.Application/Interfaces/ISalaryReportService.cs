using Hr.Application.ViewModels.EmployeeReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Application.Interfaces
{
    public interface ISalaryReportService
    {
        Task<SalaryReportFilterVm> GetSalaryReportAsync(string? employeeName, int? year, int? month);
    }
}
