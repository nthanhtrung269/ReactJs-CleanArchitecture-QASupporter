using System.Threading.Tasks;

namespace QASupporter.Application.Configuration.Interfaces
{
    public interface ICachingService
    {
        Task<bool> IsLoggingDatabaseAsync();
    }
}
