using Hr.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Domain.Entites.EmployeeAggragtte
{
    public class Nationality:BaseEntity
    {
        
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
