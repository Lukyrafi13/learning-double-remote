using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RFDecisionSKs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFDecisionSKs.Commands;
using NewLMS.Umkm.MediatR.Features.RFDecisionSKs.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.RFDecisionSK
{
    public class RFDecisionSKController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFDecisionSK
        /// </summary>
        /// <param name="mediator"></param>
        public RFDecisionSKController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFDecisionSK By DEC_CODE
        /// </summary>
        /// <param name="DEC_CODE"></param>
        /// <returns></returns>
        [HttpGet("get/{DEC_CODE}", Name = "GetRFDecisionSKByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFDecisionSKResponseDto))]
        public async Task<IActionResult> GetRFDecisionSKByCode(string DEC_CODE)
        {
            var getSCOQuery = new RFDecisionSKGetQuery { DEC_CODE = DEC_CODE };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFDecisionSK By DEC_CODE
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFDecisionSKList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFDecisionSKResponseDto>>))]
        public async Task<IActionResult> GetRFDecisionSKList(RFDecisionSKsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFDecisionSK
        /// </summary>
        /// <param name="postRFDecisionSK"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFDecisionSK")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFDecisionSKResponseDto>))]
        public async Task<IActionResult> AddRFDecisionSK(RFDecisionSKPostCommand postRFDecisionSK)
        {
            var result = await _mediator.Send(postRFDecisionSK);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFDecisionSKByCode", new { id = result.Data.DEC_CODE }, result.Data);
        }

        /// <summary>
        /// Put Edit RFDecisionSK
        /// </summary>
        /// <param name="DEC_CODE"></param>
        /// <param name="putRFDecisionSK"></param>
        /// <returns></returns>
        [HttpPut("put/{DEC_CODE}", Name = "EditRFDecisionSK")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFDecisionSKResponseDto>))]
        public async Task<IActionResult> EditRFDecisionSK([FromRoute] string DEC_CODE, [FromBody] RFDecisionSKPutCommand putRFDecisionSK)
        {
            putRFDecisionSK.DEC_CODE = DEC_CODE;
            var result = await _mediator.Send(putRFDecisionSK);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFDecisionSK
        /// </summary>
        /// <param name="DEC_CODE"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{DEC_CODE}", Name = "DeleteRFDecisionSK")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFDecisionSK([FromRoute] string DEC_CODE, [FromBody]RFDecisionSKDeleteCommand deleteCommand)
        {
            deleteCommand.DEC_CODE = DEC_CODE;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}