using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFSCOTINGKATKEBUTUHANs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFSCOTINGKATKEBUTUHANs.Commands;
using NewLMS.UMKM.MediatR.Features.RFSCOTINGKATKEBUTUHANs.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RFSCOTINGKATKEBUTUHAN
{
    public class RFSCOTINGKATKEBUTUHANController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFSCOTINGKATKEBUTUHAN
        /// </summary>
        /// <param name="mediator"></param>
        public RFSCOTINGKATKEBUTUHANController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFSCOTINGKATKEBUTUHAN By SCO_CODE
        /// </summary>
        /// <param name="SCO_CODE"></param>
        /// <returns></returns>
        [HttpGet("get/{SCO_CODE}", Name = "GetRFSCOTINGKATKEBUTUHANByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFSCOTINGKATKEBUTUHANResponseDto))]
        public async Task<IActionResult> GetRFSCOTINGKATKEBUTUHANByCode(string SCO_CODE)
        {
            var getSCOQuery = new RFSCOTINGKATKEBUTUHANsGetByCodeQuery { SCO_CODE = SCO_CODE };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFSCOTINGKATKEBUTUHAN By SCO_CODE
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFSCOTINGKATKEBUTUHANList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFSCOTINGKATKEBUTUHANResponseDto>>))]
        public async Task<IActionResult> GetRFSCOTINGKATKEBUTUHANList(RFSCOTINGKATKEBUTUHANsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFSCOTINGKATKEBUTUHAN
        /// </summary>
        /// <param name="postRFSCOTINGKATKEBUTUHAN"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFSCOTINGKATKEBUTUHAN")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFSCOTINGKATKEBUTUHANResponseDto>))]
        public async Task<IActionResult> AddRFSCOTINGKATKEBUTUHAN(RFSCOTINGKATKEBUTUHANPostCommand postRFSCOTINGKATKEBUTUHAN)
        {
            var result = await _mediator.Send(postRFSCOTINGKATKEBUTUHAN);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFSCOTINGKATKEBUTUHANByCode", new { id = result.Data.SCO_CODE }, result.Data);
        }

        /// <summary>
        /// Put Edit RFSCOTINGKATKEBUTUHAN
        /// </summary>
        /// <param name="SCO_CODE"></param>
        /// <param name="putRFSCOTINGKATKEBUTUHAN"></param>
        /// <returns></returns>
        [HttpPut("put/{SCO_CODE}", Name = "EditRFSCOTINGKATKEBUTUHAN")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFSCOTINGKATKEBUTUHANResponseDto>))]
        public async Task<IActionResult> EditRFSCOTINGKATKEBUTUHAN([FromRoute] string SCO_CODE, [FromBody] RFSCOTINGKATKEBUTUHANPutCommand putRFSCOTINGKATKEBUTUHAN)
        {
            putRFSCOTINGKATKEBUTUHAN.SCO_CODE = SCO_CODE;
            var result = await _mediator.Send(putRFSCOTINGKATKEBUTUHAN);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFSCOTINGKATKEBUTUHAN
        /// </summary>
        /// <param name="SCO_CODE"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{SCO_CODE}", Name = "DeleteRFSCOTINGKATKEBUTUHAN")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFSCOTINGKATKEBUTUHAN([FromRoute] string SCO_CODE, [FromBody]RFSCOTINGKATKEBUTUHANDeleteCommand deleteCommand)
        {
            deleteCommand.SCO_CODE = SCO_CODE;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}