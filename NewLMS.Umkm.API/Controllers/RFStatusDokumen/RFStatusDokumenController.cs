using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFStatusDokumens;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFStatusDokumens.Commands;
using NewLMS.UMKM.MediatR.Features.RFStatusDokumens.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RFStatusDokumen
{
    public class RFStatusDokumenController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFStatusDokumen
        /// </summary>
        /// <param name="mediator"></param>
        public RFStatusDokumenController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFStatusDokumen By StatusCode
        /// </summary>
        /// <param name="StatusCode"></param>
        /// <returns></returns>
        [HttpGet("get/{StatusCode}", Name = "GetRFStatusDokumenByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFStatusDokumenResponseDto))]
        public async Task<IActionResult> GetRFStatusDokumenByCode(string StatusCode)
        {
            var getSCOQuery = new RFStatusDokumenGetQuery { StatusCode = StatusCode };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFStatusDokumen By Filter
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFStatusDokumenList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFStatusDokumenResponseDto>>))]
        public async Task<IActionResult> GetRFStatusDokumenList(RFStatusDokumensGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFStatusDokumen
        /// </summary>
        /// <param name="postRFStatusDokumen"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFStatusDokumen")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFStatusDokumenResponseDto>))]
        public async Task<IActionResult> AddRFStatusDokumen(RFStatusDokumenPostCommand postRFStatusDokumen)
        {
            var result = await _mediator.Send(postRFStatusDokumen);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFStatusDokumenByCode", new { StatusCode = result.Data.StatusCode }, result.Data);
        }

        /// <summary>
        /// Put Edit RFStatusDokumen
        /// </summary>
        /// <param name="StatusCode"></param>
        /// <param name="putRFStatusDokumen"></param>
        /// <returns></returns>
        [HttpPut("put/{StatusCode}", Name = "EditRFStatusDokumen")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFStatusDokumenResponseDto>))]
        public async Task<IActionResult> EditRFStatusDokumen([FromRoute] string StatusCode, [FromBody] RFStatusDokumenPutCommand putRFStatusDokumen)
        {
            putRFStatusDokumen.StatusCode = StatusCode;
            var result = await _mediator.Send(putRFStatusDokumen);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFStatusDokumen
        /// </summary>
        /// <param name="StatusCode"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{StatusCode}", Name = "DeleteRFStatusDokumen")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFStatusDokumen([FromRoute] string StatusCode, [FromBody]RFStatusDokumenDeleteCommand deleteCommand)
        {
            deleteCommand.StatusCode = StatusCode;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}