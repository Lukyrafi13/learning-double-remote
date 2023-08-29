using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFTermConditions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFTermConditions.Commands;
using NewLMS.UMKM.MediatR.Features.RFTermConditions.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RFTermCondition
{
    public class RFTermConditionController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFTermCondition
        /// </summary>
        /// <param name="mediator"></param>
        public RFTermConditionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFTermCondition By TermCode
        /// </summary>
        /// <param name="TermCode"></param>
        /// <returns></returns>
        [HttpGet("get/{TermCode}", Name = "GetRFTermConditionByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFTermConditionResponseDto))]
        public async Task<IActionResult> GetRFTermConditionByCode(string TermCode)
        {
            var getSCOQuery = new RFTermConditionGetQuery { TermCode = TermCode };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFTermCondition By TermCode
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFTermConditionList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFTermConditionResponseDto>>))]
        public async Task<IActionResult> GetRFTermConditionList(RFTermConditionsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFTermCondition
        /// </summary>
        /// <param name="postRFTermCondition"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFTermCondition")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFTermConditionResponseDto>))]
        public async Task<IActionResult> AddRFTermCondition(RFTermConditionPostCommand postRFTermCondition)
        {
            var result = await _mediator.Send(postRFTermCondition);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFTermConditionByCode", new { TermCode = result.Data.TermCode }, result.Data);
        }

        /// <summary>
        /// Put Edit RFTermCondition
        /// </summary>
        /// <param name="TermCode"></param>
        /// <param name="putRFTermCondition"></param>
        /// <returns></returns>
        [HttpPut("put/{TermCode}", Name = "EditRFTermCondition")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFTermConditionResponseDto>))]
        public async Task<IActionResult> EditRFTermCondition([FromRoute] string TermCode, [FromBody] RFTermConditionPutCommand putRFTermCondition)
        {
            putRFTermCondition.TermCode = TermCode;
            var result = await _mediator.Send(putRFTermCondition);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFTermCondition
        /// </summary>
        /// <param name="TermCode"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{TermCode}", Name = "DeleteRFTermCondition")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFTermCondition([FromRoute] string TermCode, [FromBody]RFTermConditionDeleteCommand deleteCommand)
        {
            deleteCommand.TermCode = TermCode;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}