using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RFPaymentMethods;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFPaymentMethods.Commands;
using NewLMS.Umkm.MediatR.Features.RFPaymentMethods.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.RFPaymentMethod
{
    public class RFPaymentMethodController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFPaymentMethod
        /// </summary>
        /// <param name="mediator"></param>
        public RFPaymentMethodController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFPaymentMethod By PAY_CODE
        /// </summary>
        /// <param name="PAY_CODE"></param>
        /// <returns></returns>
        [HttpGet("get/{PAY_CODE}", Name = "GetRFPaymentMethodBy")]
        [Produces("application/json", "application/xml", Type = typeof(RFPaymentMethodResponseDto))]
        public async Task<IActionResult> GetRFPaymentMethodBy(string PAY_CODE)
        {
            var getGenderQuery = new RFPaymentMethodGetQuery { PAY_CODE = PAY_CODE };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFPaymentMethod By Filter
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFPaymentMethodList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFPaymentMethodResponseDto>>))]
        public async Task<IActionResult> GetRFPaymentMethodList(RFPaymentMethodsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFPaymentMethod
        /// </summary>
        /// <param name="postRFPaymentMethod"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFPaymentMethod")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFPaymentMethodResponseDto>))]
        public async Task<IActionResult> AddRFPaymentMethod(RFPaymentMethodPostCommand postRFPaymentMethod)
        {
            var result = await _mediator.Send(postRFPaymentMethod);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFPaymentMethodByPAY_CODE", new { id = result.Data.PAY_CODE }, result.Data);
        }

        /// <summary>
        /// Put Edit RFPaymentMethod
        /// </summary>
        /// <param name="PAY_CODE"></param>
        /// <param name="putRFPaymentMethod"></param>
        /// <returns></returns>
        [HttpPut("put/{PAY_CODE}", Name = "EditRFPaymentMethod")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFPaymentMethodResponseDto>))]
        public async Task<IActionResult> EditRFPaymentMethod([FromRoute] string PAY_CODE, [FromBody] RFPaymentMethodPutCommand putRFPaymentMethod)
        {
            putRFPaymentMethod.PAY_CODE = PAY_CODE;
            var result = await _mediator.Send(putRFPaymentMethod);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFPaymentMethod
        /// </summary>
        /// <param name="PAY_CODE"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{PAY_CODE}", Name = "DeleteRFPaymentMethod")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFPaymentMethod([FromRoute] string PAY_CODE, [FromBody]RFPaymentMethodDeleteCommand deleteCommand)
        {
            deleteCommand.PAY_CODE = PAY_CODE;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}