using QASupporter.Domain.Models;
using QASupporter.Domain.SharedKernel;
using System.Threading.Tasks;

namespace QASupporter.Application.Configuration.Database
{
    public interface IUserRepository : IRepository<User, int>
    {
        Task<User> GetUserByUserNameAsync(string userName);
    }
}