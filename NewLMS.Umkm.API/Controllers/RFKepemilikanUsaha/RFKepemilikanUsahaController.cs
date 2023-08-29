using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFKepemilikanUsahas;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFKepemilikanUsahas.Commands;
using NewLMS.UMKM.MediatR.Features.RFKepemilikanUsahas.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RFKepemilikanUsaha
{
    public class RFKepemilikanUsahaController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFKepemilikanUsaha
        /// </summary>
        /// <param name="mediator"></param>
        public RFKepemilikanUsahaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFKepemilikanUsaha By KepemilikanUsahaId
        /// </summary>
        /// <param name="KepemilikanUsahaId"></param>
        /// <returns></returns>
        [HttpGet("get/{KepemilikanUsahaId}", Name = "GetRFKepemilikanUsahaBy")]
        [Produces("application/json", "application/xml", Type = typeof(RFKepemilikanUsahaResponseDto))]
        public async Task<IActionResult> GetRFKepemilikanUsahaBy(string KepemilikanUsahaId)
        {
            var getGenderQuery = new RFKepemilikanUsahaGetQuery { KepemilikanUsahaId = KepemilikanUsahaId };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFKepemilikanUsaha By Filter
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFKepemilikanUsahaList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFKepemilikanUsahaResponseDto>>))]
        public async Task<IActionResult> GetRFKepemilikanUsahaList(RFKepemilikanUsahasGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFKepemilikanUsaha
        /// </summary>
        /// <param name="postRFKepemilikanUsaha"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFKepemilikanUsaha")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFKepemilikanUsahaResponseDto>))]
        public async Task<IActionResult> AddRFKepemilikanUsaha(RFKepemilikanUsahaPostCommand postRFKepemilikanUsaha)
        {
            var result = await _mediator.Send(postRFKepemilikanUsaha);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFKepemilikanUsahaByKepemilikanUsahaId", new { id = result.Data.KepemilikanUsahaId }, result.Data);
        }

        /// <summary>
        /// Put Edit RFKepemilikanUsaha
        /// </summary>
        /// <param name="KepemilikanUsahaId"></param>
        /// <param name="putRFKepemilikanUsaha"></param>
        /// <returns></returns>
        [HttpPut("put/{KepemilikanUsahaId}", Name = "EditRFKepemilikanUsaha")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFKepemilikanUsahaResponseDto>))]
        public async Task<IActionResult> EditRFKepemilikanUsaha([FromRoute] string KepemilikanUsahaId, [FromBody] RFKepemilikanUsahaPutCommand putRFKepemilikanUsaha)
        {
            putRFKepemilikanUsaha.KepemilikanUsahaId = KepemilikanUsahaId;
            var result = await _mediator.Send(putRFKepemilikanUsaha);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFKepemilikanUsaha
        /// </summary>
        /// <param name="KepemilikanUsahaId"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{KepemilikanUsahaId}", Name = "DeleteRFKepemilikanUsaha")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFKepemilikanUsaha([FromRoute] string KepemilikanUsahaId, [FromBody]RFKepemilikanUsahaDeleteCommand deleteCommand)
        {
            deleteCommand.KepemilikanUsahaId = KepemilikanUsahaId;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}