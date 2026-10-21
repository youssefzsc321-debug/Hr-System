using Hr.Domain.Common;
using Hr.Domain.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Application.ViewModels.RolesVms
{
    public class RoleFormVm
    {
        public int Id { get; set; }
        [Required(ErrorMessage =Errors.Required)]

        public string Name { get; set; }

        
        public List<RolePermissionVm> Permissions { get; set; } = new List<RolePermissionVm>();
        
    }
}
