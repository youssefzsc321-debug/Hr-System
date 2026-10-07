using Hr.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Domain.Entites
{
    public class Role:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<RolePermission> Permissions { get; set; } = new List<RolePermission>();
    }
}
