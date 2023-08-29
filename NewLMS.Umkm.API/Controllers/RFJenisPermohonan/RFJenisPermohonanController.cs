using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RfAppTypes;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RfAppTypes.Commands;
using NewLMS.UMKM.MediatR.Features.RfAppTypes.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RfAppType
{
    public class RfAppTypeController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RfAppType
        /// </summary>
        /// <param name="mediator"></param>
        public RfAppTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RfAppType By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetRfAppTypeById")]
        [Produces("application/json", "application/xml", Type = typeof(RfAppTypeResponseDto))]
        public async Task<IActionResult> GetRfAppTypeById(Guid Id)
        {
            var getGenderQuery = new RfAppTypesGetByIdQuery { Id = Id };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RfAppType
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRfAppTypeList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RfAppTypeResponseDto>>))]
        public async Task<IActionResult> GetRfAppTypeList(RfAppTypesGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RfAppType
        /// </summary>
        /// <param name="postRfAppType"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRfAppType")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RfAppTypeResponseDto>))]
        public async Task<IActionResult> AddRfAppType(RfAppTypePostCommand postRfAppType)
        {
            var result = await _mediator.Send(postRfAppType);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRfAppTypeById", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit RfAppType
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putRfAppType"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditRfAppType")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RfAppTypeResponseDto>))]
        public async Task<IActionResult> EditRfAppType([FromRoute] Guid Id, [FromBody] RfAppTypePutCommand putRfAppType)
        {
            putRfAppType.Id = Id;
            var result = await _mediator.Send(putRfAppType);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RfAppType
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteRfAppType")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRfAppType([FromRoute] Guid Id, [FromBody]RfAppTypeDeleteCommand deleteCommand)
        {
            deleteCommand.Id = Id;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}