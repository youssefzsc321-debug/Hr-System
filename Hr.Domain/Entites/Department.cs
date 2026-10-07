using Hr.Domain.Common;
using Hr.Domain.Entites.EmployeeAggragtte;

namespace Hr.Domain.Entites
{
    public class Department:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}