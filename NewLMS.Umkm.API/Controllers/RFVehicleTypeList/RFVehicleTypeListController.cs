using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFVehicleTypeLists;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFVehicleTypeLists.Commands;
using NewLMS.UMKM.MediatR.Features.RFVehicleTypeLists.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RFVehicleTypeList
{
    public class RFVehicleTypeListController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFVehicleTypeList
        /// </summary>
        /// <param name="mediator"></param>
        public RFVehicleTypeListController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFVehicleTypeList By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetRFVehicleTypeListByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFVehicleTypeListResponseDto))]
        public async Task<IActionResult> GetRFVehicleTypeListByCode(Guid Id)
        {
            var getSCOQuery = new RFVehicleTypeListGetQuery { Id = Id };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFVehicleTypeList
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFVehicleTypeListList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFVehicleTypeListResponseDto>>))]
        public async Task<IActionResult> GetRFVehicleTypeListList(RFVehicleTypeListsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFVehicleTypeList
        /// </summary>
        /// <param name="postRFVehicleTypeList"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFVehicleTypeList")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFVehicleTypeListResponseDto>))]
        public async Task<IActionResult> AddRFVehicleTypeList(RFVehicleTypeListPostCommand postRFVehicleTypeList)
        {
            var result = await _mediator.Send(postRFVehicleTypeList);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFVehicleTypeListByCode", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit RFVehicleTypeList
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putRFVehicleTypeList"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditRFVehicleTypeList")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFVehicleTypeListResponseDto>))]
        public async Task<IActionResult> EditRFVehicleTypeList([FromRoute] Guid Id, [FromBody] RFVehicleTypeListPutCommand putRFVehicleTypeList)
        {
            putRFVehicleTypeList.Id = Id;
            var result = await _mediator.Send(putRFVehicleTypeList);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFVehicleTypeList
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteRFVehicleTypeList")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFVehicleTypeList([FromRoute] Guid Id, [FromBody]RFVehicleTypeListDeleteCommand deleteCommand)
        {
            deleteCommand.Id = Id;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}