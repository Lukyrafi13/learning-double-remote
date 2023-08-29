using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFCSBPHeaders;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFCSBPHeaders.Commands;
using NewLMS.UMKM.MediatR.Features.RFCSBPHeaders.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RFCSBPHeader
{
    public class RFCSBPHeaderController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFCSBPHeader
        /// </summary>
        /// <param name="mediator"></param>
        public RFCSBPHeaderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFCSBPHeader By CSBPGroupID
        /// </summary>
        /// <param name="CSBPGroupID"></param>
        /// <returns></returns>
        [HttpGet("get/{CSBPGroupID}", Name = "GetRFCSBPHeaderBy")]
        [Produces("application/json", "application/xml", Type = typeof(RFCSBPHeaderResponseDto))]
        public async Task<IActionResult> GetRFCSBPHeaderBy(string CSBPGroupID)
        {
            var getGenderQuery = new RFCSBPHeaderGetQuery { CSBPGroupID = CSBPGroupID };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFCSBPHeader By Filter
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFCSBPHeaderList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFCSBPHeaderResponseDto>>))]
        public async Task<IActionResult> GetRFCSBPHeaderList(RFCSBPHeadersGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFCSBPHeader
        /// </summary>
        /// <param name="postRFCSBPHeader"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFCSBPHeader")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFCSBPHeaderResponseDto>))]
        public async Task<IActionResult> AddRFCSBPHeader(RFCSBPHeaderPostCommand postRFCSBPHeader)
        {
            var result = await _mediator.Send(postRFCSBPHeader);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFCSBPHeaderByCSBPGroupID", new { id = result.Data.CSBPGroupID }, result.Data);
        }

        /// <summary>
        /// Put Edit RFCSBPHeader
        /// </summary>
        /// <param name="CSBPGroupID"></param>
        /// <param name="putRFCSBPHeader"></param>
        /// <returns></returns>
        [HttpPut("put/{CSBPGroupID}", Name = "EditRFCSBPHeader")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFCSBPHeaderResponseDto>))]
        public async Task<IActionResult> EditRFCSBPHeader([FromRoute] string CSBPGroupID, [FromBody] RFCSBPHeaderPutCommand putRFCSBPHeader)
        {
            putRFCSBPHeader.CSBPGroupID = CSBPGroupID;
            var result = await _mediator.Send(putRFCSBPHeader);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFCSBPHeader
        /// </summary>
        /// <param name="CSBPGroupID"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{CSBPGroupID}", Name = "DeleteRFCSBPHeader")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFCSBPHeader([FromRoute] string CSBPGroupID, [FromBody] RFCSBPHeaderDeleteCommand deleteCommand)
        {
            deleteCommand.CSBPGroupID = CSBPGroupID;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}