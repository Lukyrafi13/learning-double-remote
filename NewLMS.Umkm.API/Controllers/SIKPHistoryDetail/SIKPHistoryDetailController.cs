using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.SIKPHistoryDetails;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.SIKPHistoryDetails.Commands;
using NewLMS.UMKM.MediatR.Features.SIKPHistoryDetails.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.SIKPHistoryDetail
{
    public class SIKPHistoryDetailController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// SIKPHistoryDetail
        /// </summary>
        /// <param name="mediator"></param>
        public SIKPHistoryDetailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get SIKPHistoryDetail By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetSIKPHistoryDetailByCode")]
        [Produces("application/json", "application/xml", Type = typeof(SIKPHistoryDetailResponseDto))]
        public async Task<IActionResult> GetSIKPHistoryDetailByCode(Guid Id)
        {
            var getSCOQuery = new SIKPHistoryDetailGetQuery { Id = Id };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get SIKPHistoryDetail
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetSIKPHistoryDetailList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<SIKPHistoryDetailResponseDto>>))]
        public async Task<IActionResult> GetSIKPHistoryDetailList(SIKPHistoryDetailsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New SIKPHistoryDetail
        /// </summary>
        /// <param name="postSIKPHistoryDetail"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddSIKPHistoryDetail")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<SIKPHistoryDetailResponseDto>))]
        public async Task<IActionResult> AddSIKPHistoryDetail(SIKPHistoryDetailPostCommand postSIKPHistoryDetail)
        {
            var result = await _mediator.Send(postSIKPHistoryDetail);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetSIKPHistoryDetailByCode", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit SIKPHistoryDetail
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putSIKPHistoryDetail"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditSIKPHistoryDetail")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<SIKPHistoryDetailResponseDto>))]
        public async Task<IActionResult> EditSIKPHistoryDetail([FromRoute] Guid Id, [FromBody] SIKPHistoryDetailPutCommand putSIKPHistoryDetail)
        {
            putSIKPHistoryDetail.Id = Id;
            var result = await _mediator.Send(putSIKPHistoryDetail);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete SIKPHistoryDetail
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteSIKPHistoryDetail")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteSIKPHistoryDetail([FromRoute] Guid Id, [FromBody]SIKPHistoryDetailDeleteCommand deleteCommand)
        {
            deleteCommand.Id = Id;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}