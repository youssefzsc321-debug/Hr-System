using DocumentFormat.OpenXml.Bibliography;
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
            var model=await _salaryReportService.GetSalaryReportAsync(employeeName, year, month);
            return View(model);
        }
    }
}
