using Hr.Domain.Entites;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Infrastructure.Specifications.RoleSpec
{
    public class RoleWithPermisionsSpec:BaseSpecification<Role>
    {
        public RoleWithPermisionsSpec()
        {

            AddInclude(x => x.Permissions);
        }
        public RoleWithPermisionsSpec(int id):base(x=>x.Id==id)
        {
            AddInclude(x => x.Permissions);
        }


    }
}
