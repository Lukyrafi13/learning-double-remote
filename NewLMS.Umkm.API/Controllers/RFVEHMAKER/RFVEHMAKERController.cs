using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RFVEHMAKERs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFVEHMAKERs.Commands;
using NewLMS.Umkm.MediatR.Features.RFVEHMAKERs.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.RFVEHMAKER
{
    public class RFVEHMAKERController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFVEHMAKER
        /// </summary>
        /// <param name="mediator"></param>
        public RFVEHMAKERController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFVEHMAKER By VMKR_CODE
        /// </summary>
        /// <param name="VMKR_CODE"></param>
        /// <returns></returns>
        [HttpGet("get/{VMKR_CODE}", Name = "GetRFVEHMAKERByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFVEHMAKERResponseDto))]
        public async Task<IActionResult> GetRFVEHMAKERByCode(string VMKR_CODE)
        {
            var getSCOQuery = new RFVEHMAKERGetQuery { VMKR_CODE = VMKR_CODE };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFVEHMAKER By VMKR_CODE
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFVEHMAKERList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFVEHMAKERResponseDto>>))]
        public async Task<IActionResult> GetRFVEHMAKERList(RFVEHMAKERsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFVEHMAKER
        /// </summary>
        /// <param name="postRFVEHMAKER"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFVEHMAKER")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFVEHMAKERResponseDto>))]
        public async Task<IActionResult> AddRFVEHMAKER(RFVEHMAKERPostCommand postRFVEHMAKER)
        {
            var result = await _mediator.Send(postRFVEHMAKER);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFVEHMAKERByCode", new { id = result.Data.VMKR_CODE }, result.Data);
        }

        /// <summary>
        /// Put Edit RFVEHMAKER
        /// </summary>
        /// <param name="VMKR_CODE"></param>
        /// <param name="putRFVEHMAKER"></param>
        /// <returns></returns>
        [HttpPut("put/{VMKR_CODE}", Name = "EditRFVEHMAKER")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFVEHMAKERResponseDto>))]
        public async Task<IActionResult> EditRFVEHMAKER([FromRoute] string VMKR_CODE, [FromBody] RFVEHMAKERPutCommand putRFVEHMAKER)
        {
            putRFVEHMAKER.VMKR_CODE = VMKR_CODE;
            var result = await _mediator.Send(putRFVEHMAKER);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFVEHMAKER
        /// </summary>
        /// <param name="VMKR_CODE"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{VMKR_CODE}", Name = "DeleteRFVEHMAKER")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFVEHMAKER([FromRoute] string VMKR_CODE, [FromBody]RFVEHMAKERDeleteCommand deleteCommand)
        {
            deleteCommand.VMKR_CODE = VMKR_CODE;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}