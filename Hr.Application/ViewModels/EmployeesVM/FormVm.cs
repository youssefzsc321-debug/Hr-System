using Hr.Domain.Common;
using Hr.Domain.Entites;
using Hr.Domain.Entites.EmployeeAggragtte;
using Hr.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace Hr.Application.ViewModels.EmployeesVM
{
    public class FormVm
    {
        public int Id { get; set; }

        [Required(ErrorMessage = Errors.Required)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = Errors.Required)]
        public AddressVM Address { get; set; } = new AddressVM();

        [Required(ErrorMessage = Errors.Required)]
        [RegularExpression(RegexPatterns.Phone, ErrorMessage = Errors.PhoneRegex)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = Errors.Required)]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = Errors.Required)]
        [Display(Name = "Nationality")]
        public int NationalityId { get; set; }
        public IEnumerable<SelectListItem> Nationalites { get; set; } = new List<SelectListItem>();

        [Required(ErrorMessage = Errors.Required)]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = Errors.Required)]
        [StringLength(14, MinimumLength = 14, ErrorMessage = Errors.MinLengthForNatId)]
        [Display(Name = "National ID")]
        public string NationalId { get; set; } = string.Empty;

        [Required(ErrorMessage = Errors.Required)]
        [DataType(DataType.Date)]
        [Display(Name = "Contract Date")]
        public DateTime ContractDate { get; set; }

        [Required(ErrorMessage = Errors.Required)]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        public IEnumerable<SelectListItem> Departments { get; set; } = new List<SelectListItem>();

        [Required(ErrorMessage = Errors.Required)]
        [RegularExpression(RegexPatterns.SalaryRegex, ErrorMessage = Errors.ValidSalary)]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = Errors.Required)]
        [Display(Name = "Default Check-In")]
        public TimeOnly DefaultCheckIn { get; set; }

        [Required(ErrorMessage = Errors.Required)]
        [Display(Name = "Default Check-Out")]
        public TimeOnly DefaultCheckOut { get; set; }

        

    }
}