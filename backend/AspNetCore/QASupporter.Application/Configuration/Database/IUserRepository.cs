using QASupporter.Domain.Models;
using QASupporter.Domain.SharedKernel;

namespace QASupporter.Application.Configuration.Database
{
    public interface IUserRepository : IRepository<User, int>
    {
    }
}