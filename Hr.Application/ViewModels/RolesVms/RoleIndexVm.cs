using Hr.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Application.ViewModels.RolesVms
{
    public class RoleIndexVm
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int PermissionsCount { get; set; }
    }
}
