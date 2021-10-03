using QASupporter.Application.Configuration.Commands;
using System.Collections.Generic;

namespace QASupporter.Application.CqrsHandlers.DeleteFiles
{
    public class DeleteFilesCommand : CommandBase
    {
        public IList<long> Ids { get; }

        public DeleteFilesCommand(IList<long> ids)
        {
            Ids = ids;
        }
    }
}
