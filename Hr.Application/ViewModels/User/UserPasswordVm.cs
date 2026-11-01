using Hr.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Application.ViewModels.User
{
    public class UserPasswordVm
    {
        public string Id { get; set; } 

        [Display(Name = "New Password")]
        [Required(ErrorMessage = Errors.Required)]
        [DataType(DataType.Password)]
        [RegularExpression(RegexPatterns.Password, ErrorMessage = Errors.WeakPassword)]
        public string Password { get; set; } 

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = Errors.Required)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = Errors.ConfirmPasswordNotMatch)]
        public string ConfirmPassword { get; set; } 
    }
}
