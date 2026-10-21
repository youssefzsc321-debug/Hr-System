using Hr.Application.Interfaces;
using Hr.Application.ViewModels.User;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hr_System.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var (IsSuccess, error) = await _userService.LoginAsync(model);
            if (!IsSuccess)
            {
                ModelState.AddModelError(string.Empty, error);
                return View(model);
            }
            return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            await _userService.LogoutAsync();

            return RedirectToAction("Login", "Account");
        }

    }
}
