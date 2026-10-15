using Hr.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Application.ViewModels.OfficialHoliday
{
    public class OfficialHolidayFormVm
    {
        public int Id { get; set; }
        [Required(ErrorMessage =Errors.Required)]
        public string Name { get; set; }
        [Required(ErrorMessage =Errors.Required)]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage =Errors.Required)]
        public DateTime EndDate { get; set; }
    }
}
