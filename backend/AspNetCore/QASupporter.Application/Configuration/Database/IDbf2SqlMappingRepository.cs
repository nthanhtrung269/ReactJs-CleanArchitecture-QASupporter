using QASupporter.Domain.Models;
using QASupporter.Domain.SharedKernel;

namespace QASupporter.Application.Configuration.Database
{
    public interface IDbf2SqlMappingRepository : IRepository<Dbf2SqlMapping, int>
    {
    }
}