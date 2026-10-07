using Hr.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Domain.Entites
{
    public class RolePermission:BaseEntity
    {
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public string PageName { get; set; }
        public bool CanRead { get; set; }
        public bool CanDelete { get; set; }
        public bool CanAdd { get; set; }
        public bool CanEdit { get; set; }
    }
}
