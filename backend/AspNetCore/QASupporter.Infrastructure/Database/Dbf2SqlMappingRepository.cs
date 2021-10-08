using QASupporter.Application.Configuration.Database;
using QASupporter.Domain.Models;

namespace QASupporter.Infrastructure.Database
{
    public class Dbf2SqlMappingRepository : EfRepository<DBContext, Dbf2SqlMapping, int>, IDbf2SqlMappingRepository
    {
        public Dbf2SqlMappingRepository(DBContext dbContext) : base(dbContext)
        {
        }
    }
}