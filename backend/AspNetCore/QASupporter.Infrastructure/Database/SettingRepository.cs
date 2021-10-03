using QASupporter.Application.Configuration.Database;
using QASupporter.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace QASupporter.Infrastructure.Database
{
    public class SettingRepository : EfRepository<DBContext, Setting, int>, ISettingRepository
    {
        public SettingRepository(DBContext dbContext) : base(dbContext)
        {
        }

        public Task<Setting> GetByName(string settingName)
        {
            settingName = settingName.Trim().ToLower();
            return _dbContext.Settings.FirstOrDefaultAsync(e => e.SettingName.ToLower() == settingName);
        }
    }
}