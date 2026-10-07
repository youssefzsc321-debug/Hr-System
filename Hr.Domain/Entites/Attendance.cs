using Hr.Domain.Common;
using Hr.Domain.Entites.EmployeeAggragtte;

namespace Hr.Domain.Entites
{
    public class Attendance:BaseEntity
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public TimeOnly CheckIn { get; set; }
        public TimeOnly CheckOut { get; set; }

    }
}