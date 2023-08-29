using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RFRelationCols;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFRelationCols.Commands;
using NewLMS.Umkm.MediatR.Features.RFRelationCols.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.RFRelationCol
{
    public class RFRelationColController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFRelationCol
        /// </summary>
        /// <param name="mediator"></param>
        public RFRelationColController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFRelationCol By ReCode
        /// </summary>
        /// <param name="ReCode"></param>
        /// <returns></returns>
        [HttpGet("get/{ReCode}", Name = "GetRFRelationColByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFRelationColResponseDto))]
        public async Task<IActionResult> GetRFRelationColByCode(string ReCode)
        {
            var getSCOQuery = new RFRelationColsGetByCodeQuery { ReCode = ReCode };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFRelationCol By ReCode
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFRelationColList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFRelationColResponseDto>>))]
        public async Task<IActionResult> GetRFRelationColList(RFRelationColsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFRelationCol
        /// </summary>
        /// <param name="postRFRelationCol"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFRelationCol")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFRelationColResponseDto>))]
        public async Task<IActionResult> AddRFRelationCol(RFRelationColPostCommand postRFRelationCol)
        {
            var result = await _mediator.Send(postRFRelationCol);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFRelationColByCode", new { id = result.Data.ReCode }, result.Data);
        }

        /// <summary>
        /// Put Edit RFRelationCol
        /// </summary>
        /// <param name="ReCode"></param>
        /// <param name="putRFRelationCol"></param>
        /// <returns></returns>
        [HttpPut("put/{ReCode}", Name = "EditRFRelationCol")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFRelationColResponseDto>))]
        public async Task<IActionResult> EditRFRelationCol([FromRoute] string ReCode, [FromBody] RFRelationColPutCommand putRFRelationCol)
        {
            putRFRelationCol.ReCode = ReCode;
            var result = await _mediator.Send(putRFRelationCol);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFRelationCol
        /// </summary>
        /// <param name="ReCode"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{ReCode}", Name = "DeleteRFRelationCol")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFRelationCol([FromRoute] string ReCode, [FromBody]RFRelationColDeleteCommand deleteCommand)
        {
            deleteCommand.ReCode = ReCode;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}