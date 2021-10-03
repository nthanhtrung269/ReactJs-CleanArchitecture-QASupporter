using QASupporter.Application.CqrsHandlers.ReadModels;
using QASupporter.Domain.Enums;
using QASupporter.Domain.Models;
using QASupporter.Domain.SharedKernel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QASupporter.Application.Configuration.Database
{
    public interface IFileReadRepository : IDapperRepository
    {
        Task<IList<BaseFileDto>> GetResizedFileByIdQueryAsync(IEnumerable<long> ids);
        Task<BaseFileDto> GetFileByIdQuery(long id);
        Task<IEnumerable<BaseFileDto>> GetAllImageOfIdAsync(long id, int? width, int? height);
        Task<IEnumerable<File>> GetAllResizedImageForDeleting(BackgroudProcessingStatus status);
        Task<IEnumerable<File>> GetAllAvailableImageToPreResize(int minWidth,
            int minHeight,
            IEnumerable<string> supportFiles,
            IEnumerable<string> supportFileTypes,
            BackgroudProcessingStatus status);
    }
}
