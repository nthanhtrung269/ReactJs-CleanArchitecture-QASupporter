using QASupporter.Application.Configuration.Commands;
using QASupporter.Application.Configuration.Database;
using QASupporter.Domain.Helpers;
using QASupporter.Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace QASupporter.Application.CqrsHandlers.DeleteDbf2SqlMapping
{
    public class DeleteDbf2SqlMappingCommandHandler : ICommandHandler<DeleteDbf2SqlMappingCommand, bool>
    {
        private readonly IDbf2SqlMappingRepository _dbf2SqlMappingRepository;

        public DeleteDbf2SqlMappingCommandHandler(IDbf2SqlMappingRepository dbf2SqlMappingRepository)
        {
            _dbf2SqlMappingRepository = dbf2SqlMappingRepository;
        }

        public async Task<bool> Handle(DeleteDbf2SqlMappingCommand request, CancellationToken cancellationToken)
        {
            Guard.AgainstNull(nameof(DeleteDbf2SqlMappingCommand), request);

            Dbf2SqlMapping dbf2SqlMapping = await _dbf2SqlMappingRepository.GetByIdAsync(request.Dbf2SqlMappingId);
            Guard.AgainstNull(nameof(dbf2SqlMapping), dbf2SqlMapping);

            await _dbf2SqlMappingRepository.DeleteAsync(dbf2SqlMapping);
            await _dbf2SqlMappingRepository.CommitAsync();

            return true;
        }
    }
}
