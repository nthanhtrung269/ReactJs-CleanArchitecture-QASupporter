using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using QASupporter.Application.Configuration.ApplicationSettings;
using QASupporter.Application.CqrsHandlers.GetAllUsers;
using QASupporter.Application.CqrsHandlers.ReadModels;
using QASupporter.Application.CqrsHandlers.Register;
using QASupporter.Application.CqrsHandlers.SignIn;
using QASupporter.Application.CqrsHandlers.WriteModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QASupporter.Api.Controllers
{
    /// <summary>
    /// The FileController.
    /// </summary>
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly QaSupporterSettings _configuration;

        /// <summary>
        /// File Controller.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        /// <param name="config">The config.</param>
        public UsersController(IMediator mediator,
            IOptions<QaSupporterSettings> config)
        {
            _mediator = mediator;
            _configuration = config.Value;
        }

        /// <summary>
        /// Register.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>System.Boolean.</returns>
        [HttpPost("register")]
        public async Task<bool> RegisterAsync([FromBody] UserDto request)
        {
            return await _mediator.Send(new RegisterCommand(request));
        }

        /// <summary>
        /// Signin.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>UserInfoDto.</returns>
        [HttpPost("signin")]
        public async Task<BaseUserDto> SignInAsync([FromBody] UserDto request)
        {
            BaseUserDto baseUserDto = await _mediator.Send(new SignInQuery(request));

            if (baseUserDto != null)
            {
                baseUserDto.Password = string.Empty;
                baseUserDto.Status = true;
            }

            return baseUserDto;
        }

        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns>Task{IList{BaseUserDto}}.</returns>
        [HttpGet("get-all")]
        public async Task<IList<BaseUserDto>> GetAllUsers()
        {
            return await _mediator.Send(new GetAllUsersQuery());
        }
    }
}