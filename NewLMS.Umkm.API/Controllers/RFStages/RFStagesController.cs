using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFStagess;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFStagess.Commands;
using NewLMS.UMKM.MediatR.Features.RFStagess.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RFStages
{
    public class RFStagesController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFStages
        /// </summary>
        /// <param name="mediator"></param>
        public RFStagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFStages By StageId
        /// </summary>
        /// <param name="StageId"></param>
        /// <returns></returns>
        [HttpGet("get/{StageId}", Name = "GetRFStagesByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFStagesResponseDto))]
        public async Task<IActionResult> GetRFStagesByCode(int StageId)
        {
            var getSCOQuery = new RFStagesGetQuery { StageId = StageId };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFStages By StageId
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFStagesList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFStagesResponseDto>>))]
        public async Task<IActionResult> GetRFStagesList(RFStagessGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFStages
        /// </summary>
        /// <param name="postRFStages"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFStages")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFStagesResponseDto>))]
        public async Task<IActionResult> AddRFStages(RFStagesPostCommand postRFStages)
        {
            var result = await _mediator.Send(postRFStages);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFStagesByCode", new { id = result.Data.StageId }, result.Data);
        }

        /// <summary>
        /// Put Edit RFStages
        /// </summary>
        /// <param name="StageId"></param>
        /// <param name="putRFStages"></param>
        /// <returns></returns>
        [HttpPut("put/{StageId}", Name = "EditRFStages")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFStagesResponseDto>))]
        public async Task<IActionResult> EditRFStages([FromRoute] int StageId, [FromBody] RFStagesPutCommand putRFStages)
        {
            putRFStages.StageId = StageId;
            var result = await _mediator.Send(putRFStages);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFStages
        /// </summary>
        /// <param name="StageId"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{StageId}", Name = "DeleteRFStages")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFStages([FromRoute] int StageId, [FromBody]RFStagesDeleteCommand deleteCommand)
        {
            deleteCommand.StageId = StageId;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}