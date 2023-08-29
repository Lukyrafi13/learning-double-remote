using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RFPolaPengembalians;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFPolaPengembalians.Commands;
using NewLMS.Umkm.MediatR.Features.RFPolaPengembalians.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.RFPolaPengembalian
{
    public class RFPolaPengembalianController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFPolaPengembalian
        /// </summary>
        /// <param name="mediator"></param>
        public RFPolaPengembalianController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFPolaPengembalian By Id
        /// </summary>
        /// <param name="PolaCode"></param>
        /// <returns></returns>
        [HttpGet("get/{PolaCode}", Name = "GetRFPolaPengembalianById")]
        [Produces("application/json", "application/xml", Type = typeof(RFPolaPengembalianResponseDto))]
        public async Task<IActionResult> GetRFPolaPengembalianById(string PolaCode)
        {
            var getGenderQuery = new RFPolaPengembalianGetQuery { PolaCode = PolaCode };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFPolaPengembalian
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFPolaPengembalianList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFPolaPengembalianResponseDto>>))]
        public async Task<IActionResult> GetRFPolaPengembalianList(RFPolaPengembaliansGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFPolaPengembalian
        /// </summary>
        /// <param name="postRFPolaPengembalian"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFPolaPengembalian")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFPolaPengembalianResponseDto>))]
        public async Task<IActionResult> AddRFPolaPengembalian(RFPolaPengembalianPostCommand postRFPolaPengembalian)
        {
            var result = await _mediator.Send(postRFPolaPengembalian);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFPolaPengembalianById", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit RFPolaPengembalian
        /// </summary>
        /// <param name="PolaCode"></param>
        /// <param name="putRFPolaPengembalian"></param>
        /// <returns></returns>
        [HttpPut("put/{PolaCode}", Name = "EditRFPolaPengembalian")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFPolaPengembalianResponseDto>))]
        public async Task<IActionResult> EditRFPolaPengembalian([FromRoute] string PolaCode, [FromBody] RFPolaPengembalianPutCommand putRFPolaPengembalian)
        {
            putRFPolaPengembalian.PolaCode = PolaCode;
            var result = await _mediator.Send(putRFPolaPengembalian);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFPolaPengembalian
        /// </summary>
        /// <param name="PolaCode"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{PolaCode}", Name = "DeleteRFPolaPengembalian")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFPolaPengembalian([FromRoute] string PolaCode, [FromBody] RFPolaPengembalianDeleteCommand deleteCommand)
        {
            deleteCommand.PolaCode = PolaCode;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}