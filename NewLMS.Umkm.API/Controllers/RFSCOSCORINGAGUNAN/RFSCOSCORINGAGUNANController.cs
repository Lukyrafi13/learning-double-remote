using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFSCOSCORINGAGUNANs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFSCOSCORINGAGUNANs.Commands;
using NewLMS.UMKM.MediatR.Features.RFSCOSCORINGAGUNANs.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RFSCOSCORINGAGUNAN
{
    public class RFSCOSCORINGAGUNANController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFSCOSCORINGAGUNAN
        /// </summary>
        /// <param name="mediator"></param>
        public RFSCOSCORINGAGUNANController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFSCOSCORINGAGUNAN By SCO_CODE
        /// </summary>
        /// <param name="SCO_CODE"></param>
        /// <returns></returns>
        [HttpGet("get/{SCO_CODE}", Name = "GetRFSCOSCORINGAGUNANByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFSCOSCORINGAGUNANResponseDto))]
        public async Task<IActionResult> GetRFSCOSCORINGAGUNANByCode(string SCO_CODE)
        {
            var getSCOQuery = new RFSCOSCORINGAGUNANsGetByCodeQuery { SCO_CODE = SCO_CODE };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFSCOSCORINGAGUNAN By SCO_CODE
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFSCOSCORINGAGUNANList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFSCOSCORINGAGUNANResponseDto>>))]
        public async Task<IActionResult> GetRFSCOSCORINGAGUNANList(RFSCOSCORINGAGUNANsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFSCOSCORINGAGUNAN
        /// </summary>
        /// <param name="postRFSCOSCORINGAGUNAN"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFSCOSCORINGAGUNAN")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFSCOSCORINGAGUNANResponseDto>))]
        public async Task<IActionResult> AddRFSCOSCORINGAGUNAN(RFSCOSCORINGAGUNANPostCommand postRFSCOSCORINGAGUNAN)
        {
            var result = await _mediator.Send(postRFSCOSCORINGAGUNAN);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFSCOSCORINGAGUNANByCode", new { id = result.Data.SCO_CODE }, result.Data);
        }

        /// <summary>
        /// Put Edit RFSCOSCORINGAGUNAN
        /// </summary>
        /// <param name="SCO_CODE"></param>
        /// <param name="putRFSCOSCORINGAGUNAN"></param>
        /// <returns></returns>
        [HttpPut("put/{SCO_CODE}", Name = "EditRFSCOSCORINGAGUNAN")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFSCOSCORINGAGUNANResponseDto>))]
        public async Task<IActionResult> EditRFSCOSCORINGAGUNAN([FromRoute] string SCO_CODE, [FromBody] RFSCOSCORINGAGUNANPutCommand putRFSCOSCORINGAGUNAN)
        {
            putRFSCOSCORINGAGUNAN.SCO_CODE = SCO_CODE;
            var result = await _mediator.Send(putRFSCOSCORINGAGUNAN);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFSCOSCORINGAGUNAN
        /// </summary>
        /// <param name="SCO_CODE"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{SCO_CODE}", Name = "DeleteRFSCOSCORINGAGUNAN")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFSCOSCORINGAGUNAN([FromRoute] string SCO_CODE, [FromBody]RFSCOSCORINGAGUNANDeleteCommand deleteCommand)
        {
            deleteCommand.SCO_CODE = SCO_CODE;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}