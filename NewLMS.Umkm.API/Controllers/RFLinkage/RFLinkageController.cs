using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFLinkages;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFLinkages.Commands;
using NewLMS.UMKM.MediatR.Features.RFLinkages.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RFLinkage
{
    public class RFLinkageController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFLinkage
        /// </summary>
        /// <param name="mediator"></param>
        public RFLinkageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFLinkage By LinkCode
        /// </summary>
        /// <param name="LinkCode"></param>
        /// <returns></returns>
        [HttpGet("get/{LinkCode}", Name = "GetRFLinkageByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFLinkageResponseDto))]
        public async Task<IActionResult> GetRFLinkageByCode(string LinkCode)
        {
            var getSCOQuery = new RFLinkageGetQuery { LinkCode = LinkCode };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFLinkage By LinkCode
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFLinkageList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFLinkageResponseDto>>))]
        public async Task<IActionResult> GetRFLinkageList(RFLinkagesGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFLinkage
        /// </summary>
        /// <param name="postRFLinkage"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFLinkage")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFLinkageResponseDto>))]
        public async Task<IActionResult> AddRFLinkage(RFLinkagePostCommand postRFLinkage)
        {
            var result = await _mediator.Send(postRFLinkage);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFLinkageByCode", new { LinkCode = result.Data.LinkCode }, result.Data);
        }

        /// <summary>
        /// Put Edit RFLinkage
        /// </summary>
        /// <param name="LinkCode"></param>
        /// <param name="putRFLinkage"></param>
        /// <returns></returns>
        [HttpPut("put/{LinkCode}", Name = "EditRFLinkage")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFLinkageResponseDto>))]
        public async Task<IActionResult> EditRFLinkage([FromRoute] string LinkCode, [FromBody] RFLinkagePutCommand putRFLinkage)
        {
            putRFLinkage.LinkCode = LinkCode;
            var result = await _mediator.Send(putRFLinkage);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFLinkage
        /// </summary>
        /// <param name="LinkCode"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{LinkCode}", Name = "DeleteRFLinkage")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFLinkage([FromRoute] string LinkCode, [FromBody]RFLinkageDeleteCommand deleteCommand)
        {
            deleteCommand.LinkCode = LinkCode;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}