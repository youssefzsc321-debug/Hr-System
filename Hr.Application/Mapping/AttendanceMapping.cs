using AutoMapper;
using Hr.Application.ViewModels.AttendanceVM;
using Hr.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Application.Mapping
{
    public class AttendanceMapping:Profile
    {
        public AttendanceMapping()
        {
            CreateMap<Attendance, AttendanceVm>()
                .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.Employee != null ? src.Employee.FullName : string.Empty))
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Employee != null && src.Employee.Department != null ? src.Employee.Department.Name : string.Empty));

            CreateMap<AttendanceFormVm, Attendance>().ReverseMap();

        }
    }
}
