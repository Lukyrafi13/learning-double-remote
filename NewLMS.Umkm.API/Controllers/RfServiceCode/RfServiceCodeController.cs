using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RfServiceCodes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RfServiceCodes.Commands;
using NewLMS.UMKM.MediatR.Features.RfServiceCodes.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RfServiceCode
{
    public class RfServiceCodeController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RfServiceCode
        /// </summary>
        /// <param name="mediator"></param>
        public RfServiceCodeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RfServiceCode By ServiceCode
        /// </summary>
        /// <param name="ServiceCode"></param>
        /// <returns></returns>
        [HttpGet("get/{ServiceCode}", Name = "GetRfServiceCodeByServiceCode")]
        [Produces("application/json", "application/xml", Type = typeof(RfServiceCodeResponseDto))]
        public async Task<IActionResult> GetRfServiceCodeByServiceCode(string ServiceCode)
        {
            var getGenderQuery = new RfServiceCodesGetByServiceCodeQuery { ServiceCode = ServiceCode };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RfServiceCode By ServiceCode
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRfServiceCodeList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RfServiceCodeResponseDto>>))]
        public async Task<IActionResult> GetRfServiceCodeList(RfServiceCodesGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RfServiceCode
        /// </summary>
        /// <param name="postRfServiceCode"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRfServiceCode")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RfServiceCodeResponseDto>))]
        public async Task<IActionResult> AddRfServiceCode(RfServiceCodePostCommand postRfServiceCode)
        {
            var result = await _mediator.Send(postRfServiceCode);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRfServiceCodeByServiceCode", new { id = result.Data.ServiceCode }, result.Data);
        }

        /// <summary>
        /// Put Edit RfServiceCode
        /// </summary>
        /// <param name="ServiceCode"></param>
        /// <param name="putRfServiceCode"></param>
        /// <returns></returns>
        [HttpPut("put/{ServiceCode}", Name = "EditRfServiceCode")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RfServiceCodeResponseDto>))]
        public async Task<IActionResult> EditRfServiceCode([FromRoute] string ServiceCode, [FromBody] RfServiceCodePutCommand putRfServiceCode)
        {
            putRfServiceCode.ServiceCode = ServiceCode;
            var result = await _mediator.Send(putRfServiceCode);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RfServiceCode
        /// </summary>
        /// <param name="ServiceCode"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{ServiceCode}", Name = "DeleteRfServiceCode")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRfServiceCode([FromRoute] string ServiceCode, [FromBody]RfServiceCodeDeleteCommand deleteCommand)
        {
            deleteCommand.ServiceCode = ServiceCode;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}