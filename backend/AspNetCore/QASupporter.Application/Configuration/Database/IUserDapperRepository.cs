using QASupporter.Application.CqrsHandlers.ReadModels;
using QASupporter.Domain.SharedKernel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QASupporter.Application.Configuration.Database
{
    public interface IUserDapperRepository : IDapperRepository
    {
        Task<IList<BaseUserDto>> GetAllUsersAsync();
        Task<BaseUserDto> GetUserByUserNameAsync(string userName);
    }
}
