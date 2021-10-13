using QASupporter.Application.Configuration.Database;
using QASupporter.Application.CqrsHandlers.ReadModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QASupporter.Infrastructure.Database
{
    public class UserDapperRepository : DapperRepository, IUserDapperRepository
    {
        public UserDapperRepository(ISqlConnectionFactory sqlConnectionFactory) : base(sqlConnectionFactory)
        {
        }

        public async Task<IList<BaseUserDto>> GetAllUsersAsync()
        {
            const string sql = @"SELECT * FROM Users order by UserName";
            return await QueryAsync<BaseUserDto>(sql);
        }

        public async Task<BaseUserDto> GetUserByUserNameAsync(string userName)
        {
            const string sql = @"SELECT * FROM Users where UserName=@userName";
            return await QuerySingleOrDefaultAsync<BaseUserDto>(sql, new { userName });
        }
    }
}
