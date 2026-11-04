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
        Task<byte[]> ExportSalaryToExcelAsync(string? employeeName, int? month, int? year);
        Task<byte[]> ExportSalaryToPDFAsync(string? employeeName, int? month, int? year);
        Task<byte[]> ExportEmployeePayslipToExcelAsync(int employeeId, int month, int year);
        Task<byte[]> ExportEmployeePayslipToPDFAsync(int employeeId, int month, int year);
    }
}
