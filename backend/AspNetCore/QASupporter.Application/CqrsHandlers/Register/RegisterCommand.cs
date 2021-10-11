using QASupporter.Application.Configuration.Commands;
using QASupporter.Application.CqrsHandlers.WriteModels;

namespace QASupporter.Application.CqrsHandlers.Register
{
    public class RegisterCommand : CommandBase<bool>
    {
        public UserDto User { get; }

        public RegisterCommand(UserDto user)
        {
            User = user;
        }
    }
}
