using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RfCompanyGroups;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RfCompanyGroups.Commands;
using NewLMS.UMKM.MediatR.Features.RfCompanyGroups.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RfCompanyGroup
{
    public class RfCompanyGroupController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RfCompanyGroup
        /// </summary>
        /// <param name="mediator"></param>
        public RfCompanyGroupController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RfCompanyGroup By AnlCode
        /// </summary>
        /// <param name="AnlCode"></param>
        /// <returns></returns>
        [HttpGet("get/{AnlCode}", Name = "GetRfCompanyGroupByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RfCompanyGroupResponseDto))]
        public async Task<IActionResult> GetRfCompanyGroupByCode(string AnlCode)
        {
            var getSCOQuery = new RfCompanyGroupGetQuery { AnlCode = AnlCode };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RfCompanyGroup By AnlCode
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRfCompanyGroupList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RfCompanyGroupResponseDto>>))]
        public async Task<IActionResult> GetRfCompanyGroupList(RfCompanyGroupsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RfCompanyGroup
        /// </summary>
        /// <param name="postRfCompanyGroup"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRfCompanyGroup")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RfCompanyGroupResponseDto>))]
        public async Task<IActionResult> AddRfCompanyGroup(RfCompanyGroupPostCommand postRfCompanyGroup)
        {
            var result = await _mediator.Send(postRfCompanyGroup);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRfCompanyGroupByCode", new { id = result.Data.AnlCode }, result.Data);
        }

        /// <summary>
        /// Put Edit RfCompanyGroup
        /// </summary>
        /// <param name="AnlCode"></param>
        /// <param name="putRfCompanyGroup"></param>
        /// <returns></returns>
        [HttpPut("put/{AnlCode}", Name = "EditRfCompanyGroup")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RfCompanyGroupResponseDto>))]
        public async Task<IActionResult> EditRfCompanyGroup([FromRoute] string AnlCode, [FromBody] RfCompanyGroupPutCommand putRfCompanyGroup)
        {
            putRfCompanyGroup.AnlCode = AnlCode;
            var result = await _mediator.Send(putRfCompanyGroup);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RfCompanyGroup
        /// </summary>
        /// <param name="AnlCode"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{AnlCode}", Name = "DeleteRfCompanyGroup")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRfCompanyGroup([FromRoute] string AnlCode, [FromBody]RfCompanyGroupDeleteCommand deleteCommand)
        {
            deleteCommand.AnlCode = AnlCode;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}