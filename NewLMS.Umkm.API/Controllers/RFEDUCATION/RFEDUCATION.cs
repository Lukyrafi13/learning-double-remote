using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFEDUCATIONs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFEDUCATIONs.Commands;
using NewLMS.UMKM.MediatR.Features.RFEDUCATIONs.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RFEDUCATION
{
    public class RFEDUCATIONController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFEDUCATION
        /// </summary>
        /// <param name="mediator"></param>
        public RFEDUCATIONController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFEDUCATION By ED_CODE
        /// </summary>
        /// <param name="ED_CODE"></param>
        /// <returns></returns>
        [HttpGet("get/{ED_CODE}", Name = "GetRFEDUCATIONByED_CODE")]
        [Produces("application/json", "application/xml", Type = typeof(RFEDUCATIONResponseDto))]
        public async Task<IActionResult> GetRFEDUCATIONByED_CODE(string ED_CODE)
        {
            var getEducationQuery = new RFEDUCATIONsGetByEducationCodeQuery { ED_CODE = ED_CODE };
            var result = await _mediator.Send(getEducationQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFEDUCATION By ED_CODE
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFEDUCATIONList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFEDUCATIONResponseDto>>))]
        public async Task<IActionResult> GetRFEDUCATIONList(RFEDUCATIONsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFEDUCATION
        /// </summary>
        /// <param name="postRFEDUCATION"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFEDUCATION")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFEDUCATIONResponseDto>))]
        public async Task<IActionResult> AddRFEDUCATION(RFEDUCATIONPostCommand postRFEDUCATION)
        {
            var result = await _mediator.Send(postRFEDUCATION);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFEDUCATIONByED_CODE", new { id = result.Data.ED_CODE }, result.Data);
        }

        /// <summary>
        /// Put Edit RFEDUCATION
        /// </summary>
        /// <param name="ED_CODE"></param>
        /// <param name="putRFEDUCATION"></param>
        /// <returns></returns>
        [HttpPut("put/{ED_CODE}", Name = "EditRFEDUCATION")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFEDUCATIONResponseDto>))]
        public async Task<IActionResult> EditRFEDUCATION([FromRoute] string ED_CODE, [FromBody] RFEDUCATIONPutCommand putRFEDUCATION)
        {
            putRFEDUCATION.ED_CODE = ED_CODE;
            var result = await _mediator.Send(putRFEDUCATION);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFEDUCATION
        /// </summary>
        /// <param name="ED_CODE"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{ED_CODE}", Name = "DeleteRFEDUCATION")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFEDUCATION([FromRoute] string ED_CODE, [FromBody]RFEDUCATIONDeleteCommand deleteCommand)
        {
            deleteCommand.ED_CODE = ED_CODE;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}