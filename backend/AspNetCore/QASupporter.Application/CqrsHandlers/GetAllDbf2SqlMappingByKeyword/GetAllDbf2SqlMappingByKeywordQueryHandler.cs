using Microsoft.Extensions.Options;
using QASupporter.Application.Configuration.ApplicationSettings;
using QASupporter.Application.Configuration.Database;
using QASupporter.Application.Configuration.Queries;
using QASupporter.Application.CqrsHandlers.ReadModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QASupporter.Application.CqrsHandlers.GetAllDbf2SqlMappingByKeyword
{
    public class GetAllDbf2SqlMappingByKeywordQueryHandler : IQueryHandler<GetAllDbf2SqlMappingByKeywordQuery, IList<BaseDbf2SqlMappingDto>>
    {
        private readonly IDbf2SqlMappingDapperRepository _dbf2SqlMappingDapperRepository;
        private readonly QaSupporterSettings _configuration;

        public GetAllDbf2SqlMappingByKeywordQueryHandler(IDbf2SqlMappingDapperRepository dbf2SqlMappingDapperRepository, IOptions<QaSupporterSettings> config)
        {
            _dbf2SqlMappingDapperRepository = dbf2SqlMappingDapperRepository;
            _configuration = config.Value;
        }

        public async Task<IList<BaseDbf2SqlMappingDto>> Handle(GetAllDbf2SqlMappingByKeywordQuery request, CancellationToken cancellationToken)
        {
            List<BaseDbf2SqlMappingDto> baseDbf2SqlMappingDtos = (await _dbf2SqlMappingDapperRepository.GetAllDbf2SqlMappingByKeywordAsync(request.Keyword, request.ModifiedBy)).ToList();
            return baseDbf2SqlMappingDtos;
        }
    }
}
