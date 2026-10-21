using Hr.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Application.ViewModels.User
{
    public class LoginVm
    {
        [Required(ErrorMessage =Errors.Required)]
        public string EmailOrUserName { get; set; }
        [Required(ErrorMessage =Errors.Required)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

    }


}
