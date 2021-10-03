using QASupporter.Application.Configuration.Commands;
using QASupporter.Application.Configuration.Database;
using QASupporter.Application.Configuration.Interfaces;
using QASupporter.Domain.Helpers;
using QASupporter.Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace QASupporter.Application.CqrsHandlers.DeleteFile
{
    public class DeleteFileCommandHandler : ICommandHandler<DeleteFileCommand>
    {
        private readonly IFileRepository _fileRepository;
        private readonly IFileSystemService _fileSystemService;

        public DeleteFileCommandHandler(IFileRepository fileRepository,
            IFileSystemService fileSystemService)
        {
            _fileRepository = fileRepository;
            _fileSystemService = fileSystemService;
        }

        public async Task<Unit> Handle(DeleteFileCommand request, CancellationToken cancellationToken)
        {
            Guard.AgainstNull(nameof(DeleteFileCommand), request);
            File rsFile = await _fileRepository.GetByIdAsync(request.FileId);
            Guard.AgainstNull(nameof(rsFile), rsFile);

            // Deletes file from forder
            _fileSystemService.Delete(rsFile.FilePath);

            await _fileRepository.DeleteAsync(rsFile);
            await _fileRepository.CommitAsync();

            return Unit.Value;
        }
    }
}
