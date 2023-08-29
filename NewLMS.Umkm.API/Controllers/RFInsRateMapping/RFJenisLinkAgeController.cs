using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RFInsRateMappings;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFInsRateMappings.Commands;
using NewLMS.Umkm.MediatR.Features.RFInsRateMappings.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.RFInsRateMapping
{
    public class RFInsRateMappingController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFInsRateMapping
        /// </summary>
        /// <param name="mediator"></param>
        public RFInsRateMappingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFInsRateMapping By InsRateId
        /// </summary>
        /// <param name="InsRateId"></param>
        /// <returns></returns>
        [HttpGet("get/{InsRateId}", Name = "GetRFInsRateMappingByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFInsRateMappingResponseDto))]
        public async Task<IActionResult> GetRFInsRateMappingByCode(string InsRateId)
        {
            var getSCOQuery = new RFInsRateMappingGetQuery { InsRateId = InsRateId };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFInsRateMapping By InsRateId
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFInsRateMappingList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFInsRateMappingResponseDto>>))]
        public async Task<IActionResult> GetRFInsRateMappingList(RFInsRateMappingsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFInsRateMapping
        /// </summary>
        /// <param name="postRFInsRateMapping"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFInsRateMapping")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFInsRateMappingResponseDto>))]
        public async Task<IActionResult> AddRFInsRateMapping(RFInsRateMappingPostCommand postRFInsRateMapping)
        {
            var result = await _mediator.Send(postRFInsRateMapping);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFInsRateMappingByCode", new { InsRateId = result.Data.InsRateId }, result.Data);
        }

        /// <summary>
        /// Put Edit RFInsRateMapping
        /// </summary>
        /// <param name="InsRateId"></param>
        /// <param name="putRFInsRateMapping"></param>
        /// <returns></returns>
        [HttpPut("put/{InsRateId}", Name = "EditRFInsRateMapping")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFInsRateMappingResponseDto>))]
        public async Task<IActionResult> EditRFInsRateMapping([FromRoute] string InsRateId, [FromBody] RFInsRateMappingPutCommand putRFInsRateMapping)
        {
            putRFInsRateMapping.InsRateId = InsRateId;
            var result = await _mediator.Send(putRFInsRateMapping);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFInsRateMapping
        /// </summary>
        /// <param name="InsRateId"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{InsRateId}", Name = "DeleteRFInsRateMapping")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFInsRateMapping([FromRoute] string InsRateId, [FromBody] RFInsRateMappingDeleteCommand deleteCommand)
        {
            deleteCommand.InsRateId = InsRateId;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}