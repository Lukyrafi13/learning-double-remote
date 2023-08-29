using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RfTargetStatuss;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RfTargetStatuss.Commands;
using NewLMS.UMKM.MediatR.Features.RfTargetStatuss.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RfTargetStatus
{
    public class RfTargetStatusController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RfTargetStatus
        /// </summary>
        /// <param name="mediator"></param>
        public RfTargetStatusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RfTargetStatus By StatusCode
        /// </summary>
        /// <param name="StatusCode"></param>
        /// <returns></returns>
        [HttpGet("get/{StatusCode}", Name = "GetRfTargetStatusByStatusCode")]
        [Produces("application/json", "application/xml", Type = typeof(RfTargetStatusResponseDto))]
        public async Task<IActionResult> GetRfTargetStatusByStatusCode(string StatusCode)
        {
            var getStatusTargetQuery = new RfTargetStatussGetByStatusCodeQuery { StatusCode = StatusCode };
            var result = await _mediator.Send(getStatusTargetQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RfTargetStatus By StatusCode
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRfTargetStatusList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RfTargetStatusResponseDto>>))]
        public async Task<IActionResult> GetRfTargetStatusList(RfTargetStatussGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RfTargetStatus
        /// </summary>
        /// <param name="postRfTargetStatus"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRfTargetStatus")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RfTargetStatusResponseDto>))]
        public async Task<IActionResult> AddRfTargetStatus(RfTargetStatusPostCommand postRfTargetStatus)
        {
            var result = await _mediator.Send(postRfTargetStatus);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRfTargetStatusByStatusCode", new { id = result.Data.StatusCode }, result.Data);
        }

        /// <summary>
        /// Put Edit RfTargetStatus
        /// </summary>
        /// <param name="StatusCode"></param>
        /// <param name="putRfTargetStatus"></param>
        /// <returns></returns>
        [HttpPut("put/{StatusCode}", Name = "EditRfTargetStatus")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RfTargetStatusResponseDto>))]
        public async Task<IActionResult> EditRfTargetStatus([FromRoute] string StatusCode, [FromBody] RfTargetStatusPutCommand putRfTargetStatus)
        {
            putRfTargetStatus.StatusCode = StatusCode;
            var result = await _mediator.Send(putRfTargetStatus);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RfTargetStatus
        /// </summary>
        /// <param name="StatusCode"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{StatusCode}", Name = "DeleteRfTargetStatus")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRfTargetStatus([FromRoute] string StatusCode, [FromBody]RfTargetStatusDeleteCommand deleteCommand)
        {
            deleteCommand.StatusCode = StatusCode;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}