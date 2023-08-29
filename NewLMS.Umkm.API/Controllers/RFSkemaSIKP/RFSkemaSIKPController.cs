using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFSkemaSIKPs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFSkemaSIKPs.Commands;
using NewLMS.UMKM.MediatR.Features.RFSkemaSIKPs.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RFSkemaSIKP
{
    public class RFSkemaSIKPController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFSkemaSIKP
        /// </summary>
        /// <param name="mediator"></param>
        public RFSkemaSIKPController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFSkemaSIKP By Id
        /// </summary>
        /// <param name="SkemaCode"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetRFSkemaSIKPById")]
        [Produces("application/json", "application/xml", Type = typeof(RFSkemaSIKPResponseDto))]
        public async Task<IActionResult> GetRFSkemaSIKPById(string SkemaCode)
        {
            var getGenderQuery = new RFSkemaSIKPGetQuery { SkemaCode = SkemaCode };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFSkemaSIKP
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFSkemaSIKPList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFSkemaSIKPResponseDto>>))]
        public async Task<IActionResult> GetRFSkemaSIKPList(RFSkemaSIKPsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFSkemaSIKP
        /// </summary>
        /// <param name="postRFSkemaSIKP"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFSkemaSIKP")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFSkemaSIKPResponseDto>))]
        public async Task<IActionResult> AddRFSkemaSIKP(RFSkemaSIKPPostCommand postRFSkemaSIKP)
        {
            var result = await _mediator.Send(postRFSkemaSIKP);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFSkemaSIKPById", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit RFSkemaSIKP
        /// </summary>
        /// <param name="SkemaCode"></param>
        /// <param name="putRFSkemaSIKP"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditRFSkemaSIKP")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFSkemaSIKPResponseDto>))]
        public async Task<IActionResult> EditRFSkemaSIKP([FromRoute] string SkemaCode, [FromBody] RFSkemaSIKPPutCommand putRFSkemaSIKP)
        {
            putRFSkemaSIKP.SkemaCode = SkemaCode;
            var result = await _mediator.Send(putRFSkemaSIKP);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFSkemaSIKP
        /// </summary>
        /// <param name="SkemaCode"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteRFSkemaSIKP")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFSkemaSIKP([FromRoute] string SkemaCode, [FromBody] RFSkemaSIKPDeleteCommand deleteCommand)
        {
            deleteCommand.SkemaCode = SkemaCode;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}