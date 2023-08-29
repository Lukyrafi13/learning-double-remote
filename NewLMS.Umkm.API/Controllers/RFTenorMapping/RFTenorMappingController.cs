using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RFTenorMappings;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFTenorMappings.Commands;
using NewLMS.Umkm.MediatR.Features.RFTenorMappings.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.RFTenorMapping
{
    public class RFTenorMappingController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFTenorMapping
        /// </summary>
        /// <param name="mediator"></param>
        public RFTenorMappingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFTenorMapping By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetRFTenorMappingByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFTenorMappingResponseDto))]
        public async Task<IActionResult> GetRFTenorMappingByCode(Guid Id)
        {
            var getSCOQuery = new RFTenorMappingGetQuery { Id = Id };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFTenorMapping
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFTenorMappingList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFTenorMappingResponseDto>>))]
        public async Task<IActionResult> GetRFTenorMappingList(RFTenorMappingsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFTenorMapping
        /// </summary>
        /// <param name="postRFTenorMapping"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFTenorMapping")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFTenorMappingResponseDto>))]
        public async Task<IActionResult> AddRFTenorMapping(RFTenorMappingPostCommand postRFTenorMapping)
        {
            var result = await _mediator.Send(postRFTenorMapping);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFTenorMappingByCode", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit RFTenorMapping
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putRFTenorMapping"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditRFTenorMapping")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFTenorMappingResponseDto>))]
        public async Task<IActionResult> EditRFTenorMapping([FromRoute] Guid Id, [FromBody] RFTenorMappingPutCommand putRFTenorMapping)
        {
            putRFTenorMapping.Id = Id;
            var result = await _mediator.Send(putRFTenorMapping);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFTenorMapping
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteRFTenorMapping")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFTenorMapping([FromRoute] Guid Id, [FromBody]RFTenorMappingDeleteCommand deleteCommand)
        {
            deleteCommand.Id = Id;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}