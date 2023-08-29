using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.EnumSandiBITypes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.EnumSandiBITypes.Commands;
using NewLMS.Umkm.MediatR.Features.EnumSandiBITypes.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.EnumSandiBIType
{
    public class EnumSandiBITypeController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// EnumSandiBIType
        /// </summary>
        /// <param name="mediator"></param>
        public EnumSandiBITypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get EnumSandiBIType By BI_TYPE
        /// </summary>
        /// <param name="BI_TYPE"></param>
        /// <returns></returns>
        [HttpGet("get/{BI_TYPE}", Name = "GetEnumSandiBITypeByCode")]
        [Produces("application/json", "application/xml", Type = typeof(EnumSandiBITypeResponseDto))]
        public async Task<IActionResult> GetEnumSandiBITypeByCode(string BI_TYPE)
        {
            var getSCOQuery = new EnumSandiBITypeGetQuery { BI_TYPE = BI_TYPE };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get EnumSandiBIType
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetEnumSandiBITypeList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<EnumSandiBITypeResponseDto>>))]
        public async Task<IActionResult> GetEnumSandiBITypeList(EnumSandiBITypesGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New EnumSandiBIType
        /// </summary>
        /// <param name="postEnumSandiBIType"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddEnumSandiBIType")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<EnumSandiBITypeResponseDto>))]
        public async Task<IActionResult> AddEnumSandiBIType(EnumSandiBITypePostCommand postEnumSandiBIType)
        {
            var result = await _mediator.Send(postEnumSandiBIType);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetEnumSandiBITypeByCode", new { BI_TYPE = result.Data.BI_TYPE }, result.Data);
        }

        /// <summary>
        /// Put Edit EnumSandiBIType
        /// </summary>
        /// <param name="BI_TYPE"></param>
        /// <param name="putEnumSandiBIType"></param>
        /// <returns></returns>
        [HttpPut("put/{BI_TYPE}", Name = "EditEnumSandiBIType")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<EnumSandiBITypeResponseDto>))]
        public async Task<IActionResult> EditEnumSandiBIType([FromRoute] string BI_TYPE, [FromBody] EnumSandiBITypePutCommand putEnumSandiBIType)
        {
            putEnumSandiBIType.BI_TYPE = BI_TYPE;
            var result = await _mediator.Send(putEnumSandiBIType);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete EnumSandiBIType
        /// </summary>
        /// <param name="BI_TYPE"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{BI_TYPE}", Name = "DeleteEnumSandiBIType")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteEnumSandiBIType([FromRoute] string BI_TYPE, [FromBody]EnumSandiBITypeDeleteCommand deleteCommand)
        {
            deleteCommand.BI_TYPE = BI_TYPE;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}