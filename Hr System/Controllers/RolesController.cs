using AutoMapper;
using Hr.Application.Interfaces;
using Hr.Application.Repositories;
using Hr.Application.ViewModels.RolesVms;
using Hr.Domain.Entites;
using Hr.Domain.Enums;
using Hr.Infrastructure.Specifications.RoleSpec;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hr_System.Controllers
{
    public class RolesController : Controller
    {
        private readonly IUnitOfWorkRepo _unitOfWorkRepo;
        private readonly IMapper _mapper;
        private readonly IRoleServices _roleServices;
        public RolesController(IUnitOfWorkRepo unitOfWorkRepo, IMapper mapper, IRoleServices roleServices)
        {
            _unitOfWorkRepo = unitOfWorkRepo;
            _mapper = mapper;
            _roleServices = roleServices;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var spec = new RoleWithPermisionsSpec();

            var roles = await _unitOfWorkRepo.Roles.GetAllAsyncWithSpec(spec);
            var model = roles.Select(r => new RoleIndexVm
            {
                Id = r.Id,
                Name = r.Name,
                PermissionsCount = r.Permissions != null ? r.Permissions.Count(p => p.CanRead || p.CanAdd || p.CanEdit || p.CanDelete) : 0
            }).ToList();

            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = _roleServices.InitModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleFormVm model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Please enter the group name." });
            }

            var (IsSuccess, Error) = await _roleServices.CreateRole(model);
            if(!IsSuccess)return Json(new { success = false, message = Error });
            return Json(new { success = true });
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var spec = new RoleWithPermisionsSpec(id);
            var role = await _unitOfWorkRepo.Roles.GetByIdWithSpec(spec);
            if (role == null) return NotFound();
            var model = _mapper.Map<RoleFormVm>(role);
            return View(nameof(Create), model);
        }



        [HttpPost]
        public async Task<IActionResult> Edit(RoleFormVm model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    success = false,
                    message = "Please enter a valid group name."
                });
            }

            var (IsSuccess, message) = await _roleServices.EditRole(model);

            if (!IsSuccess)
            {
                return Json(new { success = false, message = message });
            }

            return Json(new { success = true });
        }

    }
}
