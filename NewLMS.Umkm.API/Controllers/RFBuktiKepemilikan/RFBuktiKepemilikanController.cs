using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RFBuktiKepemilikans;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFBuktiKepemilikans.Commands;
using NewLMS.Umkm.MediatR.Features.RFBuktiKepemilikans.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.RFBuktiKepemilikan
{
    public class RFBuktiKepemilikanController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFBuktiKepemilikan
        /// </summary>
        /// <param name="mediator"></param>
        public RFBuktiKepemilikanController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFBuktiKepemilikan By ANL_CODE
        /// </summary>
        /// <param name="ANL_CODE"></param>
        /// <returns></returns>
        [HttpGet("get/{ANL_CODE}", Name = "GetRFBuktiKepemilikanByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFBuktiKepemilikanResponseDto))]
        public async Task<IActionResult> GetRFBuktiKepemilikanByCode(string ANL_CODE)
        {
            var getSCOQuery = new RFBuktiKepemilikanGetQuery { ANL_CODE = ANL_CODE };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFBuktiKepemilikan By ANL_CODE
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFBuktiKepemilikanList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFBuktiKepemilikanResponseDto>>))]
        public async Task<IActionResult> GetRFBuktiKepemilikanList(RFBuktiKepemilikansGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFBuktiKepemilikan
        /// </summary>
        /// <param name="postRFBuktiKepemilikan"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFBuktiKepemilikan")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFBuktiKepemilikanResponseDto>))]
        public async Task<IActionResult> AddRFBuktiKepemilikan(RFBuktiKepemilikanPostCommand postRFBuktiKepemilikan)
        {
            var result = await _mediator.Send(postRFBuktiKepemilikan);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFBuktiKepemilikanByCode", new { id = result.Data.ANL_CODE }, result.Data);
        }

        /// <summary>
        /// Put Edit RFBuktiKepemilikan
        /// </summary>
        /// <param name="ANL_CODE"></param>
        /// <param name="putRFBuktiKepemilikan"></param>
        /// <returns></returns>
        [HttpPut("put/{ANL_CODE}", Name = "EditRFBuktiKepemilikan")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFBuktiKepemilikanResponseDto>))]
        public async Task<IActionResult> EditRFBuktiKepemilikan([FromRoute] string ANL_CODE, [FromBody] RFBuktiKepemilikanPutCommand putRFBuktiKepemilikan)
        {
            putRFBuktiKepemilikan.ANL_CODE = ANL_CODE;
            var result = await _mediator.Send(putRFBuktiKepemilikan);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFBuktiKepemilikan
        /// </summary>
        /// <param name="ANL_CODE"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{ANL_CODE}", Name = "DeleteRFBuktiKepemilikan")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFBuktiKepemilikan([FromRoute] string ANL_CODE, [FromBody]RFBuktiKepemilikanDeleteCommand deleteCommand)
        {
            deleteCommand.ANL_CODE = ANL_CODE;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}