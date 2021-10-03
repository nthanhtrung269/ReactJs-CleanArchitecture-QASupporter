using System.IO;
using System.Threading;

namespace QASupporter.Application.Configuration.Interfaces
{
    public interface IImageResizerService
    {
        (int newWidth, int newHeight) Resize(Stream stream, (int width, int height) originalRatio, (int? width, int? height) resizeRatio, string fileExtension, Stream outputStream);
        (int height, int width) GetImageDimentionsAsync(Stream stream, string fileExtention, CancellationToken cancellationToken);
    }
}
