using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFMARITALs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFMARITALs.Commands;
using NewLMS.UMKM.MediatR.Features.RFMARITALs.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RFMARITAL
{
    public class RFMARITALController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFMARITAL
        /// </summary>
        /// <param name="mediator"></param>
        public RFMARITALController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFMARITAL By MR_CODE
        /// </summary>
        /// <param name="MR_CODE"></param>
        /// <returns></returns>
        [HttpGet("get/{MR_CODE}", Name = "GetRFMARITALByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFMARITALResponseDto))]
        public async Task<IActionResult> GetRFMARITALByCode(string MR_CODE)
        {
            var getSCOQuery = new GetByIdRFMARITALQuery { MR_CODE = MR_CODE };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFMARITAL By MR_CODE
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFMARITALList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFMARITALResponseDto>>))]
        public async Task<IActionResult> GetRFMARITALList(GetByRFMARITALFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFMARITAL
        /// </summary>
        /// <param name="postRFMARITAL"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFMARITAL")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFMARITALResponseDto>))]
        public async Task<IActionResult> AddRFMARITAL(RFMARITALSPostCommand postRFMARITAL)
        {
            var result = await _mediator.Send(postRFMARITAL);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFMARITALByCode", new { id = result.Data.MR_CODE }, result.Data);
        }

        /// <summary>
        /// Put Edit RFMARITAL
        /// </summary>
        /// <param name="MR_CODE"></param>
        /// <param name="putRFMARITAL"></param>
        /// <returns></returns>
        [HttpPut("put/{MR_CODE}", Name = "EditRFMARITAL")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFMARITALResponseDto>))]
        public async Task<IActionResult> EditRFMARITAL([FromRoute] string MR_CODE, [FromBody] RFMARITALPutCommand putRFMARITAL)
        {
            putRFMARITAL.MR_CODE = MR_CODE;
            var result = await _mediator.Send(putRFMARITAL);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFMARITAL
        /// </summary>
        /// <param name="MR_CODE"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{MR_CODE}", Name = "DeleteRFMARITAL")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFMARITAL([FromRoute] string MR_CODE, [FromBody]RFMARITALDeleteCommand deleteCommand)
        {
            deleteCommand.MR_CODE = MR_CODE;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}