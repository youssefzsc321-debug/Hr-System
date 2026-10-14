using AutoMapper;
using Hr.Application.Interfaces;
using Hr.Application.Repositories;
using Hr.Application.ViewModels.EmployeesVM;
using Hr.Domain.Entites.EmployeeAggragtte;
using Hr.Infrastructure.Specifications.EmployeesSpec;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Abstractions;
using System.Linq;
using System.Threading.Tasks;

namespace Hr_System.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWorkRepo _unitOfWorkRepo;
        private readonly IMapper _mapper;
        private IEmployeeService _employeeService;
        public EmployeeController(IUnitOfWorkRepo unitOfWorkRepo, IMapper mapper, IEmployeeService employeeService)
        {
            _unitOfWorkRepo = unitOfWorkRepo;
            _mapper = mapper;
            _employeeService = employeeService;
        }
        public async Task<IActionResult> Index()
        {
            var spec = new EmployeesWithDepartmetnSpec(new EmployeeSepcParams());

            var employees = await _unitOfWorkRepo.Employees.GetAllAsyncWithSpec(spec);
            var employeesVm = _mapper.Map<IEnumerable<GetEmployeesVM>>(employees);
            return View(employeesVm);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var modelVm = await _employeeService.PrepareFormVmAsync();
            return View("Form", modelVm);
        }


        [HttpPost]
        public async Task<IActionResult> Create(FormVm model)
        {
            var(IsSuccess,errors)=await _employeeService.CreateEmployeeAsync(model);
            if(!IsSuccess)
            {
                foreach(var error in errors)
                    ModelState.AddModelError(error.Key,error.Value);

                model = await _employeeService.PrepareFormVmAsync(model);
                return View("Form", model);
            }
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var spec = new EmployeesWithDepartmetnSpec(id);

            var employee = await _unitOfWorkRepo.Employees.GetByIdWithSpec(spec);
            if (employee == null) return NotFound();
            var modelVm = _mapper.Map<FormVm>(employee);
            modelVm = await _employeeService.PrepareFormVmAsync(modelVm);
            return View("Form", modelVm);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(FormVm model)
        {
            var (isSuccess, errors) = await _employeeService.UpdateEmployeeAsync(model);
            if (!isSuccess)
            {
                if (errors != null && errors.ContainsKey("404"))
                {
                    return NotFound("Employee not found!");
                }
                if(errors !=null)
                {
                    foreach (var error in errors)
                        ModelState.AddModelError(error.Key, error.Value);
                }


                await _employeeService.PrepareFormVmAsync(model);
                return View("Form",model);
            }
           
            return RedirectToAction(nameof(Index));
            
        }

        [HttpPost]
        public async Task<IActionResult> ToggleStatus(int id)
        {
            var isToggeld =await _employeeService.ToggleStatusAsync(id);
            if(!isToggeld) return NotFound("Employee not found!");
            return RedirectToAction(nameof(Index));
        }

       



    }
}
