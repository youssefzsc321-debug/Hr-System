using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Application.ViewModels.EmployeeReports
{
    public class SalaryReportFilterVm
    {
        public string? SearchTerm { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
        public IEnumerable<EmployeeSalaryReportVm> ReportRecords { get; set; } = new List<EmployeeSalaryReportVm>();
    }
}
