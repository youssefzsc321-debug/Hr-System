using AutoMapper;
using Hr.Application.Interfaces;
using Hr.Application.Repositories;
using Hr.Application.ViewModels.RolesVms;
using Hr.Domain.Entites;
using Hr.Domain.Enums;
using Hr.Infrastructure.Specifications.RoleSpec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Infrastructure.Services
{
    public class RoleServices : IRoleServices
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkRepo _unitOfWorkRepo;

        public RoleServices(IMapper mapper, IUnitOfWorkRepo unitOfWorkRepo)
        {
            _mapper = mapper;
            _unitOfWorkRepo = unitOfWorkRepo;
        }

        public async Task<(bool IsSuccess, string Message)> CreateRole(RoleFormVm model)
        {
            bool hasPermission = model.Permissions.Any(p => p.CanRead || p.CanAdd || p.CanEdit || p.CanDelete);
            if (!hasPermission)
            {
                return (false, "Please select at least one permission for the group.");
            }
            var role = _mapper.Map<Role>(model);
            role.CreatedOn = DateTime.Now;
            await _unitOfWorkRepo.Roles.AddAsync(role);
            await _unitOfWorkRepo.SaveChangesAsync();
            return (true, null);
        }

        public async Task<(bool IsSuccess, string Message)> EditRole(RoleFormVm model)
        {
            if (model.Permissions == null ||
                !model.Permissions.Any(p =>
                    p.CanRead || p.CanAdd || p.CanEdit || p.CanDelete))
            {
               
                return (false, "Please select at least one permission.");
            }

            var spec = new RoleWithPermisionsSpec(model.Id);
            var role = await _unitOfWorkRepo.Roles.GetByIdWithSpec(spec);

            if (role == null)
            {
               
                return (false, "Role not found.");

            }

            role.Name = model.Name;

            foreach (var permissionVm in model.Permissions)
            {
                var permission = role.Permissions
                    .FirstOrDefault(p => p.PageName == permissionVm.PageName);

                if (permission == null)
                {
                    continue;
                }

                permission.CanAdd = permissionVm.CanAdd;
                permission.CanDelete = permissionVm.CanDelete;
                permission.CanEdit = permissionVm.CanEdit;
                permission.CanRead = permissionVm.CanRead;
            }

            await _unitOfWorkRepo.SaveChangesAsync();

         
            return (true, null!);
        }

        public RoleFormVm InitModel()
        {
            var model = new RoleFormVm();
            foreach (Enum item in Enum.GetValues(typeof(Modules)))
            {
                model.Permissions.Add(new RolePermissionVm
                {
                    PageName = item.GetFormattedEnum(),
                    CanRead = false,
                    CanAdd = false,
                    CanEdit = false,
                    CanDelete = false
                });
            }
            return model;
        }
    }
}
