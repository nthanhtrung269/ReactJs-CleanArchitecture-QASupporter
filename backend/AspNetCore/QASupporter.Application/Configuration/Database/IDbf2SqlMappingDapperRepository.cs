using QASupporter.Application.CqrsHandlers.ReadModels;
using QASupporter.Domain.SharedKernel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QASupporter.Application.Configuration.Database
{
    public interface IDbf2SqlMappingDapperRepository : IDapperRepository
    {
        Task<IList<BaseDbf2SqlMappingDto>> GetAllDbf2SqlMappingByKeywordAsync(string keyword, string modifiedBy);
        Task<BaseDbf2SqlMappingDto> GetDbf2SqlMappingByIdAsync(int id);
    }
}
