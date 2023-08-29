using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFSiklusUsahas;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFSiklusUsahas.Commands;
using NewLMS.UMKM.MediatR.Features.RFSiklusUsahas.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RFSiklusUsaha
{
    public class RFSiklusUsahaController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFSiklusUsaha
        /// </summary>
        /// <param name="mediator"></param>
        public RFSiklusUsahaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFSiklusUsaha By SiklusCode
        /// </summary>
        /// <param name="SiklusCode"></param>
        /// <returns></returns>
        [HttpGet("get/{SiklusCode}", Name = "GetRFSiklusUsahaBy")]
        [Produces("application/json", "application/xml", Type = typeof(RFSiklusUsahaResponseDto))]
        public async Task<IActionResult> GetRFSiklusUsahaBy(string SiklusCode)
        {
            var getGenderQuery = new RFSiklusUsahaGetQuery { SiklusCode = SiklusCode };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFSiklusUsaha By Filter
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFSiklusUsahaList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFSiklusUsahaResponseDto>>))]
        public async Task<IActionResult> GetRFSiklusUsahaList(RFSiklusUsahasGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFSiklusUsaha
        /// </summary>
        /// <param name="postRFSiklusUsaha"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFSiklusUsaha")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFSiklusUsahaResponseDto>))]
        public async Task<IActionResult> AddRFSiklusUsaha(RFSiklusUsahaPostCommand postRFSiklusUsaha)
        {
            var result = await _mediator.Send(postRFSiklusUsaha);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFSiklusUsahaBySiklusCode", new { id = result.Data.SiklusCode }, result.Data);
        }

        /// <summary>
        /// Put Edit RFSiklusUsaha
        /// </summary>
        /// <param name="SiklusCode"></param>
        /// <param name="putRFSiklusUsaha"></param>
        /// <returns></returns>
        [HttpPut("put/{SiklusCode}", Name = "EditRFSiklusUsaha")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFSiklusUsahaResponseDto>))]
        public async Task<IActionResult> EditRFSiklusUsaha([FromRoute] string SiklusCode, [FromBody] RFSiklusUsahaPutCommand putRFSiklusUsaha)
        {
            putRFSiklusUsaha.SiklusCode = SiklusCode;
            var result = await _mediator.Send(putRFSiklusUsaha);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFSiklusUsaha
        /// </summary>
        /// <param name="SiklusCode"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{SiklusCode}", Name = "DeleteRFSiklusUsaha")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFSiklusUsaha([FromRoute] string SiklusCode, [FromBody]RFSiklusUsahaDeleteCommand deleteCommand)
        {
            deleteCommand.SiklusCode = SiklusCode;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}