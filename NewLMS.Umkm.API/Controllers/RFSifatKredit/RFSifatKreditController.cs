using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RFSifatKredits;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFSifatKredits.Commands;
using NewLMS.Umkm.MediatR.Features.RFSifatKredits.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.RFSifatKredit
{
    public class RFSifatKreditController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFSifatKredit
        /// </summary>
        /// <param name="mediator"></param>
        public RFSifatKreditController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFSifatKredit By SKCode
        /// </summary>
        /// <param name="SKCode"></param>
        /// <returns></returns>
        [HttpGet("get/{SKCode}", Name = "GetRFSifatKreditByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFSifatKreditResponseDto))]
        public async Task<IActionResult> GetRFSifatKreditByCode(string SKCode)
        {
            var getSCOQuery = new RFSifatKreditGetQuery { SKCode = SKCode };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFSifatKredit By SKCode
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFSifatKreditList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFSifatKreditResponseDto>>))]
        public async Task<IActionResult> GetRFSifatKreditList(RFSifatKreditsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFSifatKredit
        /// </summary>
        /// <param name="postRFSifatKredit"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFSifatKredit")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFSifatKreditResponseDto>))]
        public async Task<IActionResult> AddRFSifatKredit(RFSifatKreditPostCommand postRFSifatKredit)
        {
            var result = await _mediator.Send(postRFSifatKredit);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFSifatKreditByCode", new { id = result.Data.SKCode }, result.Data);
        }

        /// <summary>
        /// Put Edit RFSifatKredit
        /// </summary>
        /// <param name="SKCode"></param>
        /// <param name="putRFSifatKredit"></param>
        /// <returns></returns>
        [HttpPut("put/{SKCode}", Name = "EditRFSifatKredit")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFSifatKreditResponseDto>))]
        public async Task<IActionResult> EditRFSifatKredit([FromRoute] string SKCode, [FromBody] RFSifatKreditPutCommand putRFSifatKredit)
        {
            putRFSifatKredit.SKCode = SKCode;
            var result = await _mediator.Send(putRFSifatKredit);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFSifatKredit
        /// </summary>
        /// <param name="SKCode"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{SKCode}", Name = "DeleteRFSifatKredit")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFSifatKredit([FromRoute] string SKCode, [FromBody]RFSifatKreditDeleteCommand deleteCommand)
        {
            deleteCommand.SKCode = SKCode;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}