using QASupporter.Application.Configuration.Database;
using QASupporter.Application.Configuration.Queries;
using QASupporter.Application.CqrsHandlers.ReadModels;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace QASupporter.Application.CqrsHandlers.GetAllUsers
{
    public class GetAllUsersQueryHandler : IQueryHandler<GetAllUsersQuery, IList<BaseUserDto>>
    {
        private readonly IUserDapperRepository _userDapperRepository;

        public GetAllUsersQueryHandler(IUserDapperRepository userDapperRepository)
        {
            _userDapperRepository = userDapperRepository;
        }

        public async Task<IList<BaseUserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _userDapperRepository.GetAllUsersAsync();
        }
    }
}
