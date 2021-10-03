using QASupporter.Application.Configuration.Database;
using QASupporter.Domain.Enums;
using QASupporter.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QASupporter.Infrastructure.Database
{
    public class FileRepository : EfRepository<DBContext, File, long>, IFileRepository
    {
        public FileRepository(DBContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> DeleteFiles(List<File> files)
        {
            _dbContext.Files.RemoveRange(files);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public IEnumerable<File> GetFiles(long[] ids, int? width, int? height)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<File> GetFiles(long id, int? width, int? height)
        {
            return _dbContext.Files.Where(file => (file.Id == id)
                || ((width == null || file.Width == width.Value)
                    && (height == null || file.Height == height.Value)
                    && (file.OriginalId == id))).ToList();
        }

        public IEnumerable<File> GetFilesForBackgroudProcessing(List<string> supportFiles, List<string> supportedCategoryTypes, int numberItems)
        {
            List<File> rsFiles = _dbContext.Files
                .Where(f => supportFiles.Contains(f.Extension)
                            && supportedCategoryTypes.Contains(f.FileType)
                            && f.OriginalId == null
                            && (f.BackgroudProcessingStatus == (int)BackgroudProcessingStatus.Failed))
                .OrderByDescending(f => f.Id)
                .Take(numberItems).ToList();

            if (rsFiles == null || !rsFiles.Any())
            {
                rsFiles = _dbContext.Files
                .Where(f => supportFiles.Contains(f.Extension)
                            && supportedCategoryTypes.Contains(f.FileType)
                            && f.OriginalId == null
                            && f.BackgroudProcessingStatus == 1
                            && f.CreatedDate != null
                            && f.CreatedDate.Value.AddMinutes(10) <= DateTime.UtcNow)
                .OrderByDescending(f => f.Id)
                .Take(numberItems).ToList();
            }

            foreach (var rsFile in rsFiles)
            {
                rsFile.BackgroudProcessingStatus = (int)BackgroudProcessingStatus.IsProcessing;
            }

            _dbContext.UpdateRange(rsFiles);
            _dbContext.SaveChanges();

            return rsFiles;
        }

        public void UpdateRangeForBackgroudProcessing(List<File> rsFiles, int backgroudProcessingStatus)
        {
            foreach (var rsFile in rsFiles)
            {
                rsFile.BackgroudProcessingStatus = backgroudProcessingStatus;
            }

            _dbContext.UpdateRange(rsFiles);
            _dbContext.SaveChanges();
        }
    }
}