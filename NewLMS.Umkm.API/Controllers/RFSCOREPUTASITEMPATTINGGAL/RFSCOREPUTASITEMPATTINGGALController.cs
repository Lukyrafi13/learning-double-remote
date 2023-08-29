using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RFSCOREPUTASITEMPATTINGGALs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFSCOREPUTASITEMPATTINGGALs.Commands;
using NewLMS.Umkm.MediatR.Features.RFSCOREPUTASITEMPATTINGGALs.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.RFSCOREPUTASITEMPATTINGGAL
{
    public class RFSCOREPUTASITEMPATTINGGALController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFSCOREPUTASITEMPATTINGGAL
        /// </summary>
        /// <param name="mediator"></param>
        public RFSCOREPUTASITEMPATTINGGALController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFSCOREPUTASITEMPATTINGGAL By SCO_CODE
        /// </summary>
        /// <param name="SCO_CODE"></param>
        /// <returns></returns>
        [HttpGet("get/{SCO_CODE}", Name = "GetRFSCOREPUTASITEMPATTINGGALByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFSCOREPUTASITEMPATTINGGALResponseDto))]
        public async Task<IActionResult> GetRFSCOREPUTASITEMPATTINGGALByCode(string SCO_CODE)
        {
            var getSCOQuery = new RFSCOREPUTASITEMPATTINGGALsGetByCodeQuery { SCO_CODE = SCO_CODE };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFSCOREPUTASITEMPATTINGGAL By SCO_CODE
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFSCOREPUTASITEMPATTINGGALList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFSCOREPUTASITEMPATTINGGALResponseDto>>))]
        public async Task<IActionResult> GetRFSCOREPUTASITEMPATTINGGALList(RFSCOREPUTASITEMPATTINGGALsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFSCOREPUTASITEMPATTINGGAL
        /// </summary>
        /// <param name="postRFSCOREPUTASITEMPATTINGGAL"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFSCOREPUTASITEMPATTINGGAL")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFSCOREPUTASITEMPATTINGGALResponseDto>))]
        public async Task<IActionResult> AddRFSCOREPUTASITEMPATTINGGAL(RFSCOREPUTASITEMPATTINGGALPostCommand postRFSCOREPUTASITEMPATTINGGAL)
        {
            var result = await _mediator.Send(postRFSCOREPUTASITEMPATTINGGAL);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFSCOREPUTASITEMPATTINGGALByCode", new { id = result.Data.SCO_CODE }, result.Data);
        }

        /// <summary>
        /// Put Edit RFSCOREPUTASITEMPATTINGGAL
        /// </summary>
        /// <param name="SCO_CODE"></param>
        /// <param name="putRFSCOREPUTASITEMPATTINGGAL"></param>
        /// <returns></returns>
        [HttpPut("put/{SCO_CODE}", Name = "EditRFSCOREPUTASITEMPATTINGGAL")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFSCOREPUTASITEMPATTINGGALResponseDto>))]
        public async Task<IActionResult> EditRFSCOREPUTASITEMPATTINGGAL([FromRoute] string SCO_CODE, [FromBody] RFSCOREPUTASITEMPATTINGGALPutCommand putRFSCOREPUTASITEMPATTINGGAL)
        {
            putRFSCOREPUTASITEMPATTINGGAL.SCO_CODE = SCO_CODE;
            var result = await _mediator.Send(putRFSCOREPUTASITEMPATTINGGAL);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFSCOREPUTASITEMPATTINGGAL
        /// </summary>
        /// <param name="SCO_CODE"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{SCO_CODE}", Name = "DeleteRFSCOREPUTASITEMPATTINGGAL")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFSCOREPUTASITEMPATTINGGAL([FromRoute] string SCO_CODE, [FromBody]RFSCOREPUTASITEMPATTINGGALDeleteCommand deleteCommand)
        {
            deleteCommand.SCO_CODE = SCO_CODE;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}