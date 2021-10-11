using QASupporter.Application.Configuration.Commands;

namespace QASupporter.Application.CqrsHandlers.DeleteDbf2SqlMapping
{
    public class DeleteDbf2SqlMappingCommand : CommandBase<bool>
    {
        public int Dbf2SqlMappingId { get; }

        public DeleteDbf2SqlMappingCommand(int dbf2SqlMappingId)
        {
            Dbf2SqlMappingId = dbf2SqlMappingId;
        }
    }
}
