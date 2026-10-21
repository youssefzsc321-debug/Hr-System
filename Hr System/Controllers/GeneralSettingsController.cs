using AutoMapper;
using Hr.Application.Interfaces;
using Hr.Application.Repositories;
using Hr.Application.ViewModels.GeneralSettingsVms;
using Hr.Domain.Entites;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hr_System.Controllers
{
    public class GeneralSettingsController : Controller
    {
        private readonly IGeneralSettingServices _generalSettingService;
        private readonly IUnitOfWorkRepo _unitOfWorkRepo;
        private readonly IMapper _mapper;
        public GeneralSettingsController(IUnitOfWorkRepo unitOfWorkRepo, IMapper mapper, IGeneralSettingServices generalSettingService)
        {
            _unitOfWorkRepo = unitOfWorkRepo;
            _mapper = mapper;
            _generalSettingService = generalSettingService;
        }
        public async Task<IActionResult> Index()
        {
            var generalSettings = await _generalSettingService.GetGeneralSetting();
            if (generalSettings == null)
            {
                return View(new FormVm());
            }
            var modelVm = _mapper.Map<FormVm>(generalSettings);
            return View(modelVm);
        }


        [HttpPost]
        public async Task<IActionResult> Save(FormVm model)
        {
            if (!ModelState.IsValid)
                return View("Index", model);

            var result = await _generalSettingService.SaveSettingAsync(model);

            if (!result.Success)
            {
                return NotFound(result.error);
            }

            TempData["SuccessMessage"] = "General settings saved successfully.";
            return RedirectToAction(nameof(Index));
        }


    }
}
