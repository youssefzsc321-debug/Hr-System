using ClosedXML.Excel;
using Hr.Application.Interfaces;
using Hr.Application.Repositories;
using Hr.Application.ViewModels.EmployeeReports;
using Hr.Application.ViewModels.EmployeesVM;
using Hr.Infrastructure.Specifications.AttendanceSpec;
using Hr.Infrastructure.Specifications.EmployeesSpec;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hr_System.Controllers
{
    public class SalaryReportController : Controller
    {
        private readonly IUnitOfWorkRepo _unitOfWorkRepo;
        private readonly ISalaryReportService _salaryReportService;

        public SalaryReportController(IUnitOfWorkRepo unitOfWorkRepo, ISalaryReportService salaryReportService)
        {
            _unitOfWorkRepo = unitOfWorkRepo;
            _salaryReportService = salaryReportService;
        }

        public async Task<IActionResult> Index(string? employeeName, int? year, int? month)
        {
            var model = await _salaryReportService.GetSalaryReportAsync(employeeName, year, month);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ExportSalaryToExcel(string? employeeName, int? month, int? year)
        {
            var bytes = await _salaryReportService.ExportSalaryToExcelAsync(employeeName, month, year);
            return File(
                bytes,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                $"Salary_Report_{month ?? DateTime.Now.Month}_{year ?? DateTime.Now.Year}.xlsx"
            );
        }

        [HttpGet]
        public async Task<IActionResult> ExportSalaryToPDF(string? employeeName, int? month, int? year)
        {
            var bytes = await _salaryReportService.ExportSalaryToPDFAsync(employeeName, month, year);
            return File(
                bytes,
                "application/pdf",
                $"Salary_Report_{month ?? DateTime.Now.Month}_{year ?? DateTime.Now.Year}.pdf"
            );
        }

        [HttpGet]
        public async Task<IActionResult> ExportEmployeePayslipToExcel(int employeeId, int month, int year)
        {
            var bytes = await _salaryReportService.ExportEmployeePayslipToExcelAsync(employeeId, month, year);
            return File(
                bytes,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                $"Payslip_{employeeId}_{month}_{year}.xlsx"
            );
        }

        [HttpGet]
        public async Task<IActionResult> ExportEmployeePayslipToPDF(int employeeId, int month, int year)
        {
            var bytes = await _salaryReportService.ExportEmployeePayslipToPDFAsync(employeeId, month, year);
            return File(
                bytes,
                "application/pdf",
                $"Payslip_{employeeId}_{month}_{year}.pdf"
            );
        }
    }
}