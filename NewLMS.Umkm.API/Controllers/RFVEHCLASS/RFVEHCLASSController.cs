using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RFVEHCLASSs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFVEHCLASSs.Commands;
using NewLMS.Umkm.MediatR.Features.RFVEHCLASSs.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.RFVEHCLASS
{
    public class RFVEHCLASSController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFVEHCLASS
        /// </summary>
        /// <param name="mediator"></param>
        public RFVEHCLASSController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFVEHCLASS By VCLS_CODE
        /// </summary>
        /// <param name="VCLS_CODE"></param>
        /// <returns></returns>
        [HttpGet("get/{VCLS_CODE}", Name = "GetRFVEHCLASSByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFVEHCLASSResponseDto))]
        public async Task<IActionResult> GetRFVEHCLASSByCode(string VCLS_CODE)
        {
            var getSCOQuery = new RFVEHCLASSGetQuery { VCLS_CODE = VCLS_CODE };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFVEHCLASS By VCLS_CODE
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFVEHCLASSList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFVEHCLASSResponseDto>>))]
        public async Task<IActionResult> GetRFVEHCLASSList(RFVEHCLASSsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFVEHCLASS
        /// </summary>
        /// <param name="postRFVEHCLASS"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFVEHCLASS")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFVEHCLASSResponseDto>))]
        public async Task<IActionResult> AddRFVEHCLASS(RFVEHCLASSPostCommand postRFVEHCLASS)
        {
            var result = await _mediator.Send(postRFVEHCLASS);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFVEHCLASSByCode", new { id = result.Data.VCLS_CODE }, result.Data);
        }

        /// <summary>
        /// Put Edit RFVEHCLASS
        /// </summary>
        /// <param name="VCLS_CODE"></param>
        /// <param name="putRFVEHCLASS"></param>
        /// <returns></returns>
        [HttpPut("put/{VCLS_CODE}", Name = "EditRFVEHCLASS")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFVEHCLASSResponseDto>))]
        public async Task<IActionResult> EditRFVEHCLASS([FromRoute] string VCLS_CODE, [FromBody] RFVEHCLASSPutCommand putRFVEHCLASS)
        {
            putRFVEHCLASS.VCLS_CODE = VCLS_CODE;
            var result = await _mediator.Send(putRFVEHCLASS);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFVEHCLASS
        /// </summary>
        /// <param name="VCLS_CODE"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{VCLS_CODE}", Name = "DeleteRFVEHCLASS")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFVEHCLASS([FromRoute] string VCLS_CODE, [FromBody]RFVEHCLASSDeleteCommand deleteCommand)
        {
            deleteCommand.VCLS_CODE = VCLS_CODE;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}