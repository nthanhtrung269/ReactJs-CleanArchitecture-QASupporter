using QASupporter.Application.Configuration.Commands;
using QASupporter.Application.CqrsHandlers.WriteModels;

namespace QASupporter.Application.CqrsHandlers.AddDbf2SqlMapping
{
    public class AddDbf2SqlMappingCommand : CommandBase<bool>
    {
        public Dbf2SqlMappingDto Dbf2SqlMapping { get; }

        public AddDbf2SqlMappingCommand(Dbf2SqlMappingDto dbf2SqlMapping)
        {
            Dbf2SqlMapping = dbf2SqlMapping;
        }
    }
}
