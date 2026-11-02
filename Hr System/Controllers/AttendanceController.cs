using AutoMapper;
using Hr.Application.Interfaces;
using Hr.Application.Repositories;
using Hr.Application.ViewModels.AttendanceVM;
using Hr.Infrastructure.Specifications.AttendanceSpec;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hr_System.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly IUnitOfWorkRepo _unitOfWorkRepo;
        private readonly IMapper _mapper;
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IUnitOfWorkRepo unitOfWorkRepo, IMapper mapper, IAttendanceService attendanceService)
        {
            _unitOfWorkRepo = unitOfWorkRepo;
            _mapper = mapper;
            _attendanceService = attendanceService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string? searchTerm, DateOnly? fromDate, DateOnly? toDate)
        {
            if (fromDate.HasValue && toDate.HasValue && fromDate > toDate)
            {
                ModelState.AddModelError("fromDate", "From Date cannot be greater than To Date.");
            }
            if (!ModelState.IsValid)
            {
                var errorModel = await _attendanceService.GetAttendanceListAsync(searchTerm, fromDate, toDate);
                return View(errorModel);
            }
            var modelvm = await _attendanceService.GetAttendanceListAsync(searchTerm, fromDate, toDate);

            return View(modelvm);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var modelVm = await _attendanceService.FillModel();
            return View("Form", modelVm);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(AttendanceFormVm model)
        {
            if (model.CheckOut.HasValue && model.CheckOut.HasValue && model.CheckOut <= model.CheckIn)
            {
                ModelState.AddModelError(nameof(model.CheckOut), "Check-out time must be after check-in time.");
            }
            if (!ModelState.IsValid)
            {
                model = await _attendanceService.FillModel(model);
                return View("Form", model);
            }
            var isCreated = await _attendanceService.CreateAttendanceAsync(model);
            if (isCreated)
            {
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError(string.Empty, "An error occurred while saving the attendance record.");
            model = await _attendanceService.FillModel(model);
            return View("Form", model);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var attendace = await _unitOfWorkRepo.Attendances.GetByIdAsync(id);
            if (attendace == null) return NotFound();
            var model = _mapper.Map<AttendanceFormVm>(attendace);
            model = await _attendanceService.FillModel(model);
            return View("Form", model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AttendanceFormVm model)
        {
            if (model.CheckOut.HasValue && model.CheckOut.HasValue && model.CheckOut <= model.CheckIn)
            {
                ModelState.AddModelError(nameof(model.CheckOut), "Check-out time must be after check-in time.");
            }
            if (!ModelState.IsValid)
            {
                model = await _attendanceService.FillModel(model);
                return View("Form", model);
            }
            var isUpdated = await _attendanceService.UpdateAttendanceAsync(model);
            if (!isUpdated)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _attendanceService.DeleteAttendanceAsync(id);

            if (!isDeleted)
            {
                TempData["ErrorMessage"] = "Failed to delete the attendance record, or it no longer exists.";
                return RedirectToAction(nameof(Index));
            }

            TempData["SuccessMessage"] = "Attendance record deleted successfully.";
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ImportExcel(IFormFile excelFile)
        {
            try
            {
                var success = await _attendanceService.ImportAttendanceFromExcelAsync(excelFile);

                if (!success)
                {
                    TempData["ErrorMessage"] = "Please select a valid Excel file.";
                    return RedirectToAction(nameof(Index));
                }

                TempData["SuccessMessage"] = "Attendance records imported successfully from Excel.";
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Error reading the Excel file. Ensure columns are ordered: EmployeeId, Date, CheckIn, CheckOut.";
            }

            return RedirectToAction(nameof(Index));
        }


    }
}
