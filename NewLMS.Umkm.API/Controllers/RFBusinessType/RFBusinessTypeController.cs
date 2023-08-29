using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFBusinessTypes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFBusinessTypes.Commands;
using NewLMS.UMKM.MediatR.Features.RFBusinessTypes.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RFBusinessType
{
    public class RFBusinessTypeController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFBusinessType
        /// </summary>
        /// <param name="mediator"></param>
        public RFBusinessTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFBusinessType By BTCode
        /// </summary>
        /// <param name="BTCode"></param>
        /// <returns></returns>
        [HttpGet("get/{BTCode}", Name = "GetRFBusinessTypeBy")]
        [Produces("application/json", "application/xml", Type = typeof(RFBusinessTypeResponseDto))]
        public async Task<IActionResult> GetRFBusinessTypeBy(string BTCode)
        {
            var getGenderQuery = new RFBusinessTypeGetQuery { BTCode = BTCode };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFBusinessType By Filter
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFBusinessTypeList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFBusinessTypeResponseDto>>))]
        public async Task<IActionResult> GetRFBusinessTypeList(RFBusinessTypesGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFBusinessType
        /// </summary>
        /// <param name="postRFBusinessType"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFBusinessType")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFBusinessTypeResponseDto>))]
        public async Task<IActionResult> AddRFBusinessType(RFBusinessTypePostCommand postRFBusinessType)
        {
            var result = await _mediator.Send(postRFBusinessType);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFBusinessTypeByBTCode", new { id = result.Data.BTCode }, result.Data);
        }

        /// <summary>
        /// Put Edit RFBusinessType
        /// </summary>
        /// <param name="BTCode"></param>
        /// <param name="putRFBusinessType"></param>
        /// <returns></returns>
        [HttpPut("put/{BTCode}", Name = "EditRFBusinessType")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFBusinessTypeResponseDto>))]
        public async Task<IActionResult> EditRFBusinessType([FromRoute] string BTCode, [FromBody] RFBusinessTypePutCommand putRFBusinessType)
        {
            putRFBusinessType.BTCode = BTCode;
            var result = await _mediator.Send(putRFBusinessType);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFBusinessType
        /// </summary>
        /// <param name="BTCode"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{BTCode}", Name = "DeleteRFBusinessType")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFBusinessType([FromRoute] string BTCode, [FromBody]RFBusinessTypeDeleteCommand deleteCommand)
        {
            deleteCommand.BTCode = BTCode;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}