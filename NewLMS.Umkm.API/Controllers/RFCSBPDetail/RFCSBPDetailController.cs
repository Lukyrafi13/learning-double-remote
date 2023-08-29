using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RFCSBPDetails;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFCSBPDetails.Commands;
using NewLMS.Umkm.MediatR.Features.RFCSBPDetails.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.RFCSBPDetail
{
    public class RFCSBPDetailController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFCSBPDetail
        /// </summary>
        /// <param name="mediator"></param>
        public RFCSBPDetailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFCSBPDetail By CSBPDetailID
        /// </summary>
        /// <param name="CSBPDetailID"></param>
        /// <returns></returns>
        [HttpGet("get/{CSBPDetailID}", Name = "GetRFCSBPDetailBy")]
        [Produces("application/json", "application/xml", Type = typeof(RFCSBPDetailResponseDto))]
        public async Task<IActionResult> GetRFCSBPDetailBy(string CSBPDetailID)
        {
            var getGenderQuery = new RFCSBPDetailGetQuery { CSBPDetailID = CSBPDetailID };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFCSBPDetail By Filter
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFCSBPDetailList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFCSBPDetailResponseDto>>))]
        public async Task<IActionResult> GetRFCSBPDetailList(RFCSBPDetailsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFCSBPDetail
        /// </summary>
        /// <param name="postRFCSBPDetail"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFCSBPDetail")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFCSBPDetailResponseDto>))]
        public async Task<IActionResult> AddRFCSBPDetail(RFCSBPDetailPostCommand postRFCSBPDetail)
        {
            var result = await _mediator.Send(postRFCSBPDetail);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFCSBPDetailByCSBPDetailID", new { id = result.Data.CSBPDetailID }, result.Data);
        }

        /// <summary>
        /// Put Edit RFCSBPDetail
        /// </summary>
        /// <param name="CSBPDetailID"></param>
        /// <param name="putRFCSBPDetail"></param>
        /// <returns></returns>
        [HttpPut("put/{CSBPDetailID}", Name = "EditRFCSBPDetail")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFCSBPDetailResponseDto>))]
        public async Task<IActionResult> EditRFCSBPDetail([FromRoute] string CSBPDetailID, [FromBody] RFCSBPDetailPutCommand putRFCSBPDetail)
        {
            putRFCSBPDetail.CSBPDetailID = CSBPDetailID;
            var result = await _mediator.Send(putRFCSBPDetail);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFCSBPDetail
        /// </summary>
        /// <param name="CSBPDetailID"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{CSBPDetailID}", Name = "DeleteRFCSBPDetail")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFCSBPDetail([FromRoute] string CSBPDetailID, [FromBody] RFCSBPDetailDeleteCommand deleteCommand)
        {
            deleteCommand.CSBPDetailID = CSBPDetailID;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}