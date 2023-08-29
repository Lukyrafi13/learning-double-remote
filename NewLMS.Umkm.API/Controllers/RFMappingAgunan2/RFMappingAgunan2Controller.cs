using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RFMappingAgunan2s;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFMappingAgunan2s.Commands;
using NewLMS.Umkm.MediatR.Features.RFMappingAgunan2s.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.RFMappingAgunan2
{
    public class RFMappingAgunan2Controller : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFMappingAgunan2
        /// </summary>
        /// <param name="mediator"></param>
        public RFMappingAgunan2Controller(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFMappingAgunan2 By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetRFMappingAgunan2ByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFMappingAgunan2ResponseDto))]
        public async Task<IActionResult> GetRFMappingAgunan2ByCode(Guid Id)
        {
            var getSCOQuery = new RFMappingAgunan2sGetByCodeQuery { Id = Id };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFMappingAgunan2
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFMappingAgunan2List")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFMappingAgunan2ResponseDto>>))]
        public async Task<IActionResult> GetRFMappingAgunan2List(RFMappingAgunan2sGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFMappingAgunan2
        /// </summary>
        /// <param name="postRFMappingAgunan2"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFMappingAgunan2")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFMappingAgunan2ResponseDto>))]
        public async Task<IActionResult> AddRFMappingAgunan2(RFMappingAgunan2PostCommand postRFMappingAgunan2)
        {
            var result = await _mediator.Send(postRFMappingAgunan2);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFMappingAgunan2ByCode", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit RFMappingAgunan2
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putRFMappingAgunan2"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditRFMappingAgunan2")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFMappingAgunan2ResponseDto>))]
        public async Task<IActionResult> EditRFMappingAgunan2([FromRoute] Guid Id, [FromBody] RFMappingAgunan2PutCommand putRFMappingAgunan2)
        {
            putRFMappingAgunan2.Id = Id;
            var result = await _mediator.Send(putRFMappingAgunan2);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFMappingAgunan2
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteRFMappingAgunan2")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFMappingAgunan2([FromRoute] Guid Id, [FromBody]RFMappingAgunan2DeleteCommand deleteCommand)
        {
            deleteCommand.Id = Id;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}