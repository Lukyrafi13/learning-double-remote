using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFConditions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFConditions.Commands;
using NewLMS.UMKM.MediatR.Features.RFConditions.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RFCondition
{
    public class RFConditionController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFCondition
        /// </summary>
        /// <param name="mediator"></param>
        public RFConditionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFCondition By ConditionCode
        /// </summary>
        /// <param name="ConditionCode"></param>
        /// <returns></returns>
        [HttpGet("get/{ConditionCode}", Name = "GetRFConditionByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFConditionResponseDto))]
        public async Task<IActionResult> GetRFConditionByCode(string ConditionCode)
        {
            var getSCOQuery = new RFConditionGetQuery { ConditionCode = ConditionCode };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFCondition By ConditionCode
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFConditionList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFConditionResponseDto>>))]
        public async Task<IActionResult> GetRFConditionList(RFConditionsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFCondition
        /// </summary>
        /// <param name="postRFCondition"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFCondition")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFConditionResponseDto>))]
        public async Task<IActionResult> AddRFCondition(RFConditionPostCommand postRFCondition)
        {
            var result = await _mediator.Send(postRFCondition);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFConditionByCode", new { ConditionCode = result.Data.ConditionCode }, result.Data);
        }

        /// <summary>
        /// Put Edit RFCondition
        /// </summary>
        /// <param name="ConditionCode"></param>
        /// <param name="putRFCondition"></param>
        /// <returns></returns>
        [HttpPut("put/{ConditionCode}", Name = "EditRFCondition")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFConditionResponseDto>))]
        public async Task<IActionResult> EditRFCondition([FromRoute] string ConditionCode, [FromBody] RFConditionPutCommand putRFCondition)
        {
            putRFCondition.ConditionCode = ConditionCode;
            var result = await _mediator.Send(putRFCondition);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFCondition
        /// </summary>
        /// <param name="ConditionCode"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{ConditionCode}", Name = "DeleteRFCondition")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFCondition([FromRoute] string ConditionCode, [FromBody]RFConditionDeleteCommand deleteCommand)
        {
            deleteCommand.ConditionCode = ConditionCode;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}