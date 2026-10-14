using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Application.ViewModels.EmployeesVM
{
    public class EmployeeSepcParams
    {
        public string? Search { get; set; }

        public int? DepartmentId { get; set; }

        public int? NationalityId { get; set; }

        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
