using QASupporter.Application.Configuration.ApplicationSettings;
using QASupporter.Application.Configuration.Interfaces;
using Microsoft.Extensions.Options;
using System.IO;
using System.Threading;

namespace QASupporter.Application.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageResizerService _imageResizer;
        private readonly QaSupporterSettings _assetSetting;

        public ImageService(IImageResizerService imageResizer, IOptions<QaSupporterSettings> assetSetting)
        {
            _imageResizer = imageResizer;
            _assetSetting = assetSetting.Value;
        }

        public bool CanResize((int? width, int? height) request, (int? width, int? height) original)
        {
            if (request.width != null && request.width > 0 && request.height != null && request.height > 0)
                return (decimal)request.width / request.height == (decimal)original.width / original.height;

            return true;
        }

        public FileStream ReadImage(string path)
        {
            if (File.Exists(path))
            {
                var fs = File.OpenRead(path);
                return fs;
            }

            return null;
        }

        public (int newHeight, int newWidth) ResizeImage(Stream image, (int width, int height) originalRatio, (int? width, int? height) ratio, string fileExtension, FileStream outputStream)
        {
            return _imageResizer.Resize(image, originalRatio, ratio, fileExtension, outputStream);
        }

        /// <summary>
        /// Gets image dimentions.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="fileExtention">The fileExtention.</param>
        /// <param name="cancellationToken">The cancellationToken.</param>
        /// <returns>(int height, int width).</returns>
        public (int height, int width) GetImageDimentions(Stream stream, string fileExtension, CancellationToken cancellationToken)
        {
            return _imageResizer.GetImageDimentionsAsync(stream, fileExtension, cancellationToken);
        }

        public bool ShouldResize((int width, int height) originalRatio, (int? width, int? height) requestRatio)
        {
            return (!requestRatio.width.HasValue || originalRatio.width > requestRatio.width)
                && (!requestRatio.height.HasValue || originalRatio.height > requestRatio.height)
                && (requestRatio.width.HasValue || requestRatio.height.HasValue);
        }
    }
}
