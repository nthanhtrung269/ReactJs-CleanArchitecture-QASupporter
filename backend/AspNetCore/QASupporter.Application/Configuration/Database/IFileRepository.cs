using QASupporter.Domain.Models;
using QASupporter.Domain.SharedKernel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QASupporter.Application.Configuration.Database
{
    public interface IFileRepository : IRepository<File, long>
    {
        Task<bool> DeleteFiles(List<File> files);
        IEnumerable<File> GetFiles(long[] ids, int? width, int? height);
        IEnumerable<File> GetFiles(long id, int? width, int? height);
        IEnumerable<File> GetFilesForBackgroudProcessing(List<string> supportFiles, List<string> supportedCategoryTypes, int numberItems);
        void UpdateRangeForBackgroudProcessing(List<File> rsFiles, int backgroudProcessingStatus);
    }
}