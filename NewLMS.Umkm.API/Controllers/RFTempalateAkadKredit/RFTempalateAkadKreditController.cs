using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFTempalateAkadKredits;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFTempalateAkadKredits.Commands;
using NewLMS.UMKM.MediatR.Features.RFTempalateAkadKredits.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RFTempalateAkadKredit
{
    public class RFTempalateAkadKreditController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFTempalateAkadKredit
        /// </summary>
        /// <param name="mediator"></param>
        public RFTempalateAkadKreditController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFTempalateAkadKredit By TermDesc
        /// </summary>
        /// <param name="TermDesc"></param>
        /// <returns></returns>
        [HttpGet("get/{TermDesc}", Name = "GetRFTempalateAkadKreditByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFTempalateAkadKreditResponseDto))]
        public async Task<IActionResult> GetRFTempalateAkadKreditByCode(string TermDesc)
        {
            var getSCOQuery = new RFTempalateAkadKreditGetQuery { TermDesc = TermDesc };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFTempalateAkadKredit By TermDesc
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFTempalateAkadKreditList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFTempalateAkadKreditResponseDto>>))]
        public async Task<IActionResult> GetRFTempalateAkadKreditList(RFTempalateAkadKreditsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFTempalateAkadKredit
        /// </summary>
        /// <param name="postRFTempalateAkadKredit"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFTempalateAkadKredit")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFTempalateAkadKreditResponseDto>))]
        public async Task<IActionResult> AddRFTempalateAkadKredit(RFTempalateAkadKreditPostCommand postRFTempalateAkadKredit)
        {
            var result = await _mediator.Send(postRFTempalateAkadKredit);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFTempalateAkadKreditByCode", new { TermDesc = result.Data.TermDesc }, result.Data);
        }

        /// <summary>
        /// Put Edit RFTempalateAkadKredit
        /// </summary>
        /// <param name="TermDesc"></param>
        /// <param name="putRFTempalateAkadKredit"></param>
        /// <returns></returns>
        [HttpPut("put/{TermDesc}", Name = "EditRFTempalateAkadKredit")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFTempalateAkadKreditResponseDto>))]
        public async Task<IActionResult> EditRFTempalateAkadKredit([FromRoute] string TermDesc, [FromBody] RFTempalateAkadKreditPutCommand putRFTempalateAkadKredit)
        {
            putRFTempalateAkadKredit.TermDesc = TermDesc;
            var result = await _mediator.Send(putRFTempalateAkadKredit);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFTempalateAkadKredit
        /// </summary>
        /// <param name="TermDesc"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{TermDesc}", Name = "DeleteRFTempalateAkadKredit")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFTempalateAkadKredit([FromRoute] string TermDesc, [FromBody] RFTempalateAkadKreditDeleteCommand deleteCommand)
        {
            deleteCommand.TermDesc = TermDesc;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}