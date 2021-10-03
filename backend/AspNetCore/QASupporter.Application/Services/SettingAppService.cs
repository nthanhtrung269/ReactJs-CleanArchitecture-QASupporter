using QASupporter.Application.Configuration.Database;
using QASupporter.Application.Configuration.Interfaces;
using QASupporter.Application.Settings;
using QASupporter.Domain.Models;
using Mapster;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QASupporter.Application.Services
{
    public class SettingAppService : ISettingAppService
    {
        private readonly ISettingRepository _settingRepository;

        public SettingAppService(ISettingRepository settingRepository)
        {
            _settingRepository = settingRepository;
        }

        public async Task<SettingDto> GetSettingAsync(int id)
        {
            Setting rsSetting = await _settingRepository.GetByIdAsync(id);
            return rsSetting.Adapt<SettingDto>();
        }

        public async Task<string> GetSettingValueByNameAsync(string name)
        {
            Setting rsSetting = await _settingRepository.GetByName(name);

            if (rsSetting != null)
            {
                return rsSetting.SettingValue;
            }

            return null;
        }

        public async Task<IList<SettingDto>> GetAllAsync()
        {
            List<Setting> rsSetting = await _settingRepository.ListAsync();
            if (rsSetting != null)
            {
                return rsSetting.Adapt<IList<SettingDto>>();
            }

            return null;
        }
    }
}