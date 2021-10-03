using QASupporter.Domain.Models;
using QASupporter.Domain.SharedKernel;
using System.Threading.Tasks;

namespace QASupporter.Application.Configuration.Database
{
    public interface ISettingRepository : IRepository<Setting, int>
    {
        Task<Setting> GetByName(string settingName);
    }
}