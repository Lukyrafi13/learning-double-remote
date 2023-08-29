using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFTipeKredits;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFTipeKredits.Commands;
using NewLMS.UMKM.MediatR.Features.RFTipeKredits.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RFTipeKredit
{
    public class RFTipeKreditController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFTipeKredit
        /// </summary>
        /// <param name="mediator"></param>
        public RFTipeKreditController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFTipeKredit By Code
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        [HttpGet("get/{Code}", Name = "GetRFTipeKreditByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFTipeKreditResponseDto))]
        public async Task<IActionResult> GetRFTipeKreditByCode(string Code)
        {
            var getSCOQuery = new RFTipeKreditGetQuery { Code = Code };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFTipeKredit
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFTipeKreditList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFTipeKreditResponseDto>>))]
        public async Task<IActionResult> GetRFTipeKreditList(RFTipeKreditsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFTipeKredit
        /// </summary>
        /// <param name="postRFTipeKredit"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFTipeKredit")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFTipeKreditResponseDto>))]
        public async Task<IActionResult> AddRFTipeKredit(RFTipeKreditPostCommand postRFTipeKredit)
        {
            var result = await _mediator.Send(postRFTipeKredit);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFTipeKreditByCode", new { Code = result.Data.Code }, result.Data);
        }

        /// <summary>
        /// Put Edit RFTipeKredit
        /// </summary>
        /// <param name="Code"></param>
        /// <param name="putRFTipeKredit"></param>
        /// <returns></returns>
        [HttpPut("put/{Code}", Name = "EditRFTipeKredit")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFTipeKreditResponseDto>))]
        public async Task<IActionResult> EditRFTipeKredit([FromRoute] string Code, [FromBody] RFTipeKreditPutCommand putRFTipeKredit)
        {
            putRFTipeKredit.Code = Code;
            var result = await _mediator.Send(putRFTipeKredit);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFTipeKredit
        /// </summary>
        /// <param name="Code"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Code}", Name = "DeleteRFTipeKredit")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFTipeKredit([FromRoute] string Code, [FromBody]RFTipeKreditDeleteCommand deleteCommand)
        {
            deleteCommand.Code = Code;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}