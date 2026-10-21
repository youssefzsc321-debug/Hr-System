using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Domain.Enums
{
    public enum Modules
    {
        Employees,
        [Display(Name = "General Settings")]
        GeneralSettings,
        [Display(Name = "Attendance And Departure")]
        AttendanceAndDeparture,
        [Display(Name = "Salary Report")]
        SalaryReport
    }
}
