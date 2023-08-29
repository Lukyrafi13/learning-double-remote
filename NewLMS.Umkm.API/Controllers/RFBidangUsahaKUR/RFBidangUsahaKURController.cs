using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFBidangUsahaKURs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFBidangUsahaKURs.Commands;
using NewLMS.UMKM.MediatR.Features.RFBidangUsahaKURs.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RFBidangUsahaKUR
{
    public class RFBidangUsahaKURController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFBidangUsahaKUR
        /// </summary>
        /// <param name="mediator"></param>
        public RFBidangUsahaKURController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFBidangUsahaKUR By BTCode
        /// </summary>
        /// <param name="BTCode"></param>
        /// <returns></returns>
        [HttpGet("get/{BTCode}", Name = "GetRFBidangUsahaKURBy")]
        [Produces("application/json", "application/xml", Type = typeof(RFBidangUsahaKURResponseDto))]
        public async Task<IActionResult> GetRFBidangUsahaKURBy(string BTCode)
        {
            var getGenderQuery = new RFBidangUsahaKURGetQuery { BTCode = BTCode };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFBidangUsahaKUR By Filter
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFBidangUsahaKURList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFBidangUsahaKURResponseDto>>))]
        public async Task<IActionResult> GetRFBidangUsahaKURList(RFBidangUsahaKURsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFBidangUsahaKUR
        /// </summary>
        /// <param name="postRFBidangUsahaKUR"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFBidangUsahaKUR")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFBidangUsahaKURResponseDto>))]
        public async Task<IActionResult> AddRFBidangUsahaKUR(RFBidangUsahaKURPostCommand postRFBidangUsahaKUR)
        {
            var result = await _mediator.Send(postRFBidangUsahaKUR);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFBidangUsahaKURByBTCode", new { id = result.Data.BTCode }, result.Data);
        }

        /// <summary>
        /// Put Edit RFBidangUsahaKUR
        /// </summary>
        /// <param name="BTCode"></param>
        /// <param name="putRFBidangUsahaKUR"></param>
        /// <returns></returns>
        [HttpPut("put/{BTCode}", Name = "EditRFBidangUsahaKUR")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFBidangUsahaKURResponseDto>))]
        public async Task<IActionResult> EditRFBidangUsahaKUR([FromRoute] string BTCode, [FromBody] RFBidangUsahaKURPutCommand putRFBidangUsahaKUR)
        {
            putRFBidangUsahaKUR.BTCode = BTCode;
            var result = await _mediator.Send(putRFBidangUsahaKUR);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFBidangUsahaKUR
        /// </summary>
        /// <param name="BTCode"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{BTCode}", Name = "DeleteRFBidangUsahaKUR")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFBidangUsahaKUR([FromRoute] string BTCode, [FromBody]RFBidangUsahaKURDeleteCommand deleteCommand)
        {
            deleteCommand.BTCode = BTCode;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}