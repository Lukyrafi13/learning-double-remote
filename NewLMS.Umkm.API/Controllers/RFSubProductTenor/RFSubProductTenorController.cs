using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFSubProductTenors;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFSubProductTenors.Commands;
using NewLMS.UMKM.MediatR.Features.RFSubProductTenors.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RFSubProductTenor
{
    public class RFSubProductTenorController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFSubProductTenor
        /// </summary>
        /// <param name="mediator"></param>
        public RFSubProductTenorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFSubProductTenor By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetRFSubProductTenorByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFSubProductTenorResponseDto))]
        public async Task<IActionResult> GetRFSubProductTenorByCode(Guid Id)
        {
            var getSCOQuery = new RFSubProductTenorGetQuery { Id = Id };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFSubProductTenor By SubProductId
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("get/detail/{SubProductId}", Name = "GetRFSubProductTenorBySubProductId")]
        [Produces("application/json", "application/xml", Type = typeof(RFSubProductTenorDetailResponseDto))]
        public async Task<IActionResult> GetRFSubProductTenorBySubProductId([FromRoute] RFSubProductTenorGetSubProductIdQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Get RFSubProductTenor
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFSubProductTenorList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFSubProductTenorResponseDto>>))]
        public async Task<IActionResult> GetRFSubProductTenorList(RFSubProductTenorsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFSubProductTenor
        /// </summary>
        /// <param name="postRFSubProductTenor"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFSubProductTenor")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFSubProductTenorResponseDto>))]
        public async Task<IActionResult> AddRFSubProductTenor(RFSubProductTenorPostCommand postRFSubProductTenor)
        {
            var result = await _mediator.Send(postRFSubProductTenor);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFSubProductTenorByCode", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit RFSubProductTenor
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putRFSubProductTenor"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditRFSubProductTenor")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFSubProductTenorResponseDto>))]
        public async Task<IActionResult> EditRFSubProductTenor([FromRoute] Guid Id, [FromBody] RFSubProductTenorPutCommand putRFSubProductTenor)
        {
            putRFSubProductTenor.Id = Id;
            var result = await _mediator.Send(putRFSubProductTenor);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFSubProductTenor
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteRFSubProductTenor")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFSubProductTenor([FromRoute] Guid Id, [FromBody] RFSubProductTenorDeleteCommand deleteCommand)
        {
            deleteCommand.Id = Id;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}