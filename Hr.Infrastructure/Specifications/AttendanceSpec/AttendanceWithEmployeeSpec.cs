using Hr.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Infrastructure.Specifications.AttendanceSpec
{
    public class AttendanceWithEmployeeSpec : BaseSpecification<Attendance>
    {
        public AttendanceWithEmployeeSpec(string? search, DateOnly? fromDate, DateOnly? toDate)
            : base(a =>
                (string.IsNullOrEmpty(search) ||
                 a.Employee.FullName.Contains(search) ||
                 a.Employee.Department.Name.Contains(search)) &&
                (!fromDate.HasValue || a.Date >= fromDate.Value) &&
                (!toDate.HasValue || a.Date <= toDate.Value))
        {
            AddInclude(a => a.Employee);
            AddInclude(a => a.Employee.Department);
        }

        public AttendanceWithEmployeeSpec(int id) : base(a => a.Id == id)
        {
            AddInclude(a => a.Employee);
            AddInclude(a => a.Employee.Department);
        }
    }
}
