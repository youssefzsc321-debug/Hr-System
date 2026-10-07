using Hr.Domain.Common;
using Hr.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Domain.Entites.EmployeeAggragtte
{
    public class Employee:BaseEntity
    {
        public string FullName { get; set; }
        public Address Address { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }

        public int NationalityId { get; set; }
        public Nationality Nationality { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string NationalId { get; set; }
        public DateTime ContractDate { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public decimal Salary { get; set; }
        public TimeOnly DefaultCheckIn { get; set; }   
        public TimeOnly DefaultCheckOut { get; set; }


        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
    }
}
