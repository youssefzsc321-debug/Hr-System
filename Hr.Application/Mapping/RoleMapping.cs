using AutoMapper;
using Hr.Application.ViewModels.RolesVms;
using Hr.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Application.Mapping
{
    public class RoleMapping:Profile
    {
        public RoleMapping()
        {
            CreateMap<RoleFormVm, Role>()
                .ForMember(dest=>dest.Permissions,opt=>opt.MapFrom(src=>src.Permissions))
                .ReverseMap();

            CreateMap<RolePermissionVm, RolePermission>().ReverseMap();
        }
    }

}
