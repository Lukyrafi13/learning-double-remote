using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFSCOMUTASIPERBULANs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFSCOMUTASIPERBULANs.Commands;
using NewLMS.UMKM.MediatR.Features.RFSCOMUTASIPERBULANs.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RFSCOMUTASIPERBULAN
{
    public class RFSCOMUTASIPERBULANController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFSCOMUTASIPERBULAN
        /// </summary>
        /// <param name="mediator"></param>
        public RFSCOMUTASIPERBULANController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFSCOMUTASIPERBULAN By SCO_CODE
        /// </summary>
        /// <param name="SCO_CODE"></param>
        /// <returns></returns>
        [HttpGet("get/{SCO_CODE}", Name = "GetRFSCOMUTASIPERBULANByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFSCOMUTASIPERBULANResponseDto))]
        public async Task<IActionResult> GetRFSCOMUTASIPERBULANByCode(string SCO_CODE)
        {
            var getSCOQuery = new RFSCOMUTASIPERBULANsGetByCodeQuery { SCO_CODE = SCO_CODE };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFSCOMUTASIPERBULAN By SCO_CODE
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFSCOMUTASIPERBULANList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFSCOMUTASIPERBULANResponseDto>>))]
        public async Task<IActionResult> GetRFSCOMUTASIPERBULANList(RFSCOMUTASIPERBULANsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFSCOMUTASIPERBULAN
        /// </summary>
        /// <param name="postRFSCOMUTASIPERBULAN"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFSCOMUTASIPERBULAN")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFSCOMUTASIPERBULANResponseDto>))]
        public async Task<IActionResult> AddRFSCOMUTASIPERBULAN(RFSCOMUTASIPERBULANPostCommand postRFSCOMUTASIPERBULAN)
        {
            var result = await _mediator.Send(postRFSCOMUTASIPERBULAN);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFSCOMUTASIPERBULANByCode", new { id = result.Data.SCO_CODE }, result.Data);
        }

        /// <summary>
        /// Put Edit RFSCOMUTASIPERBULAN
        /// </summary>
        /// <param name="SCO_CODE"></param>
        /// <param name="putRFSCOMUTASIPERBULAN"></param>
        /// <returns></returns>
        [HttpPut("put/{SCO_CODE}", Name = "EditRFSCOMUTASIPERBULAN")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFSCOMUTASIPERBULANResponseDto>))]
        public async Task<IActionResult> EditRFSCOMUTASIPERBULAN([FromRoute] string SCO_CODE, [FromBody] RFSCOMUTASIPERBULANPutCommand putRFSCOMUTASIPERBULAN)
        {
            putRFSCOMUTASIPERBULAN.SCO_CODE = SCO_CODE;
            var result = await _mediator.Send(putRFSCOMUTASIPERBULAN);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFSCOMUTASIPERBULAN
        /// </summary>
        /// <param name="SCO_CODE"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{SCO_CODE}", Name = "DeleteRFSCOMUTASIPERBULAN")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFSCOMUTASIPERBULAN([FromRoute] string SCO_CODE, [FromBody]RFSCOMUTASIPERBULANDeleteCommand deleteCommand)
        {
            deleteCommand.SCO_CODE = SCO_CODE;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}