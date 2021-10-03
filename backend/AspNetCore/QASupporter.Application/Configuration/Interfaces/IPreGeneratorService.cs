using QASupporter.Domain.Models;
using System.IO;
using System.Threading.Tasks;

namespace QASupporter.Application.Configuration.Interfaces
{
    public interface IPreGeneratorService
    {
        Task Process();

        Task PreGenerateResizedImages(Domain.Models.File rsFile, Stream stream = null);
    }
}
