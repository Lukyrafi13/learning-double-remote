using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.SlikCreditHistorys;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.SlikCreditHistorys.Commands;
using NewLMS.UMKM.MediatR.Features.SlikCreditHistorys.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.SlikCreditHistory
{
    public class SlikCreditHistoryController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// SlikCreditHistory
        /// </summary>
        /// <param name="mediator"></param>
        public SlikCreditHistoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get SlikCreditHistory By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetSlikCreditHistoryByCode")]
        [Produces("application/json", "application/xml", Type = typeof(SlikCreditHistoryResponseDto))]
        public async Task<IActionResult> GetSlikCreditHistoryByCode(Guid Id)
        {
            var getSCOQuery = new SlikCreditHistoryGetQuery { Id = Id };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get SlikCreditHistory
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetSlikCreditHistoryList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<SlikCreditHistoryResponseDto>>))]
        public async Task<IActionResult> GetSlikCreditHistoryList(SlikCreditHistorysGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New SlikCreditHistory
        /// </summary>
        /// <param name="postSlikCreditHistory"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddSlikCreditHistory")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<SlikCreditHistoryResponseDto>))]
        public async Task<IActionResult> AddSlikCreditHistory(SlikCreditHistoryPostCommand postSlikCreditHistory)
        {
            var result = await _mediator.Send(postSlikCreditHistory);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetSlikCreditHistoryByCode", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit SlikCreditHistory
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putSlikCreditHistory"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditSlikCreditHistory")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<SlikCreditHistoryResponseDto>))]
        public async Task<IActionResult> EditSlikCreditHistory([FromRoute] Guid Id, [FromBody] SlikCreditHistoryPutCommand putSlikCreditHistory)
        {
            putSlikCreditHistory.Id = Id;
            var result = await _mediator.Send(putSlikCreditHistory);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete SlikCreditHistory
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteSlikCreditHistory")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteSlikCreditHistory([FromRoute] Guid Id, [FromBody]SlikCreditHistoryDeleteCommand deleteCommand)
        {
            deleteCommand.Id = Id;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}