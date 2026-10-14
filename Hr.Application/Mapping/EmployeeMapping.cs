using AutoMapper;
using Hr.Application.ViewModels.EmployeesVM;
using Hr.Domain.Entites.EmployeeAggragtte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Application.Mapping
{
    public class EmployeeMapping : Profile
    {
        public EmployeeMapping()
        {
            CreateMap<Employee, GetEmployeesVM>();

            CreateMap<FormVm, Employee>()
                .ForMember(dest => dest.Nationality, opt => opt.Ignore()) 
                .ForMember(dest => dest.Department, opt => opt.Ignore())  
                .ReverseMap();

            CreateMap<Address, AddressVM>().ReverseMap();
        }
    }
}
