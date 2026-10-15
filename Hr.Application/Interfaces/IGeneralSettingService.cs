using Hr.Application.ViewModels.GeneralSettingsVms;
using Hr.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Application.Interfaces
{
    public interface IGeneralSettingService
    {
        Task<GeneralSettings?> GetGeneralSetting();
        Task <(bool Success,string error)>SaveSettingAsync(FormVm model);
    }
}
