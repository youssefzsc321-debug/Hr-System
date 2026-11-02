using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Application.ViewModels.EmployeeReports
{
    public class EmployeeSalaryReportVm
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } 
        public string DepartmentName { get; set; } 
        public decimal BasicSalary { get; set; }

        public int DaysPresent { get; set; }
        public int DaysAbsent { get; set; }
        public double OvertimeHours { get; set; }
        public double DeductionHours { get; set; }

        public decimal TotalOvertime { get; set; }
        public decimal TotalDeduction { get; set; }

        public decimal NetSalary { get; set; }
    }
}
