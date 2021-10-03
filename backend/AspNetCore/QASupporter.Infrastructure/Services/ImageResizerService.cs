using QASupporter.Application.Configuration.Interfaces;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;

namespace QASupporter.Infrastructure.Services
{
    public class ImageResizerService : IImageResizerService
    {
        /// <summary>
        /// Resizes the image.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="ratio">The ratio.</param>
        /// <param name="fileExtension">The fileExtension.</param>
        /// <param name="outputStream">The outputStream.</param>
        /// <returns>Task{(int newHeight, int newWidth)}.</returns>
        public (int newWidth, int newHeight) Resize(Stream stream, (int width, int height) originalRatio, (int? width, int? height) resizeRatio, string fileExtension, Stream outputStream)
        {
            int widthToResize = (resizeRatio.width.HasValue && resizeRatio.width > 0) ? resizeRatio.width.Value : (int)Math.Floor((decimal)originalRatio.width * resizeRatio.height.Value / originalRatio.height);
            int heightToResize = (resizeRatio.height.HasValue && resizeRatio.height > 0) ? resizeRatio.height.Value : (int)Math.Floor((decimal)originalRatio.height * resizeRatio.width.Value / originalRatio.width);
        
            using(Image image = Image.FromStream(stream))
            {
                var resizedImage = ResizeImage(image, widthToResize, heightToResize);

                resizedImage.Save(outputStream, image.RawFormat);

                return (widthToResize, heightToResize);
            }
        }

        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        private Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        /// <summary>
        /// Gets image dimentions.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="fileExtention">The fileExtention.</param>
        /// <param name="cancellationToken">The cancellationToken.</param>
        /// <returns>(int height, int width).</returns>
        public (int height, int width) GetImageDimentionsAsync(Stream stream, string fileExtention, CancellationToken cancellationToken)
        {
            using (var image = System.Drawing.Image.FromStream(stream))
            {
                return (image.Size.Height, image.Size.Width);
            }
        }
    }
}
