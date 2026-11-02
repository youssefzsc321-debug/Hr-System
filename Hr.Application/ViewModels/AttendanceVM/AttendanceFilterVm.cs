using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Application.ViewModels.AttendanceVM
{
    public class AttendanceFilterVm
    {
       
        public string? SearchTerm { get; set; }

        public DateOnly? FromDate { get; set; }

        public DateOnly? ToDate { get; set; }

        public IEnumerable<AttendanceVm> Attendances { get; set; } = new List<AttendanceVm>();
    }
}
