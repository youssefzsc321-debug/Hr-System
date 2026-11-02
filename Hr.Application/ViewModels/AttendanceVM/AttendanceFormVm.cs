using Hr.Domain.Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Application.ViewModels.AttendanceVM
{
    public class AttendanceFormVm
    {
        public int Id { get; set; }

        [Required(ErrorMessage = Errors.Required)]
        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = Errors.Required)]
        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        [Required(ErrorMessage = Errors.Required)]
        [Display(Name = "Check In Time")]
        public TimeOnly CheckIn { get; set; }

        [Display(Name = "Check Out Time")]
        [Required(ErrorMessage = Errors.Required)]
        public TimeOnly? CheckOut { get; set; }

        public IEnumerable<SelectListItem>? Employees { get; set; }=new List<SelectListItem>();
    }
}
