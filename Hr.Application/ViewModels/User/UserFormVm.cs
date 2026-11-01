using Hr.Domain.Common;
using Hr.Domain.Entites;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Application.ViewModels.User
{
    public class UserFormVm
    {
        public string? Id { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage =Errors.Required)]
        public string FullName { get; set; }

        [Display(Name = "User Name")]
        [Required(ErrorMessage =Errors.Required)]
        public string UserName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = Errors.Required)]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Required(ErrorMessage = Errors.Required)]
        [RegularExpression(RegexPatterns.Password, ErrorMessage = Errors.WeakPassword)]
        public string? Password { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = Errors.Required)]
        [Compare("Password", ErrorMessage = Errors.ConfirmPasswordNotMatch)]
        public string? ConfirmPassword { get; set; }

        [Display(Name = "Roles")]
        [Required(ErrorMessage = Errors.Required)]
        public ICollection<int> SelectedRoles { get; set; } = new List<int>();
        public ICollection<SelectListItem>? Roles { get; set; }=new List<SelectListItem>();

    }
}
