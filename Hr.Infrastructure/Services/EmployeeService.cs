using AutoMapper;
using Hr.Application.Interfaces;
using Hr.Application.Repositories;
using Hr.Application.ViewModels.EmployeesVM;
using Hr.Domain.Common;
using Hr.Domain.Entites.EmployeeAggragtte;
using Hr.Infrastructure.Specifications.EmployeesSpec;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Hr.Infrastructure.Services
{
    public class EmployeeService : IEmployeeServices
    {
        private readonly IUnitOfWorkRepo _unitOfWorkRepo;
        private readonly IMapper _mapper;
        public EmployeeService(IUnitOfWorkRepo unitOfWorkRepo, IMapper mapper)
        {
            _unitOfWorkRepo = unitOfWorkRepo;
            _mapper = mapper;
        }
        public async Task<(bool IsSuccess, Dictionary<string, string> FillErrors)> CreateEmployeeAsync(FormVm model)
        {
            var fillErrors=new Dictionary<string, string>();
            var age = DateTime.Today.Year - model.DateOfBirth.Year;
            if (model.DateOfBirth.Date > DateTime.Today.AddYears(-age)) age--;
            if (age < 20)
            {
                fillErrors.Add(nameof(model.DateOfBirth), "Employee age must not be less than 20 years.");
            }
            if (model.ContractDate.Year < 2008)
            {
                fillErrors.Add(nameof(model.ContractDate), "Please enter a valid contract date (Company started in 2008).");
            }

            if (fillErrors.Count > 0) return (false, fillErrors);

            var employee = _mapper.Map<Employee>(model);
            employee.CreatedOn = DateTime.Now;
            await _unitOfWorkRepo.Employees.AddAsync(employee);
            await _unitOfWorkRepo.SaveChangesAsync();
            return (true, null);
        }

        public async Task<FormVm> PrepareFormVmAsync(FormVm model = null)
        {
            var modelVm = model ?? new FormVm();
            var depts = await _unitOfWorkRepo.Departments.GetAllAsync();
            var natios = await _unitOfWorkRepo.Nationalites.GetAllAsync();
            modelVm.Departments = depts.Select(d => new SelectListItem { Text = d.Name, Value = d.Id.ToString() }).ToList();
            modelVm.Nationalites = natios.Select(n => new SelectListItem { Text = n.Name, Value = n.Id.ToString() }).ToList();
            return modelVm;
        }

        public async Task<bool> ToggleStatusAsync(int id)
        {
            var employee=await _unitOfWorkRepo.Employees.GetByIdAsync(id);
            if (employee == null) return false;
            employee.IsDeleted=!employee.IsDeleted;
            employee.LastUpdatedOn= DateTime.Now;
            _unitOfWorkRepo.Employees.Update(employee);
            await _unitOfWorkRepo.SaveChangesAsync();
            return true;
        }

        public async Task<(bool IsSuccess, Dictionary<string, string> FillErrors)> UpdateEmployeeAsync(FormVm model)
        {
            var fillErrors=new Dictionary<string, string>();    
            var age = DateTime.Today.Year - model.DateOfBirth.Year;
            if (model.DateOfBirth.Date > DateTime.Today.AddYears(-age)) age--;
            if (age < 20)
            {
                fillErrors.Add(nameof(model.DateOfBirth), "Employee age must not be less than 20 years.");
            }
            if (model.ContractDate.Year < 2008)
            {
                fillErrors.Add(nameof(model.ContractDate), "Please enter a valid contract date (Company started in 2008).");
            }
            if(fillErrors.Count>0)return (false, fillErrors);
            var spec = new EmployeesWithDepartmetnSpec(model.Id);
            var employee = await _unitOfWorkRepo.Employees.GetByIdWithSpec(spec);
            if (employee == null)
            {
                var dic = new Dictionary<string, string> { { "404", "Employee not found!" } };
                return (false, dic);
            }
            employee = _mapper.Map(model, employee);
            employee.LastUpdatedOn = DateTime.Today;
            _unitOfWorkRepo.Employees.Update(employee);
            await _unitOfWorkRepo.SaveChangesAsync();
            return (true, null);
        }
    }
}
