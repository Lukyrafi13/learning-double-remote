using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RfBranches;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RfBranches.Commands;
using NewLMS.UMKM.MediatR.Features.RfBranches.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RfBranch
{
    public class RfBranchController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RfBranch
        /// </summary>
        /// <param name="mediator"></param>
        public RfBranchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RfBranch By Code
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        [HttpGet("get/{Code}", Name = "GetRfBranchByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RfBranchResponseDto))]
        public async Task<IActionResult> GetRfBranchByCode(string Code)
        {
            var getStatusTargetQuery = new RfBranchGetByCodeQuery { Code = Code };
            var result = await _mediator.Send(getStatusTargetQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RfBranch List
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRfBranchList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RfBranchResponseDto>>))]
        public async Task<IActionResult> GetRfBranchList(RfBranchGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RfBranch
        /// </summary>
        /// <param name="postRfBranch"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRfBranch")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RfBranchResponseDto>))]
        public async Task<IActionResult> AddRfBranch(RfBranchPostCommand postRfBranch)
        {
            var result = await _mediator.Send(postRfBranch);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRfBranchByCode", new { Code = result.Data.Code }, result.Data);
        }

        /// <summary>
        /// Put Edit RfBranch
        /// </summary>
        /// <param name="Code"></param>
        /// <param name="putRfBranch"></param>
        /// <returns></returns>
        [HttpPut("put/{Code}", Name = "EditRfBranch")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RfBranchResponseDto>))]
        public async Task<IActionResult> EditRfBranch([FromRoute] string Code, [FromBody] RfBranchPutCommand putRfBranch)
        {
            putRfBranch.Code = Code;
            var result = await _mediator.Send(putRfBranch);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RfBranch
        /// </summary>
        /// <param name="Code"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Code}", Name = "DeleteRfBranch")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRfBranch([FromRoute] string Code, [FromBody] RfBranchDeleteCommand deleteCommand)
        {
            deleteCommand.Code = Code;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}