using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFSCOCARATRANSAKSIs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFSCOCARATRANSAKSIS.Commands;
using NewLMS.UMKM.MediatR.Features.RFSCOCARATRANSAKSIS.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RFSCOCARATRANSAKSI
{
    public class RFSCOCARATRANSAKSIController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RfOwnerCategory
        /// </summary>
        /// <param name="mediator"></param>
        public RFSCOCARATRANSAKSIController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFSCOCARATRANSAKSI By SCO_CODE
        /// </summary>
        /// <param name="SCO_CODE"></param>
        /// <returns></returns>
        [HttpGet("get/{SCO_CODE}", Name = "GetRFSCOCARATRANSAKSIBySCO_CODEQuery")]
        [Produces("application/json", "application/xml", Type = typeof(RFSCOCARATRANSAKSIResponseDto))]
        public async Task<IActionResult> GetRFSCOCARATRANSAKSIBySCO_CODEQuery(string SCO_CODE)
        {
            var query = new GetBySCO_CODERFSCOCARATRANSAKSIQuery { SCO_CODE = SCO_CODE };
            var result = await _mediator.Send(query);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFSCOCARATRANSAKSI
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFSCOCARATRANSAKSIList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFSCOCARATRANSAKSIResponseDto>>))]
        public async Task<IActionResult> GetRFSCOCARATRANSAKSIList(GetByRFSCOCARATRANSAKSIFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFSCOCARATRANSAKSI
        /// </summary>
        /// <param name="postRFSCOCARATRANSAKSI"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFSCOCARATRANSAKSI")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFSCOCARATRANSAKSIResponseDto>))]
        public async Task<IActionResult> AddRFSCOCARATRANSAKSI(RFSCOCARATRANSAKSISPostCommand postRFSCOCARATRANSAKSI)
        {
            var result = await _mediator.Send(postRFSCOCARATRANSAKSI);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFSCOCARATRANSAKSIBySCO_CODE", new { id = result.Data.SCO_CODE }, result.Data);
        }

        /// <summary>
        /// Put Edit RFSCOCARATRANSAKSI
        /// </summary>
        /// <param name="SCO_CODE"></param>
        /// <param name="putRFSCOCARATRANSAKSI"></param>
        /// <returns></returns>
        [HttpPut("put/{SCO_CODE}", Name = "EditRFSCOCARATRANSAKSI")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFSCOCARATRANSAKSIResponseDto>))]
        public async Task<IActionResult> EditRFSCOCARATRANSAKI([FromRoute] string SCO_CODE, [FromBody] RFSCOCARATRANSAKSIPutCommand putRFSCOCARATRANSAKSI)
        {
            putRFSCOCARATRANSAKSI.SCO_CODE = SCO_CODE;
            var result = await _mediator.Send(putRFSCOCARATRANSAKSI);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFSCOCARATRANSAKSI
        /// </summary>
        /// <param name="SCO_CODE"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{SCO_CODE}", Name = "DeleteRFSCOCARATRANSAKSI")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFSCOCARATRANSAKSI([FromRoute] string SCO_CODE, [FromBody] RFSCOCARATRANSAKSIDeleteCommand deleteCommand)

        {
            deleteCommand.SCO_CODE = SCO_CODE;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}