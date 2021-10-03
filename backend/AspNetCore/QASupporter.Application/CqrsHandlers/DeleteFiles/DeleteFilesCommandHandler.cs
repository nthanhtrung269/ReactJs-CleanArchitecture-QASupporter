using QASupporter.Application.Configuration.Commands;
using QASupporter.Application.Configuration.Database;
using QASupporter.Application.Configuration.Interfaces;
using QASupporter.Domain.Helpers;
using QASupporter.Domain.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace QASupporter.Application.CqrsHandlers.DeleteFiles
{
    public class DeleteFilesCommandHandler : ICommandHandler<DeleteFilesCommand>
    {
        private readonly IFileRepository _fileRepository;
        private readonly IFileSystemService _fileSystemService;

        public DeleteFilesCommandHandler(IFileRepository fileRepository, IFileSystemService fileSystemService)
        {
            _fileRepository = fileRepository;
            _fileSystemService = fileSystemService;
        }

        public async Task<Unit> Handle(DeleteFilesCommand request, CancellationToken cancellationToken)
        {
            Guard.AgainstNull(nameof(File), request);
            Guard.AgainstNullOrNotAny(nameof(File), request.Ids);

            var rsFiles = await _fileRepository.FindByAsync(e => request.Ids.Contains(e.Id));
            var tasks = new List<Task>();

            // Deletes files in folder
            tasks.Add(Task.Run(() => { rsFiles.ForEach(f => _fileSystemService.Delete(f.FilePath)); }));

            // Deletes data files in database
            tasks.Add(_fileRepository.DeleteFiles(rsFiles));

            Task task = Task.WhenAll(tasks);
            await task;

            return Unit.Value;
        }
    }
}
