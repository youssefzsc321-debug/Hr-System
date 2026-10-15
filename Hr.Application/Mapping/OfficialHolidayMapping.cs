using AutoMapper;
using Hr.Application.ViewModels.OfficialHoliday;
using Hr.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Application.Mapping
{
    public class OfficialHolidayMapping:Profile
    {
        public OfficialHolidayMapping()
        {
            CreateMap<OfficialHolidayFormVm,OfficialHoliday>().ReverseMap();
        }
    }
}
