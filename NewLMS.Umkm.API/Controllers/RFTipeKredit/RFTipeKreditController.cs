using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RfCreditTypes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RfCreditTypes.Commands;
using NewLMS.UMKM.MediatR.Features.RfCreditTypes.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RfCreditType
{
    public class RfCreditTypeController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RfCreditType
        /// </summary>
        /// <param name="mediator"></param>
        public RfCreditTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RfCreditType By Code
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        [HttpGet("get/{Code}", Name = "GetRfCreditTypeByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RfCreditTypeResponseDto))]
        public async Task<IActionResult> GetRfCreditTypeByCode(string Code)
        {
            var getSCOQuery = new RfCreditTypeGetQuery { Code = Code };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RfCreditType
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRfCreditTypeList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RfCreditTypeResponseDto>>))]
        public async Task<IActionResult> GetRfCreditTypeList(RfCreditTypesGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RfCreditType
        /// </summary>
        /// <param name="postRfCreditType"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRfCreditType")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RfCreditTypeResponseDto>))]
        public async Task<IActionResult> AddRfCreditType(RfCreditTypePostCommand postRfCreditType)
        {
            var result = await _mediator.Send(postRfCreditType);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRfCreditTypeByCode", new { Code = result.Data.Code }, result.Data);
        }

        /// <summary>
        /// Put Edit RfCreditType
        /// </summary>
        /// <param name="Code"></param>
        /// <param name="putRfCreditType"></param>
        /// <returns></returns>
        [HttpPut("put/{Code}", Name = "EditRfCreditType")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RfCreditTypeResponseDto>))]
        public async Task<IActionResult> EditRfCreditType([FromRoute] string Code, [FromBody] RfCreditTypePutCommand putRfCreditType)
        {
            putRfCreditType.Code = Code;
            var result = await _mediator.Send(putRfCreditType);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RfCreditType
        /// </summary>
        /// <param name="Code"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Code}", Name = "DeleteRfCreditType")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRfCreditType([FromRoute] string Code, [FromBody]RfCreditTypeDeleteCommand deleteCommand)
        {
            deleteCommand.Code = Code;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}