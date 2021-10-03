using QASupporter.Application.Configuration.Commands;

namespace QASupporter.Application.CqrsHandlers.DeleteFile
{
    public class DeleteFileCommand : CommandBase
    {
        public long FileId { get; }

        public DeleteFileCommand(long fileId)
        {
            FileId = fileId;
        }
    }
}
