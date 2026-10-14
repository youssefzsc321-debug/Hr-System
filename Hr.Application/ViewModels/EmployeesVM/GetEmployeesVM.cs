using Hr.Domain.Entites;
using Hr.Domain.Entites.EmployeeAggragtte;
using Hr.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Application.ViewModels.EmployeesVM
{
    public class GetEmployeesVM
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public AddressVM Address { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }

        public int NationalityId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string NationalId { get; set; }
        public DateTime ContractDate { get; set; }
        public bool IsDeleted { get; set; }
        public string DepartmentName { get; set; }
        public decimal Salary { get; set; }
        public TimeOnly DefaultCheckIn { get; set; }
        public TimeOnly DefaultCheckOut { get; set; }
    }
}
