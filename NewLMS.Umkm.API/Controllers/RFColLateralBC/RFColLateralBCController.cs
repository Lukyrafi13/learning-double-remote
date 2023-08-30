using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFColLateralBCs.Commands;
using NewLMS.UMKM.MediatR.Features.RFColLateralBCs.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Data.Dto.RFColLateralBCs;

namespace NewLMS.UMKM.API.Controllers.RFColLateralBC
{
    public class RFColLateralBCController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFColLateralBC
        /// </summary>
        /// <param name="mediator"></param>
        public RFColLateralBCController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFColLateralBC By ColCode
        /// </summary>
        /// <param name="ColCode"></param>
        /// <returns></returns>
        [HttpGet("get/{ColCode}", Name = "GetRFColLateralBCByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFColLateralBCResponseDto))]
        public async Task<IActionResult> GetRFColLateralBCByCode(string ColCode)
        {
            var getSCOQuery = new RFColLateralBCsGetByCodeQuery { ColCode = ColCode };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFColLateralBC By ColCode
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFColLateralBCList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFColLateralBCResponseDto>>))]
        public async Task<IActionResult> GetRFColLateralBCList(RFColLateralBCsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFColLateralBC
        /// </summary>
        /// <param name="postRFColLateralBC"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFColLateralBC")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFColLateralBCResponseDto>))]
        public async Task<IActionResult> AddRFColLateralBC(RFColLateralBCPostCommand postRFColLateralBC)
        {
            var result = await _mediator.Send(postRFColLateralBC);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFColLateralBCByCode", new { id = result.Data.ColCode }, result.Data);
        }

        /// <summary>
        /// Put Edit RFColLateralBC
        /// </summary>
        /// <param name="ColCode"></param>
        /// <param name="putRFColLateralBC"></param>
        /// <returns></returns>
        [HttpPut("put/{ColCode}", Name = "EditRFColLateralBC")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFColLateralBCResponseDto>))]
        public async Task<IActionResult> EditRFColLateralBC([FromRoute] string ColCode, [FromBody] RFColLateralBCPutCommand putRFColLateralBC)
        {
            putRFColLateralBC.ColCode = ColCode;
            var result = await _mediator.Send(putRFColLateralBC);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFColLateralBC
        /// </summary>
        /// <param name="ColCode"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{ColCode}", Name = "DeleteRFColLateralBC")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFColLateralBC([FromRoute] string ColCode, [FromBody]RFColLateralBCDeleteCommand deleteCommand)
        {
            deleteCommand.ColCode = ColCode;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}