using QASupporter.Domain.Models;
using System.IO;

namespace QASupporter.Domain.Helpers
{
    public class FileBuilder
    {
        private Models.File _file;

        public FileBuilder()
        {
            Reset();
        }

        public Models.File Build()
        {
            var file = _file;
            Reset();

            return file;
        }

        public FileBuilder BuildCloudUrl(string cloudUrlBase, string name)
        {
            _file.CloudUrl = PathHelper.CombineUrl(cloudUrlBase, name);
            return this;
        }

        public FileBuilder BuildFilePath(string filePathBase, string name)
        {
            _file.FilePath = Path.Combine(filePathBase, name);
            return this;
        }

        public FileBuilder BuildFileInfo(Models.File file)
        {
            _file.CreatedDate = file.CreatedDate;
            _file.CreatedBy = file.CreatedBy;
            _file.FileType = file.FileType;
            _file.Height = file.Height;
            _file.Width = file.Width;
            _file.OriginalFileName = file.OriginalFileName;
            _file.Source = file.Source;
            _file.OriginalId = file.OriginalId;
            _file.CompanyId = file.CompanyId;
            _file.Extension = file.Extension;
            return this;
        }

        private void Reset()
        {
            _file = new Models.File();
        }
    }
}
