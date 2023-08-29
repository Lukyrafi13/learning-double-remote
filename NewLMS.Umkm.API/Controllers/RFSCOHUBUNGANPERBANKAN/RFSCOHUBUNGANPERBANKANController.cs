using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFSCOHUBUNGANPERBANKANs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFSCOHUBUNGANPERBANKANs.Commands;
using NewLMS.UMKM.MediatR.Features.RFSCOHUBUNGANPERBANKANs.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RFSCOHUBUNGANPERBANKAN
{
    public class RFSCOHUBUNGANPERBANKANController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFSCOHUBUNGANPERBANKAN
        /// </summary>
        /// <param name="mediator"></param>
        public RFSCOHUBUNGANPERBANKANController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFSCOHUBUNGANPERBANKAN By SCO_CODE
        /// </summary>
        /// <param name="SCO_CODE"></param>
        /// <returns></returns>
        [HttpGet("get/{SCO_CODE}", Name = "GetRFSCOHUBUNGANPERBANKANByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFSCOHUBUNGANPERBANKANResponseDto))]
        public async Task<IActionResult> GetRFSCOHUBUNGANPERBANKANByCode(string SCO_CODE)
        {
            var getSCOQuery = new RFSCOHUBUNGANPERBANKANsGetByCodeQuery { SCO_CODE = SCO_CODE };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFSCOHUBUNGANPERBANKAN By SCO_CODE
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFSCOHUBUNGANPERBANKANList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFSCOHUBUNGANPERBANKANResponseDto>>))]
        public async Task<IActionResult> GetRFSCOHUBUNGANPERBANKANList(RFSCOHUBUNGANPERBANKANsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFSCOHUBUNGANPERBANKAN
        /// </summary>
        /// <param name="postRFSCOHUBUNGANPERBANKAN"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFSCOHUBUNGANPERBANKAN")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFSCOHUBUNGANPERBANKANResponseDto>))]
        public async Task<IActionResult> AddRFSCOHUBUNGANPERBANKAN(RFSCOHUBUNGANPERBANKANPostCommand postRFSCOHUBUNGANPERBANKAN)
        {
            var result = await _mediator.Send(postRFSCOHUBUNGANPERBANKAN);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFSCOHUBUNGANPERBANKANByCode", new { id = result.Data.SCO_CODE }, result.Data);
        }

        /// <summary>
        /// Put Edit RFSCOHUBUNGANPERBANKAN
        /// </summary>
        /// <param name="SCO_CODE"></param>
        /// <param name="putRFSCOHUBUNGANPERBANKAN"></param>
        /// <returns></returns>
        [HttpPut("put/{SCO_CODE}", Name = "EditRFSCOHUBUNGANPERBANKAN")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFSCOHUBUNGANPERBANKANResponseDto>))]
        public async Task<IActionResult> EditRFSCOHUBUNGANPERBANKAN([FromRoute] string SCO_CODE, [FromBody] RFSCOHUBUNGANPERBANKANPutCommand putRFSCOHUBUNGANPERBANKAN)
        {
            putRFSCOHUBUNGANPERBANKAN.SCO_CODE = SCO_CODE;
            var result = await _mediator.Send(putRFSCOHUBUNGANPERBANKAN);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFSCOHUBUNGANPERBANKAN
        /// </summary>
        /// <param name="SCO_CODE"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{SCO_CODE}", Name = "DeleteRFSCOHUBUNGANPERBANKAN")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFSCOHUBUNGANPERBANKAN([FromRoute] string SCO_CODE, [FromBody]RFSCOHUBUNGANPERBANKANDeleteCommand deleteCommand)
        {
            deleteCommand.SCO_CODE = SCO_CODE;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}