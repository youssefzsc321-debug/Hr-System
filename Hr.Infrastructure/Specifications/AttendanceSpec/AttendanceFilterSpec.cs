using Hr.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Infrastructure.Specifications.AttendanceSpec
{
    public class AttendanceFilterSpec:BaseSpecification<Attendance>
    {
        public AttendanceFilterSpec(int employeeId, int? year, int? month)
    : base(x => x.EmployeeId == employeeId &&
                !x.IsDeleted &&
                (!year.HasValue || x.Date.Year == year) &&
                (!month.HasValue || x.Date.Month == month))
        {
        }
    }
}
