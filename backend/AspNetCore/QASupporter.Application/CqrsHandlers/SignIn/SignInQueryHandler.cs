using QASupporter.Application.Configuration.Database;
using QASupporter.Application.Configuration.Queries;
using QASupporter.Application.CqrsHandlers.ReadModels;
using QASupporter.Domain.Helpers;
using System.Threading;
using System.Threading.Tasks;

namespace QASupporter.Application.CqrsHandlers.SignIn
{
    public class SignInQueryQueryHandler : IQueryHandler<SignInQuery, BaseUserDto>
    {
        private readonly IUserDapperRepository _userDapperRepository;

        public SignInQueryQueryHandler(IUserDapperRepository userDapperRepository)
        {
            _userDapperRepository = userDapperRepository;
        }

        public async Task<BaseUserDto> Handle(SignInQuery request, CancellationToken cancellationToken)
        {
            BaseUserDto baseUserDto = await _userDapperRepository.GetUserByUserNameAsync(request.User.UserName);
            Guard.AgainstInvalidOperationWithMessage($"UserName {request.User.UserName} is not valid.", baseUserDto != null);
            return baseUserDto;
        }
    }
}
