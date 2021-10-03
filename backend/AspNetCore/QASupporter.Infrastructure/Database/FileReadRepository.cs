using QASupporter.Application.Configuration.Database;
using QASupporter.Application.CqrsHandlers.ReadModels;
using QASupporter.Domain.Enums;
using QASupporter.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QASupporter.Infrastructure.Database
{
    public class FileReadRepository : DapperRepository, IFileReadRepository
    {
        public FileReadRepository(ISqlConnectionFactory sqlConnectionFactory) : base(sqlConnectionFactory)
        {
        }

        public async Task<IList<BaseFileDto>> GetResizedFileByIdQueryAsync(IEnumerable<long> ids)
        {
            const string sql = @"SELECT Id, OriginalId, OriginalFileName, Width, Height, 
                                        CompanyId, FilePath, ThumbnailPath, Extension, FileType, 
                                        Source, CloudUrl, FileData, CreatedBy, CreatedDate, ModifiedBy, 
                                        ModifiedDate
                               FROM RS_Files
                               WHERE Id in @ids";
            return await QueryAsync<BaseFileDto>(sql, new { ids = ids.ToArray() });
        }

        public async Task<BaseFileDto> GetFileByIdQuery(long id)
        {
            const string sql = @"SELECT Id, OriginalId, OriginalFileName, Width, Height, 
                                        CompanyId, FilePath, ThumbnailPath, Extension, FileType, 
                                        Source, CloudUrl, FileData, CreatedBy, CreatedDate, ModifiedBy, 
                                        ModifiedDate
                               FROM RS_Files
                               WHERE Id = @Id";
            return await QuerySingleOrDefaultAsync<BaseFileDto>(sql, new { id });
        }

        public async Task<IEnumerable<BaseFileDto>> GetAllImageOfIdAsync(long id, int? width, int? height)
        {
            const string sql = @"SELECT Id, OriginalId, OriginalFileName, Width, Height, 
                                        CompanyId, FilePath, ThumbnailPath, Extension, FileType, 
                                        Source, CloudUrl, FileData, CreatedBy, CreatedDate, ModifiedBy, 
                                        ModifiedDate
                               FROM RS_Files
                               WHERE Id = @Id OR
                                        (OriginalId = @Id
                                        AND (@Height IS NULL OR Height = @Height)
                                        AND (@Width IS NULL OR Width = @Width))";

            var fileDtos = await QueryAsync<BaseFileDto>(sql,
                new
                {
                    Id = id,
                    Width = width,
                    Height = height,
                });

            return fileDtos;
        }

        public async Task<IEnumerable<File>> GetAllAvailableImageToPreResize(int minWidth,
            int minHeight,
            IEnumerable<string> supportFiles,
            IEnumerable<string> supportFileTypes,
            BackgroudProcessingStatus status)
        {
            const string query = @"SELECT * FROM Rs_Files f WHERE f.OriginalId IS NULL
                                    AND f.BackgroudProcessingStatus = @BackgroudProcessingStatus
                                    AND f.Width IS NOT NULL
                                    AND f.Height IS NOT NULL
                                    AND (f.Width >= @MinWidth
                                            OR f.Height >= @MinHeight)
                                    AND (f.Extension in (SELECT * FROM STRING_SPLIT(@SupportFiles, ',')))
                                    AND (f.FileType in (SELECT * FROM STRING_SPLIT(@SupportFileTypes, ',')))";

            var rsFiles = await QueryAsync<File>(query,
                new
                {
                    MinWidth = minWidth,
                    MinHeight = minHeight,
                    SupportFiles = string.Join(',', supportFiles),
                    SupportFileTypes = string.Join(',', supportFileTypes),
                    BackgroudProcessingStatus = (int)BackgroudProcessingStatus.PreGeneratorToProcess
                });

            return rsFiles;
        }

        public async Task<IEnumerable<File>> GetAllResizedImageForDeleting(BackgroudProcessingStatus status)
        {
            const string query = @"select f1.* from rs_files f1 join RS_Files f2 on f1.originalid = f2.id
                                    where f1.originalid is not null and f2.BackgroudProcessingStatus = @BackgroudProcessingStatus";

            var rsFiles = await QueryAsync<File>(query,
                new
                {
                    BackgroudProcessingStatus = (int)status
                });

            return rsFiles;
        }
    }
}
