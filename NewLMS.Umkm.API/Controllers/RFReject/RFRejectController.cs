using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFRejects;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFRejects.Commands;
using NewLMS.UMKM.MediatR.Features.RFRejects.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RFReject
{
    public class RFRejectController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFReject
        /// </summary>
        /// <param name="mediator"></param>
        public RFRejectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFReject By RjCode
        /// </summary>
        /// <param name="RjCode"></param>
        /// <returns></returns>
        [HttpGet("get/{RjCode}", Name = "GetRFRejectBy")]
        [Produces("application/json", "application/xml", Type = typeof(RFRejectResponseDto))]
        public async Task<IActionResult> GetRFRejectBy(string RjCode)
        {
            var getGenderQuery = new RFRejectGetQuery { RjCode = RjCode };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFReject By Filter
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFRejectList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFRejectResponseDto>>))]
        public async Task<IActionResult> GetRFRejectList(RFRejectsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFReject
        /// </summary>
        /// <param name="postRFReject"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFReject")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFRejectResponseDto>))]
        public async Task<IActionResult> AddRFReject(RFRejectPostCommand postRFReject)
        {
            var result = await _mediator.Send(postRFReject);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFRejectByRjCode", new { id = result.Data.RjCode }, result.Data);
        }

        /// <summary>
        /// Put Edit RFReject
        /// </summary>
        /// <param name="RjCode"></param>
        /// <param name="putRFReject"></param>
        /// <returns></returns>
        [HttpPut("put/{RjCode}", Name = "EditRFReject")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFRejectResponseDto>))]
        public async Task<IActionResult> EditRFReject([FromRoute] string RjCode, [FromBody] RFRejectPutCommand putRFReject)
        {
            putRFReject.RjCode = RjCode;
            var result = await _mediator.Send(putRFReject);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFReject
        /// </summary>
        /// <param name="RjCode"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{RjCode}", Name = "DeleteRFReject")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFReject([FromRoute] string RjCode, [FromBody]RFRejectDeleteCommand deleteCommand)
        {
            deleteCommand.RjCode = RjCode;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}