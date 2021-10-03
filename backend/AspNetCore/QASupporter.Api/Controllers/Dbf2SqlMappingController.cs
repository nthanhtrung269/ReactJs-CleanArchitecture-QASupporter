﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using QASupporter.Application.Configuration.ApplicationSettings;
using QASupporter.Application.CqrsHandlers.GetAllDbf2SqlMappingByKeyword;
using QASupporter.Application.CqrsHandlers.ReadModels;
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
    }
}