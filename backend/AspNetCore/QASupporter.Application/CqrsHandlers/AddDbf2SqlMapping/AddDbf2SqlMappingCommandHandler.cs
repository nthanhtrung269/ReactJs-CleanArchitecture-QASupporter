using MapsterMapper;
using QASupporter.Application.Configuration.Commands;
using QASupporter.Application.Configuration.Database;
using QASupporter.Application.CqrsHandlers.WriteModels;
using QASupporter.Domain.Helpers;
using QASupporter.Domain.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace QASupporter.Application.CqrsHandlers.AddDbf2SqlMapping
{
    public class AddDbf2SqlMappingCommandHandler : ICommandHandler<AddDbf2SqlMappingCommand, bool>
    {
        private readonly IDbf2SqlMappingRepository _dbf2SqlMappingRepository;
        private readonly IMapper _mapper;

        public AddDbf2SqlMappingCommandHandler(IDbf2SqlMappingRepository dbf2SqlMappingRepository,
            IMapper mapper)
        {
            _dbf2SqlMappingRepository = dbf2SqlMappingRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(AddDbf2SqlMappingCommand request, CancellationToken cancellationToken)
        {
            Guard.AgainstNull(nameof(AddDbf2SqlMappingCommand), request);

            var dbf2SqlMapping = _mapper.Map<Dbf2SqlMappingDto, Dbf2SqlMapping>(request.Dbf2SqlMapping);
            dbf2SqlMapping.CreatedDate = DateTime.UtcNow;
            dbf2SqlMapping.CreatedBy = "Admin";

            await _dbf2SqlMappingRepository.AddAsync(dbf2SqlMapping);
            await _dbf2SqlMappingRepository.CommitAsync();

            return true;
        }
    }
}
