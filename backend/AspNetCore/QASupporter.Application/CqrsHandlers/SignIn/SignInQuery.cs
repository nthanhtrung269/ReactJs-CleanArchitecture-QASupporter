using QASupporter.Application.Configuration.Queries;
using QASupporter.Application.CqrsHandlers.ReadModels;
using QASupporter.Application.CqrsHandlers.WriteModels;

namespace QASupporter.Application.CqrsHandlers.SignIn
{
    public class SignInQuery : IQuery<BaseUserDto>
    {
        public UserDto User { get; }

        public SignInQuery(UserDto user)
        {
            User = user;
        }
    }
}
