using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using QASupporter.Api.RequestObjects;
using QASupporter.Application.Configuration.ApplicationSettings;
using QASupporter.Application.CqrsHandlers.GetAllUsers;
using QASupporter.Application.CqrsHandlers.ReadModels;
using QASupporter.Application.CqrsHandlers.Register;
using QASupporter.Application.CqrsHandlers.WriteModels;
using QASupporter.Domain.Constants;
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
        public UserInfoDto SignIn([FromBody] SignInRequest request)
        {
            if (request.Email == "admin@gmail.com")
            {
                return new UserInfoDto()
                {
                    Email = "admin@gmail.com",
                    UserName = "admin",
                    IsAdmin = true,
                    Status = true
                };
            }
            else
            {
                return new UserInfoDto()
                {
                    Status = false,
                    Message = MessageConstants.InvalidOperation
                };
            }
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