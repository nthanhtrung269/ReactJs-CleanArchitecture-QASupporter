using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using QASupporter.Application.Configuration.ApplicationSettings;
using QASupporter.Application.CqrsHandlers.AddDbf2SqlMapping;
using QASupporter.Application.CqrsHandlers.GetAllDbf2SqlMappingByKeyword;
using QASupporter.Application.CqrsHandlers.GetDbf2SqlMappingById;
using QASupporter.Application.CqrsHandlers.ReadModels;
using QASupporter.Application.CqrsHandlers.WriteModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QASupporter.Api.Controllers
{
    /// <summary>
    /// The FileController.
    /// </summary>
    [Route("api/dbf2sqlmapping")]
    [ApiController]
    public class Dbf2SqlMappingControllerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly QaSupporterSettings _configuration;

        /// <summary>
        /// File Controller.
        /// </summary>
        /// <param name="mediator">The mediator.</param>
        /// <param name="config">The config.</param>
        public Dbf2SqlMappingControllerController(IMediator mediator,
            IOptions<QaSupporterSettings> config)
        {
            _mediator = mediator;
            _configuration = config.Value;
        }

        /// <summary>
        /// Gets all by keyword.
        /// </summary>
        /// <param name="keyword">The keyword.</param>
        /// /// <param name="modifiedBy">The modifiedBy.</param>
        /// <returns>Task{IList{BaseDbf2SqlMappingDto}}.</returns>
        [HttpGet("get-all")]
        public async Task<IList<BaseDbf2SqlMappingDto>> GetAllDbf2SqlMappingByKeyword(string keyword, string modifiedBy)
        {
            return await _mediator.Send(new GetAllDbf2SqlMappingByKeywordQuery(keyword, modifiedBy));
        }

        /// <summary>
        /// Gets by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>Task{IList{BaseDbf2SqlMappingDto}}.</returns>
        [HttpGet("get")]
        public async Task<BaseDbf2SqlMappingDto> GetDbf2SqlMappingById(int id)
        {
            return await _mediator.Send(new GetDbf2SqlMappingByIdQuery(id));
        }

        /// <summary>
        /// Adds Dbf2SqlMapping.
        /// </summary>
        /// <param name="request">The request.</param>
        [HttpPost("add")]
        public async Task<bool> Add(Dbf2SqlMappingDto request)
        {
            return await _mediator.Send(new AddDbf2SqlMappingCommand(request));
        }

        /// <summary>
        /// Edits Dbf2SqlMapping.
        /// </summary>
        /// <param name="request">The request.</param>
        [HttpPost("edit")]
        public async Task<bool> Edit(Dbf2SqlMappingDto request)
        {
            return await _mediator.Send(new AddDbf2SqlMappingCommand(request));
        }
    }
}