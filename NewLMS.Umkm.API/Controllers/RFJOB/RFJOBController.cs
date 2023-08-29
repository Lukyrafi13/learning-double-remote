using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RFJOBs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFJOBs.Commands;
using NewLMS.Umkm.MediatR.Features.RFJOBs.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.RFJOB
{
    public class RFJOBController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFJOB
        /// </summary>
        /// <param name="mediator"></param>
        public RFJOBController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFJOB By JOB_CODE
        /// </summary>
        /// <param name="JOB_CODE"></param>
        /// <returns></returns>
        [HttpGet("get/{JOB_CODE}", Name = "GetRFJOBByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFJOBResponseDto))]
        public async Task<IActionResult> GetRFJOBByCode(string JOB_CODE)
        {
            var getSCOQuery = new GetByIdRFJOBQuery { JOB_CODE = JOB_CODE };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFJOB By JOB_CODE
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFJOBList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFJOBResponseDto>>))]
        public async Task<IActionResult> GetRFJOBList(GetByRFJOBFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFJOB
        /// </summary>
        /// <param name="postRFJOB"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFJOB")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFJOBResponseDto>))]
        public async Task<IActionResult> AddRFJOB(RFJOBSPostCommand postRFJOB)
        {
            var result = await _mediator.Send(postRFJOB);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFJOBByCode", new { id = result.Data.JOB_CODE }, result.Data);
        }

        /// <summary>
        /// Put Edit RFJOB
        /// </summary>
        /// <param name="JOB_CODE"></param>
        /// <param name="putRFJOB"></param>
        /// <returns></returns>
        [HttpPut("put/{JOB_CODE}", Name = "EditRFJOB")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFJOBResponseDto>))]
        public async Task<IActionResult> EditRFJOB([FromRoute] string JOB_CODE, [FromBody] RFJOBPutCommand putRFJOB)
        {
            putRFJOB.JOB_CODE = JOB_CODE;
            var result = await _mediator.Send(putRFJOB);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFJOB
        /// </summary>
        /// <param name="JOB_CODE"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{JOB_CODE}", Name = "DeleteRFJOB")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFJOB([FromRoute] string JOB_CODE, [FromBody]RFJOBDeleteCommand deleteCommand)
        {
            deleteCommand.JOB_CODE = JOB_CODE;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}