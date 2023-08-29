using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RFStatusTargets;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFStatusTargets.Commands;
using NewLMS.Umkm.MediatR.Features.RFStatusTargets.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.RFStatusTarget
{
    public class RFStatusTargetController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFStatusTarget
        /// </summary>
        /// <param name="mediator"></param>
        public RFStatusTargetController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFStatusTarget By StatusCode
        /// </summary>
        /// <param name="StatusCode"></param>
        /// <returns></returns>
        [HttpGet("get/{StatusCode}", Name = "GetRFStatusTargetByStatusCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFStatusTargetResponseDto))]
        public async Task<IActionResult> GetRFStatusTargetByStatusCode(string StatusCode)
        {
            var getStatusTargetQuery = new RFStatusTargetsGetByStatusCodeQuery { StatusCode = StatusCode };
            var result = await _mediator.Send(getStatusTargetQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFStatusTarget By StatusCode
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFStatusTargetList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFStatusTargetResponseDto>>))]
        public async Task<IActionResult> GetRFStatusTargetList(RFStatusTargetsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFStatusTarget
        /// </summary>
        /// <param name="postRFStatusTarget"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFStatusTarget")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFStatusTargetResponseDto>))]
        public async Task<IActionResult> AddRFStatusTarget(RFStatusTargetPostCommand postRFStatusTarget)
        {
            var result = await _mediator.Send(postRFStatusTarget);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFStatusTargetByStatusCode", new { id = result.Data.StatusCode }, result.Data);
        }

        /// <summary>
        /// Put Edit RFStatusTarget
        /// </summary>
        /// <param name="StatusCode"></param>
        /// <param name="putRFStatusTarget"></param>
        /// <returns></returns>
        [HttpPut("put/{StatusCode}", Name = "EditRFStatusTarget")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFStatusTargetResponseDto>))]
        public async Task<IActionResult> EditRFStatusTarget([FromRoute] string StatusCode, [FromBody] RFStatusTargetPutCommand putRFStatusTarget)
        {
            putRFStatusTarget.StatusCode = StatusCode;
            var result = await _mediator.Send(putRFStatusTarget);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFStatusTarget
        /// </summary>
        /// <param name="StatusCode"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{StatusCode}", Name = "DeleteRFStatusTarget")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFStatusTarget([FromRoute] string StatusCode, [FromBody]RFStatusTargetDeleteCommand deleteCommand)
        {
            deleteCommand.StatusCode = StatusCode;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}