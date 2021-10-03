using QASupporter.Application.Configuration.Database;
using QASupporter.Application.CqrsHandlers.ReadModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QASupporter.Infrastructure.Database
{
    public class Dbf2SqlMappingDapperRepository : DapperRepository, IDbf2SqlMappingDapperRepository
    {
        public Dbf2SqlMappingDapperRepository(ISqlConnectionFactory sqlConnectionFactory) : base(sqlConnectionFactory)
        {
        }

        public async Task<IList<BaseDbf2SqlMappingDto>> GetAllDbf2SqlMappingByKeywordAsync(string keyword, string modifiedBy)
        {
            const string sql = @"SELECT *
                               FROM Dbf2SqlMapping
                               WHERE (@modifiedBy='' or modifiedBy=@modifiedBy) and (FoxproTable like concat('%', @keyword, '%') 
                                    or FoxproColumn like concat('%', @keyword, '%') 
                                    or SqlTable like concat('%', @keyword, '%') 
                                    or SqlColumn like concat('%', @keyword, '%')
                                    or Notes like concat('%', @keyword, '%'))";
            return await QueryAsync<BaseDbf2SqlMappingDto>(sql, new { keyword = keyword, modifiedBy=modifiedBy });
        }
    }
}
