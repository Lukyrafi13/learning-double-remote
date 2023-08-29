using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.SIKPHistorys;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.SIKPHistorys.Commands;
using NewLMS.Umkm.MediatR.Features.SIKPHistorys.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.SIKPHistory
{
    public class SIKPHistoryController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// SIKPHistory
        /// </summary>
        /// <param name="mediator"></param>
        public SIKPHistoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get SIKPHistory By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetSIKPHistoryByCode")]
        [Produces("application/json", "application/xml", Type = typeof(SIKPHistoryResponseDto))]
        public async Task<IActionResult> GetSIKPHistoryByCode(Guid Id)
        {
            var getSCOQuery = new SIKPHistoryGetQuery { Id = Id };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get SIKPHistory By Id
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetSIKPHistoryList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<SIKPHistoryResponseDto>>))]
        public async Task<IActionResult> GetSIKPHistoryList(SIKPHistorysGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New SIKPHistory
        /// </summary>
        /// <param name="postSIKPHistory"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddSIKPHistory")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<SIKPHistoryResponseDto>))]
        public async Task<IActionResult> AddSIKPHistory(SIKPHistoryPostCommand postSIKPHistory)
        {
            var result = await _mediator.Send(postSIKPHistory);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetSIKPHistoryByCode", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit SIKPHistory
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putSIKPHistory"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditSIKPHistory")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<SIKPHistoryResponseDto>))]
        public async Task<IActionResult> EditSIKPHistory([FromRoute] Guid Id, [FromBody] SIKPHistoryPutCommand putSIKPHistory)
        {
            putSIKPHistory.Id = Id;
            var result = await _mediator.Send(putSIKPHistory);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete SIKPHistory
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteSIKPHistory")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteSIKPHistory([FromRoute] Guid Id, [FromBody]SIKPHistoryDeleteCommand deleteCommand)
        {
            deleteCommand.Id = Id;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}