using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFSCOHUTANGPIHAKLAINs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFSCOHUTANGPIHAKLAINs.Commands;
using NewLMS.UMKM.MediatR.Features.RFSCOHUTANGPIHAKLAINs.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RFSCOHUTANGPIHAKLAIN
{
    public class RFSCOHUTANGPIHAKLAINController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFSCOHUTANGPIHAKLAIN
        /// </summary>
        /// <param name="mediator"></param>
        public RFSCOHUTANGPIHAKLAINController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFSCOHUTANGPIHAKLAIN By SCO_CODE
        /// </summary>
        /// <param name="SCO_CODE"></param>
        /// <returns></returns>
        [HttpGet("get/{SCO_CODE}", Name = "GetRFSCOHUTANGPIHAKLAINByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFSCOHUTANGPIHAKLAINResponseDto))]
        public async Task<IActionResult> GetRFSCOHUTANGPIHAKLAINByCode(string SCO_CODE)
        {
            var getSCOQuery = new RFSCOHUTANGPIHAKLAINsGetByCodeQuery { SCO_CODE = SCO_CODE };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFSCOHUTANGPIHAKLAIN By SCO_CODE
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFSCOHUTANGPIHAKLAINList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFSCOHUTANGPIHAKLAINResponseDto>>))]
        public async Task<IActionResult> GetRFSCOHUTANGPIHAKLAINList(RFSCOHUTANGPIHAKLAINsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFSCOHUTANGPIHAKLAIN
        /// </summary>
        /// <param name="postRFSCOHUTANGPIHAKLAIN"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFSCOHUTANGPIHAKLAIN")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFSCOHUTANGPIHAKLAINResponseDto>))]
        public async Task<IActionResult> AddRFSCOHUTANGPIHAKLAIN(RFSCOHUTANGPIHAKLAINPostCommand postRFSCOHUTANGPIHAKLAIN)
        {
            var result = await _mediator.Send(postRFSCOHUTANGPIHAKLAIN);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFSCOHUTANGPIHAKLAINByCode", new { id = result.Data.SCO_CODE }, result.Data);
        }

        /// <summary>
        /// Put Edit RFSCOHUTANGPIHAKLAIN
        /// </summary>
        /// <param name="SCO_CODE"></param>
        /// <param name="putRFSCOHUTANGPIHAKLAIN"></param>
        /// <returns></returns>
        [HttpPut("put/{SCO_CODE}", Name = "EditRFSCOHUTANGPIHAKLAIN")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFSCOHUTANGPIHAKLAINResponseDto>))]
        public async Task<IActionResult> EditRFSCOHUTANGPIHAKLAIN([FromRoute] string SCO_CODE, [FromBody] RFSCOHUTANGPIHAKLAINPutCommand putRFSCOHUTANGPIHAKLAIN)
        {
            putRFSCOHUTANGPIHAKLAIN.SCO_CODE = SCO_CODE;
            var result = await _mediator.Send(putRFSCOHUTANGPIHAKLAIN);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFSCOHUTANGPIHAKLAIN
        /// </summary>
        /// <param name="SCO_CODE"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{SCO_CODE}", Name = "DeleteRFSCOHUTANGPIHAKLAIN")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFSCOHUTANGPIHAKLAIN([FromRoute] string SCO_CODE, [FromBody]RFSCOHUTANGPIHAKLAINDeleteCommand deleteCommand)
        {
            deleteCommand.SCO_CODE = SCO_CODE;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}