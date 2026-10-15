using Hr.Domain.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Application.ViewModels.GeneralSettingsVms
{
    public class FormVm
    {
        public int Id { get; set; }
        [Required(ErrorMessage =Errors.Required)]
        public decimal OverTimeVal { get; set; }
        [Required(ErrorMessage =Errors.Required)]
        public decimal DeducationVal { get; set; }
        [Required(ErrorMessage =Errors.Required)]
        public string FirstDay { get; set; }
        [Required(ErrorMessage =Errors.Required)]
        public string SecondDay { get; set; }


    }
}
