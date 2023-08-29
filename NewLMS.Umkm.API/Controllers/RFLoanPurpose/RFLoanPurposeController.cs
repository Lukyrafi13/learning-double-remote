using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RFLoanPurposes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFLoanPurposes.Commands;
using NewLMS.Umkm.MediatR.Features.RFLoanPurposes.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.RFLoanPurpose
{
    public class RFLoanPurposeController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFLoanPurpose
        /// </summary>
        /// <param name="mediator"></param>
        public RFLoanPurposeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFLoanPurpose By LP_CODE
        /// </summary>
        /// <param name="LP_CODE"></param>
        /// <returns></returns>
        [HttpGet("get/{LP_CODE}", Name = "GetRFLoanPurposeByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFLoanPurposeResponseDto))]
        public async Task<IActionResult> GetRFLoanPurposeByCode(string LP_CODE)
        {
            var getSCOQuery = new RFLoanPurposeGetQuery { LP_CODE = LP_CODE };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFLoanPurpose By LP_CODE
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFLoanPurposeList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFLoanPurposeResponseDto>>))]
        public async Task<IActionResult> GetRFLoanPurposeList(RFLoanPurposesGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFLoanPurpose
        /// </summary>
        /// <param name="postRFLoanPurpose"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFLoanPurpose")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFLoanPurposeResponseDto>))]
        public async Task<IActionResult> AddRFLoanPurpose(RFLoanPurposePostCommand postRFLoanPurpose)
        {
            var result = await _mediator.Send(postRFLoanPurpose);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFLoanPurposeByCode", new { id = result.Data.LP_CODE }, result.Data);
        }

        /// <summary>
        /// Put Edit RFLoanPurpose
        /// </summary>
        /// <param name="LP_CODE"></param>
        /// <param name="putRFLoanPurpose"></param>
        /// <returns></returns>
        [HttpPut("put/{LP_CODE}", Name = "EditRFLoanPurpose")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFLoanPurposeResponseDto>))]
        public async Task<IActionResult> EditRFLoanPurpose([FromRoute] string LP_CODE, [FromBody] RFLoanPurposePutCommand putRFLoanPurpose)
        {
            putRFLoanPurpose.LP_CODE = LP_CODE;
            var result = await _mediator.Send(putRFLoanPurpose);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFLoanPurpose
        /// </summary>
        /// <param name="LP_CODE"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{LP_CODE}", Name = "DeleteRFLoanPurpose")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFLoanPurpose([FromRoute] string LP_CODE, [FromBody]RFLoanPurposeDeleteCommand deleteCommand)
        {
            deleteCommand.LP_CODE = LP_CODE;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}