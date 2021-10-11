using QASupporter.Application.Configuration.Database;
using QASupporter.Domain.Models;

namespace QASupporter.Infrastructure.Database
{
    public class UserRepository : EfRepository<DBContext, User, int>, IUserRepository
    {
        public UserRepository(DBContext dbContext) : base(dbContext)
        {
        }
    }
}