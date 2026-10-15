using AutoMapper;
using Hr.Application.Interfaces;
using Hr.Application.Repositories;
using Hr.Application.ViewModels.GeneralSettingsVms;
using Hr.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hr.Infrastructure.Services
{
    public class GeneralSettingService : IGeneralSettingService
    {
        private readonly IUnitOfWorkRepo _unitOfWorkRepo;
        private readonly IMapper _mapper;
        public GeneralSettingService(IUnitOfWorkRepo unitOfWorkRepo, IMapper mapper)
        {
            _unitOfWorkRepo = unitOfWorkRepo;
            _mapper = mapper;
        }
        public async Task<GeneralSettings?> GetGeneralSetting()
        {
            var generalSettings = await _unitOfWorkRepo.GeneralSettings.GetAllAsync();
            return generalSettings.FirstOrDefault();
        }

        public async Task<(bool Success, string error)> SaveSettingAsync(FormVm model)
        {
            if (model.Id == 0)
            {
                var generalSetting = _mapper.Map<GeneralSettings>(model);
                await _unitOfWorkRepo.GeneralSettings.AddAsync(generalSetting);
            }
            else
            {
                var generalSetting = await _unitOfWorkRepo.GeneralSettings.GetByIdAsync(model.Id);
                if (generalSetting == null) return (false, "Not Found!");
                _mapper.Map(model, generalSetting);
                _unitOfWorkRepo.GeneralSettings.Update(generalSetting);
            }
            await _unitOfWorkRepo.SaveChangesAsync();
            return (true, null!);
        }
    }
}
