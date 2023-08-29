using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFTenors;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFTenors.Commands;
using NewLMS.UMKM.MediatR.Features.RFTenors.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RFTenor
{
    public class RFTenorController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFTenor
        /// </summary>
        /// <param name="mediator"></param>
        public RFTenorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFTenor By TNCode
        /// </summary>
        /// <param name="TNCode"></param>
        /// <returns></returns>
        [HttpGet("get/{TNCode}", Name = "GetRFTenorByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFTenorResponseDto))]
        public async Task<IActionResult> GetRFTenorByCode(string TNCode)
        {
            var getSCOQuery = new RFTenorGetQuery { TNCode = TNCode };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFTenor By TNCode
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFTenorList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFTenorResponseDto>>))]
        public async Task<IActionResult> GetRFTenorList(RFTenorsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFTenor
        /// </summary>
        /// <param name="postRFTenor"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFTenor")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFTenorResponseDto>))]
        public async Task<IActionResult> AddRFTenor(RFTenorPostCommand postRFTenor)
        {
            var result = await _mediator.Send(postRFTenor);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFTenorByCode", new { TNCode = result.Data.TNCode }, result.Data);
        }

        /// <summary>
        /// Put Edit RFTenor
        /// </summary>
        /// <param name="TNCode"></param>
        /// <param name="putRFTenor"></param>
        /// <returns></returns>
        [HttpPut("put/{TNCode}", Name = "EditRFTenor")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFTenorResponseDto>))]
        public async Task<IActionResult> EditRFTenor([FromRoute] string TNCode, [FromBody] RFTenorPutCommand putRFTenor)
        {
            putRFTenor.TNCode = TNCode;
            var result = await _mediator.Send(putRFTenor);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFTenor
        /// </summary>
        /// <param name="TNCode"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{TNCode}", Name = "DeleteRFTenor")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFTenor([FromRoute] string TNCode, [FromBody]RFTenorDeleteCommand deleteCommand)
        {
            deleteCommand.TNCode = TNCode;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}