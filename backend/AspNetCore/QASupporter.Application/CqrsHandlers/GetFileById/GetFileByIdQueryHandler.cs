using QASupporter.Application.Configuration.Database;
using QASupporter.Application.Configuration.Queries;
using QASupporter.Application.CqrsHandlers.ReadModels;
using QASupporter.Domain.Helpers;
using System.Threading;
using System.Threading.Tasks;

namespace QASupporter.Application.CqrsHandlers.GetFileById
{
    public class GetFileByIdQueryHandler : IQueryHandler<GetFileByIdQuery, BaseFileDto>
    {
        private readonly IFileReadRepository _fileReadRepository;

        public GetFileByIdQueryHandler(IFileReadRepository fileReadRepository)
        {
            _fileReadRepository = fileReadRepository;
        }

        public async Task<BaseFileDto> Handle(GetFileByIdQuery request, CancellationToken cancellationToken)
        {
            Guard.AgainstNull(nameof(GetFileByIdQuery), request);
            var fileDto = await _fileReadRepository.GetFileByIdQuery(request.Id);
            return fileDto;
        }
    }
}
