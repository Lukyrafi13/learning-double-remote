using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RfStages;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RfStages.Commands;
using NewLMS.UMKM.MediatR.Features.RfStages.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RfStages
{
    public class RfStageController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RfStage
        /// </summary>
        /// <param name="mediator"></param>
        public RfStageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RfStage By StageId
        /// </summary>
        /// <param name="StageId"></param>
        /// <returns></returns>
        [HttpGet("get/{StageId}", Name = "GetRfStageByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RfStageResponseDto))]
        public async Task<IActionResult> GetRfStageByCode(Guid StageId)
        {
            var getSCOQuery = new RfStageGetQuery { StageId = StageId };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RfStage By StageId
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRfStageList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RfStageResponseDto>>))]
        public async Task<IActionResult> GetRfStageList(RfStageGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RfStage
        /// </summary>
        /// <param name="postRfStage"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRfStage")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RfStageResponseDto>))]
        public async Task<IActionResult> AddRfStage(RfStagePostCommand postRfStage)
        {
            var result = await _mediator.Send(postRfStage);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRfStageByCode", new { id = result.Data.StageId }, result.Data);
        }

        /// <summary>
        /// Put Edit RfStage
        /// </summary>
        /// <param name="StageId"></param>
        /// <param name="putRfStage"></param>
        /// <returns></returns>
        [HttpPut("put/{StageId}", Name = "EditRfStage")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RfStageResponseDto>))]
        public async Task<IActionResult> EditRfStage([FromRoute] Guid StageId, [FromBody] RfStagePutCommand putRfStage)
        {
            putRfStage.StageId = StageId;
            var result = await _mediator.Send(putRfStage);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RfStage
        /// </summary>
        /// <param name="StageId"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{StageId}", Name = "DeleteRfStage")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRfStage([FromRoute] Guid StageId, [FromBody]RfStageDeleteCommand deleteCommand)
        {
            deleteCommand.StageId = StageId;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}