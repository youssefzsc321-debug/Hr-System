using Hr.Application.Interfaces;
using Hr.Application.Repositories;
using Hr.Application.ViewModels.EmployeeReports;
using Hr.Application.ViewModels.EmployeesVM;
using Hr.Infrastructure.Specifications.AttendanceSpec;
using Hr.Infrastructure.Specifications.EmployeesSpec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Infrastructure.Services
{
    public class SalaryReportService : ISalaryReportService
    {
        private readonly IUnitOfWorkRepo _unitOfWorkRepo;

        public SalaryReportService(IUnitOfWorkRepo unitOfWorkRepo)
        {
            _unitOfWorkRepo = unitOfWorkRepo;
        }

        public async Task<SalaryReportFilterVm> GetSalaryReportAsync(string? employeeName, int? year, int? month)
        {
            int targetMonth = month ?? DateTime.Now.Month;
            int targetYear = year ?? DateTime.Now.Year;

            var generalSettings = await _unitOfWorkRepo.GeneralSettings.GetByIdAsync(1);
            decimal overtimeRate = generalSettings?.OverTimeVal ?? 0;
            decimal deductionRate = generalSettings?.DeducationVal ?? 0;

            var employeeParams = new EmployeeSepcParams() { Search = employeeName };
            var employeeSpec = new EmployeesWithDepartmetnSpec(employeeParams);
            var employees = await _unitOfWorkRepo.Employees.GetAllAsyncWithSpec(employeeSpec);

            var reportList = new List<EmployeeSalaryReportVm>();

            foreach (var emp in employees)
            {
                var attendanceSpec = new AttendanceFilterSpec(emp.Id, targetYear, targetMonth);
                var attendances = await _unitOfWorkRepo.Attendances.GetAllAsyncWithSpec(attendanceSpec);

                int daysPresent = attendances.Count();
                int totalDaysInMonth = DateTime.DaysInMonth(targetYear, targetMonth);
                int daysAbsent = totalDaysInMonth - daysPresent;
                if (daysAbsent < 0) daysAbsent = 0;

                decimal basicSalary = emp.Salary;

                double totalDelayMinutes = 0;
                double totalOvertimeMinutes = 0;

                foreach (var att in attendances)
                {
                    if (att.CheckIn > emp.DefaultCheckIn)
                    {
                        var delay = att.CheckIn - emp.DefaultCheckIn;
                        totalDelayMinutes += delay.TotalMinutes;
                    }

                    if (att.CheckOut.HasValue && att.CheckOut > emp.DefaultCheckOut)
                    {
                        var overtime = att.CheckOut.Value - emp.DefaultCheckOut;
                        totalOvertimeMinutes += overtime.TotalMinutes;
                    }
                }

                double totalDelayHours = Math.Round(totalDelayMinutes / 60.0, 2);
                double totalOvertimeHours = Math.Round(totalOvertimeMinutes / 60.0, 2);

                decimal dayRate = basicSalary > 0 ? basicSalary / totalDaysInMonth : 0;
                decimal absenceDeduction = daysAbsent * dayRate;
                decimal delayDeduction = (decimal)totalDelayHours * deductionRate;

                decimal totalDeduction = absenceDeduction + delayDeduction;
                decimal totalOvertime = (decimal)totalOvertimeHours * overtimeRate;

                decimal netSalary = basicSalary + totalOvertime - totalDeduction;
                if (netSalary < 0) netSalary = 0;

                reportList.Add(new EmployeeSalaryReportVm
                {
                    EmployeeId = emp.Id,
                    EmployeeName = emp.FullName,
                    DepartmentName = emp.Department?.Name ?? "N/A",
                    BasicSalary = basicSalary,
                    DaysPresent = daysPresent,
                    DaysAbsent = daysAbsent,
                    OvertimeHours = totalOvertimeHours,
                    DeductionHours = totalDelayHours,
                    TotalOvertime = totalOvertime,
                    TotalDeduction = totalDeduction,
                    NetSalary = netSalary
                });
            }

            var model = new SalaryReportFilterVm
            {
                SearchTerm = employeeName,
                Month = targetMonth,
                Year = targetYear,
                ReportRecords = reportList
            };

            return model;

        }
    }
}
