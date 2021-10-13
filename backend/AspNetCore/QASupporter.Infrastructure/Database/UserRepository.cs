using Microsoft.EntityFrameworkCore;
using QASupporter.Application.Configuration.Database;
using QASupporter.Domain.Models;
using System.Threading.Tasks;

namespace QASupporter.Infrastructure.Database
{
    public class UserRepository : EfRepository<DBContext, User, int>, IUserRepository
    {
        public UserRepository(DBContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> GetUserByUserNameAsync(string userName)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == userName);
        }
    }
}