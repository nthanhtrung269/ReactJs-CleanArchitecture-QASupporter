using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using QASupporter.Api.RequestObjects;
using QASupporter.Application.Configuration.ApplicationSettings;
using QASupporter.Application.CqrsHandlers.ReadModels;
using QASupporter.Domain.Constants;

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
    }
}