using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFTipeDokumens;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFTipeDokumens.Commands;
using NewLMS.UMKM.MediatR.Features.RFTipeDokumens.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RFTipeDokumen
{
    public class RFTipeDokumenController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFTipeDokumen
        /// </summary>
        /// <param name="mediator"></param>
        public RFTipeDokumenController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFTipeDokumen By TypeCode
        /// </summary>
        /// <param name="TypeCode"></param>
        /// <returns></returns>
        [HttpGet("get/{TypeCode}", Name = "GetRFTipeDokumenByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFTipeDokumenResponseDto))]
        public async Task<IActionResult> GetRFTipeDokumenByCode(string TypeCode)
        {
            var getSCOQuery = new RFTipeDokumenGetQuery { TypeCode = TypeCode };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFTipeDokumen By TypeCode
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFTipeDokumenList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFTipeDokumenResponseDto>>))]
        public async Task<IActionResult> GetRFTipeDokumenList(RFTipeDokumensGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFTipeDokumen
        /// </summary>
        /// <param name="postRFTipeDokumen"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFTipeDokumen")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFTipeDokumenResponseDto>))]
        public async Task<IActionResult> AddRFTipeDokumen(RFTipeDokumenPostCommand postRFTipeDokumen)
        {
            var result = await _mediator.Send(postRFTipeDokumen);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFTipeDokumenByCode", new { TypeCode = result.Data.TypeCode }, result.Data);
        }

        /// <summary>
        /// Put Edit RFTipeDokumen
        /// </summary>
        /// <param name="TypeCode"></param>
        /// <param name="putRFTipeDokumen"></param>
        /// <returns></returns>
        [HttpPut("put/{TypeCode}", Name = "EditRFTipeDokumen")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFTipeDokumenResponseDto>))]
        public async Task<IActionResult> EditRFTipeDokumen([FromRoute] string TypeCode, [FromBody] RFTipeDokumenPutCommand putRFTipeDokumen)
        {
            putRFTipeDokumen.TypeCode = TypeCode;
            var result = await _mediator.Send(putRFTipeDokumen);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFTipeDokumen
        /// </summary>
        /// <param name="TypeCode"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{TypeCode}", Name = "DeleteRFTipeDokumen")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFTipeDokumen([FromRoute] string TypeCode, [FromBody]RFTipeDokumenDeleteCommand deleteCommand)
        {
            deleteCommand.TypeCode = TypeCode;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}