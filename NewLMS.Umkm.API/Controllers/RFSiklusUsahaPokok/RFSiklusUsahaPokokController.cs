using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFSiklusUsahaPokoks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFSiklusUsahaPokoks.Commands;
using NewLMS.UMKM.MediatR.Features.RFSiklusUsahaPokoks.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RFSiklusUsahaPokok
{
    public class RFSiklusUsahaPokokController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFSiklusUsahaPokok
        /// </summary>
        /// <param name="mediator"></param>
        public RFSiklusUsahaPokokController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFSiklusUsahaPokok By SiklusCode
        /// </summary>
        /// <param name="SiklusCode"></param>
        /// <returns></returns>
        [HttpGet("get/{SiklusCode}", Name = "GetRFSiklusUsahaPokokBy")]
        [Produces("application/json", "application/xml", Type = typeof(RFSiklusUsahaPokokResponseDto))]
        public async Task<IActionResult> GetRFSiklusUsahaPokokBy(string SiklusCode)
        {
            var getGenderQuery = new RFSiklusUsahaPokokGetQuery { SiklusCode = SiklusCode };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFSiklusUsahaPokok By Filter
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFSiklusUsahaPokokList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFSiklusUsahaPokokResponseDto>>))]
        public async Task<IActionResult> GetRFSiklusUsahaPokokList(RFSiklusUsahaPokoksGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFSiklusUsahaPokok
        /// </summary>
        /// <param name="postRFSiklusUsahaPokok"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFSiklusUsahaPokok")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFSiklusUsahaPokokResponseDto>))]
        public async Task<IActionResult> AddRFSiklusUsahaPokok(RFSiklusUsahaPokokPostCommand postRFSiklusUsahaPokok)
        {
            var result = await _mediator.Send(postRFSiklusUsahaPokok);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFSiklusUsahaPokokBySiklusCode", new { id = result.Data.SiklusCode }, result.Data);
        }

        /// <summary>
        /// Put Edit RFSiklusUsahaPokok
        /// </summary>
        /// <param name="SiklusCode"></param>
        /// <param name="putRFSiklusUsahaPokok"></param>
        /// <returns></returns>
        [HttpPut("put/{SiklusCode}", Name = "EditRFSiklusUsahaPokok")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFSiklusUsahaPokokResponseDto>))]
        public async Task<IActionResult> EditRFSiklusUsahaPokok([FromRoute] string SiklusCode, [FromBody] RFSiklusUsahaPokokPutCommand putRFSiklusUsahaPokok)
        {
            putRFSiklusUsahaPokok.SiklusCode = SiklusCode;
            var result = await _mediator.Send(putRFSiklusUsahaPokok);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFSiklusUsahaPokok
        /// </summary>
        /// <param name="SiklusCode"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{SiklusCode}", Name = "DeleteRFSiklusUsahaPokok")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFSiklusUsahaPokok([FromRoute] string SiklusCode, [FromBody]RFSiklusUsahaPokokDeleteCommand deleteCommand)
        {
            deleteCommand.SiklusCode = SiklusCode;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}