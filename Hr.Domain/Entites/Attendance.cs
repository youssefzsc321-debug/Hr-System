using Hr.Domain.Common;
using Hr.Domain.Entites.EmployeeAggragtte;

namespace Hr.Domain.Entites
{
    public class Attendance:BaseEntity
    {
        public DateOnly Date { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public bool IsDeleted { get; set; }
        public TimeOnly CheckIn { get; set; }
        public TimeOnly? CheckOut { get; set; }

    }
}