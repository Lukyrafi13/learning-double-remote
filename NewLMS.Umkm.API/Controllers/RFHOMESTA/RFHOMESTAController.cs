using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RFHOMESTAs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFHOMESTAs.Commands;
using NewLMS.Umkm.MediatR.Features.RFHOMESTAs.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.RFHOMESTA
{
    public class RFHOMESTAController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFHOMESTA
        /// </summary>
        /// <param name="mediator"></param>
        public RFHOMESTAController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFHOMESTA By HMSTA_CODE
        /// </summary>
        /// <param name="HMSTA_CODE"></param>
        /// <returns></returns>
        [HttpGet("get/{HMSTA_CODE}", Name = "GetRFHOMESTAByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFHOMESTAResponseDto))]
        public async Task<IActionResult> GetRFHOMESTAByCode(string HMSTA_CODE)
        {
            var getSCOQuery = new RFHOMESTAGetQuery { HMSTA_CODE = HMSTA_CODE };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFHOMESTA By HMSTA_CODE
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFHOMESTAList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFHOMESTAResponseDto>>))]
        public async Task<IActionResult> GetRFHOMESTAList(RFHOMESTAsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFHOMESTA
        /// </summary>
        /// <param name="postRFHOMESTA"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFHOMESTA")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFHOMESTAResponseDto>))]
        public async Task<IActionResult> AddRFHOMESTA(RFHOMESTAPostCommand postRFHOMESTA)
        {
            var result = await _mediator.Send(postRFHOMESTA);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFHOMESTAByCode", new { id = result.Data.HMSTA_CODE }, result.Data);
        }

        /// <summary>
        /// Put Edit RFHOMESTA
        /// </summary>
        /// <param name="HMSTA_CODE"></param>
        /// <param name="putRFHOMESTA"></param>
        /// <returns></returns>
        [HttpPut("put/{HMSTA_CODE}", Name = "EditRFHOMESTA")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFHOMESTAResponseDto>))]
        public async Task<IActionResult> EditRFHOMESTA([FromRoute] string HMSTA_CODE, [FromBody] RFHOMESTAPutCommand putRFHOMESTA)
        {
            putRFHOMESTA.HMSTA_CODE = HMSTA_CODE;
            var result = await _mediator.Send(putRFHOMESTA);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFHOMESTA
        /// </summary>
        /// <param name="HMSTA_CODE"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{HMSTA_CODE}", Name = "DeleteRFHOMESTA")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFHOMESTA([FromRoute] string HMSTA_CODE, [FromBody]RFHOMESTADeleteCommand deleteCommand)
        {
            deleteCommand.HMSTA_CODE = HMSTA_CODE;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}