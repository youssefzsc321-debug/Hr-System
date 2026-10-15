using AutoMapper;
using Hr.Application.ViewModels.GeneralSettingsVms;
using Hr.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Application.Mapping
{
    public class GeneralSettingMapping:Profile
    {
        public GeneralSettingMapping()
        {
            CreateMap<GeneralSettings, GetGeneralSettingsVM>();
            CreateMap<FormVm, GeneralSettings>().ReverseMap();
        }
    }
}
