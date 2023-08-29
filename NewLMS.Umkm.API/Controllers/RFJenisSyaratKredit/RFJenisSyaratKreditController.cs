using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RFJenisSyaratKredits;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFJenisSyaratKredits.Commands;
using NewLMS.Umkm.MediatR.Features.RFJenisSyaratKredits.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.RFJenisSyaratKredit
{
    public class RFJenisSyaratKreditController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFJenisSyaratKredit
        /// </summary>
        /// <param name="mediator"></param>
        public RFJenisSyaratKreditController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFJenisSyaratKredit By SyaratCode
        /// </summary>
        /// <param name="SyaratCode"></param>
        /// <returns></returns>
        [HttpGet("get/{SyaratCode}", Name = "GetRFJenisSyaratKreditByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFJenisSyaratKreditResponseDto))]
        public async Task<IActionResult> GetRFJenisSyaratKreditByCode(string SyaratCode)
        {
            var getSCOQuery = new RFJenisSyaratKreditGetQuery { SyaratCode = SyaratCode };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFJenisSyaratKredit By SyaratCode
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFJenisSyaratKreditList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFJenisSyaratKreditResponseDto>>))]
        public async Task<IActionResult> GetRFJenisSyaratKreditList(RFJenisSyaratKreditsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFJenisSyaratKredit
        /// </summary>
        /// <param name="postRFJenisSyaratKredit"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFJenisSyaratKredit")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFJenisSyaratKreditResponseDto>))]
        public async Task<IActionResult> AddRFJenisSyaratKredit(RFJenisSyaratKreditPostCommand postRFJenisSyaratKredit)
        {
            var result = await _mediator.Send(postRFJenisSyaratKredit);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFJenisSyaratKreditByCode", new { SyaratCode = result.Data.SyaratCode }, result.Data);
        }

        /// <summary>
        /// Put Edit RFJenisSyaratKredit
        /// </summary>
        /// <param name="SyaratCode"></param>
        /// <param name="putRFJenisSyaratKredit"></param>
        /// <returns></returns>
        [HttpPut("put/{SyaratCode}", Name = "EditRFJenisSyaratKredit")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFJenisSyaratKreditResponseDto>))]
        public async Task<IActionResult> EditRFJenisSyaratKredit([FromRoute] string SyaratCode, [FromBody] RFJenisSyaratKreditPutCommand putRFJenisSyaratKredit)
        {
            putRFJenisSyaratKredit.SyaratCode = SyaratCode;
            var result = await _mediator.Send(putRFJenisSyaratKredit);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFJenisSyaratKredit
        /// </summary>
        /// <param name="SyaratCode"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{SyaratCode}", Name = "DeleteRFJenisSyaratKredit")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFJenisSyaratKredit([FromRoute] string SyaratCode, [FromBody]RFJenisSyaratKreditDeleteCommand deleteCommand)
        {
            deleteCommand.SyaratCode = SyaratCode;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}