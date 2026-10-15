using AutoMapper;
using Hr.Application.Interfaces;
using Hr.Application.Repositories;
using Hr.Application.ViewModels.OfficialHoliday;
using Hr.Domain.Entites;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hr_System.Controllers
{
    public class OfficialHolidaysController : Controller
    {
        private readonly IUnitOfWorkRepo _unitOfWorkRepo;
        private readonly IMapper _mapper;

        public OfficialHolidaysController(IUnitOfWorkRepo unitOfWorkRepo, IMapper mapper)
        {
            _unitOfWorkRepo = unitOfWorkRepo;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var officialHolidays = await _unitOfWorkRepo.OfficialHolidays.GetAllAsync();
            if (officialHolidays == null || !officialHolidays.Any()) return View(new List<OfficialHolidayFormVm>());
            var modelVm = _mapper.Map<IEnumerable<OfficialHolidayFormVm>>(officialHolidays);
            return View(modelVm);
        }

        [HttpPost]
        public async Task<IActionResult> AddHolidayAjax(OfficialHolidayFormVm model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Please fill in all required fields correctly." });
            }

            var holiday = _mapper.Map<OfficialHoliday>(model);
            holiday.CreatedOn= DateTime.Now;
            await _unitOfWorkRepo.OfficialHolidays.AddAsync(holiday);
            await _unitOfWorkRepo.SaveChangesAsync();

            return Json(new
            {
                success = true,
                data = new
                {
                    id = holiday.Id,
                    name = holiday.Name,
                    startDate = holiday.StartDate,
                    endDate = holiday.EndDate
                }
            });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var holiday = await _unitOfWorkRepo.OfficialHolidays.GetByIdAsync(id);
            if (holiday == null) return NotFound();
            var modelVm = _mapper.Map<OfficialHolidayFormVm>(holiday);
            return PartialView("_EditHolidayPartial", modelVm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(OfficialHolidayFormVm model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Please fill in all required fields correctly." });
            }

            var holiday = await _unitOfWorkRepo.OfficialHolidays.GetByIdAsync(model.Id);
            if (holiday == null)
            {
                return Json(new { success = false, message = "Holiday not found!" });
            }

            holiday = _mapper.Map(model, holiday);
            holiday.LastUpdatedOn = DateTime.Now;

            _unitOfWorkRepo.OfficialHolidays.Update(holiday);
            await _unitOfWorkRepo.SaveChangesAsync();

            return Json(new { success = true });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var holiday = await _unitOfWorkRepo.OfficialHolidays.GetByIdAsync(id);
            if(holiday == null) return NotFound();
            _unitOfWorkRepo.OfficialHolidays.Delete(holiday);
            await _unitOfWorkRepo.SaveChangesAsync();
            return Json(new { success = true }); 
        }


    }
}
