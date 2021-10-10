using Microsoft.Extensions.Options;
using QASupporter.Application.Configuration.ApplicationSettings;
using QASupporter.Application.Configuration.Database;
using QASupporter.Application.Configuration.Queries;
using QASupporter.Application.CqrsHandlers.ReadModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QASupporter.Application.CqrsHandlers.GetDbf2SqlMappingById
{
    public class GetDbf2SqlMappingByIdQueryHandler : IQueryHandler<GetDbf2SqlMappingByIdQuery, BaseDbf2SqlMappingDto>
    {
        private readonly IDbf2SqlMappingDapperRepository _dbf2SqlMappingDapperRepository;

        public GetDbf2SqlMappingByIdQueryHandler(IDbf2SqlMappingDapperRepository dbf2SqlMappingDapperRepository)
        {
            _dbf2SqlMappingDapperRepository = dbf2SqlMappingDapperRepository;
        }

        public async Task<BaseDbf2SqlMappingDto> Handle(GetDbf2SqlMappingByIdQuery request, CancellationToken cancellationToken)
        {
            BaseDbf2SqlMappingDto baseDbf2SqlMappingDto = await _dbf2SqlMappingDapperRepository.GetDbf2SqlMappingByIdAsync(request.Id);
            return baseDbf2SqlMappingDto;
        }
    }
}
