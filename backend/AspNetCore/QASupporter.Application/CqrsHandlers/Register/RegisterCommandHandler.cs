using MapsterMapper;
using QASupporter.Application.Configuration.Commands;
using QASupporter.Application.Configuration.Database;
using QASupporter.Application.CqrsHandlers.WriteModels;
using QASupporter.Domain.Helpers;
using QASupporter.Domain.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace QASupporter.Application.CqrsHandlers.Register
{
    public class RegisterCommandHandler : ICommandHandler<RegisterCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public RegisterCommandHandler(IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            Guard.AgainstNull(nameof(RegisterCommand), request);

            var user = _mapper.Map<UserDto, User>(request.User);

            user.CreatedDate = DateTime.UtcNow;
            user.CreatedBy = "Admin";
            user.ModifiedDate = DateTime.UtcNow;
            user.ModifiedBy = "Admin";
            user.IsAdmin = true;

            await _userRepository.AddAsync(user);
            await _userRepository.CommitAsync();

            return true;
        }
    }
}
