using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RFSCOLOKTEMPATUSAHAs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFSCOLOKTEMPATUSAHAs.Commands;
using NewLMS.Umkm.MediatR.Features.RFSCOLOKTEMPATUSAHAs.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.RFSCOLOKTEMPATUSAHA
{
    public class RFSCOLOKTEMPATUSAHAController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFSCOLOKTEMPATUSAHA
        /// </summary>
        /// <param name="mediator"></param>
        public RFSCOLOKTEMPATUSAHAController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFSCOLOKTEMPATUSAHA By SCO_CODE
        /// </summary>
        /// <param name="SCO_CODE"></param>
        /// <returns></returns>
        [HttpGet("get/{SCO_CODE}", Name = "GetRFSCOLOKTEMPATUSAHAByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFSCOLOKTEMPATUSAHAResponseDto))]
        public async Task<IActionResult> GetRFSCOLOKTEMPATUSAHAByCode(string SCO_CODE)
        {
            var getSCOQuery = new RFSCOLOKTEMPATUSAHAsGetByCodeQuery { SCO_CODE = SCO_CODE };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFSCOLOKTEMPATUSAHA By SCO_CODE
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFSCOLOKTEMPATUSAHAList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFSCOLOKTEMPATUSAHAResponseDto>>))]
        public async Task<IActionResult> GetRFSCOLOKTEMPATUSAHAList(RFSCOLOKTEMPATUSAHAsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFSCOLOKTEMPATUSAHA
        /// </summary>
        /// <param name="postRFSCOLOKTEMPATUSAHA"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFSCOLOKTEMPATUSAHA")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFSCOLOKTEMPATUSAHAResponseDto>))]
        public async Task<IActionResult> AddRFSCOLOKTEMPATUSAHA(RFSCOLOKTEMPATUSAHAPostCommand postRFSCOLOKTEMPATUSAHA)
        {
            var result = await _mediator.Send(postRFSCOLOKTEMPATUSAHA);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFSCOLOKTEMPATUSAHAByCode", new { id = result.Data.SCO_CODE }, result.Data);
        }

        /// <summary>
        /// Put Edit RFSCOLOKTEMPATUSAHA
        /// </summary>
        /// <param name="SCO_CODE"></param>
        /// <param name="putRFSCOLOKTEMPATUSAHA"></param>
        /// <returns></returns>
        [HttpPut("put/{SCO_CODE}", Name = "EditRFSCOLOKTEMPATUSAHA")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFSCOLOKTEMPATUSAHAResponseDto>))]
        public async Task<IActionResult> EditRFSCOLOKTEMPATUSAHA([FromRoute] string SCO_CODE, [FromBody] RFSCOLOKTEMPATUSAHAPutCommand putRFSCOLOKTEMPATUSAHA)
        {
            putRFSCOLOKTEMPATUSAHA.SCO_CODE = SCO_CODE;
            var result = await _mediator.Send(putRFSCOLOKTEMPATUSAHA);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFSCOLOKTEMPATUSAHA
        /// </summary>
        /// <param name="SCO_CODE"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{SCO_CODE}", Name = "DeleteRFSCOLOKTEMPATUSAHA")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFSCOLOKTEMPATUSAHA([FromRoute] string SCO_CODE, [FromBody]RFSCOLOKTEMPATUSAHADeleteCommand deleteCommand)
        {
            deleteCommand.SCO_CODE = SCO_CODE;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}