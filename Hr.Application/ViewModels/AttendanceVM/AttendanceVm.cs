using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Application.ViewModels.AttendanceVM
{
    public class AttendanceVm
    {
        public int Id { get; set; }

        public string EmployeeName { get; set; } 

        public string DepartmentName { get; set; } 

        public DateOnly Date { get; set; }

        public TimeOnly CheckIn { get; set; }

        public TimeOnly? CheckOut { get; set; }
    }
}
