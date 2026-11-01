using AutoMapper;
using Hr.Application.Interfaces;
using Hr.Application.Repositories;
using Hr.Application.ViewModels.User;
using Hr.Infrastructure.Data;
using Hr.Infrastructure.Specifications.RoleSpec;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Hr_System.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWorkRepo _unitOfWorkRepo;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public UserController(UserManager<AppUser> userManager, IMapper mapper, IUnitOfWorkRepo unitOfWorkRepo, IUserService userService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _unitOfWorkRepo = unitOfWorkRepo;
            _userService = userService;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var modelVm = _mapper.Map<IEnumerable<UserVm>>(users);
            return View(modelVm);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = await _userService.FillModel();
            return View("Form", model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserFormVm model)
        {
            if (!ModelState.IsValid)
            {
                model = await _userService.FillModel(model);
                return View("Form", model);
            }
            var (IsSuccess, errors) = await _userService.CreateUserAsync(model);
            if (IsSuccess)
            {
                return RedirectToAction(nameof(Index));
            }
            foreach (var error in errors)
            {
                ModelState.AddModelError(string.Empty, error);
            }

            model = await _userService.FillModel(model);

            return View("Form", model);

        }


        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var userVm = await _userService.GetEditUserFormAsync(id);
            if (userVm == null) return NotFound();
            return View("Form", userVm);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UserFormVm model)
        {
            ModelState.Remove(nameof(model.Password));
            ModelState.Remove(nameof(model.ConfirmPassword));
            if (!ModelState.IsValid)
            {
                model = await _userService.FillModel(model);
                return View("Form", model);
            }

            var (succeeded, errors) = await _userService.UpdateUserAsync(model);

            if (succeeded)
            {
                return RedirectToAction(nameof(Index));
            }

            foreach (var error in errors)
            {
                ModelState.AddModelError(string.Empty, error);
            }

            model = await _userService.FillModel(model);
            return View("Form", model);
        }

        [HttpPost]
        public async Task<IActionResult> ToggleStatus(string id)
        {
            var user=await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            user.IsDeleted=!user.IsDeleted;
            user.LastUpdatedOn= DateTime.UtcNow;
            await _userManager.UpdateAsync(user);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> ChangePassword(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if(user == null) return NotFound();
            var modelVm=new UserPasswordVm() { Id = id };
            return View(modelVm);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(UserPasswordVm model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var (IsSuccess,errors)=await _userService.ChangePasswordAsync(model);
            if(IsSuccess)
            {
                 
                return RedirectToAction(nameof(Index));
            }
            foreach(var error in errors)
            {
                ModelState.AddModelError(string.Empty, error);
            }
            return View(model);
        }






    }
}
