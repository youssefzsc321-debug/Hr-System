using Hr.Domain.Entites;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Infrastructure.Data
{ 
    public class AppUser: IdentityUser
    {
        public string FullName { get; set; }
        public int? RoleId { get; set; }
        public Role Role { get; set; }
    }
}
