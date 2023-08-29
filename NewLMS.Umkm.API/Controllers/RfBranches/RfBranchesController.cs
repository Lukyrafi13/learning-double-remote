using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RfBranchess;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RfBranchess.Commands;
using NewLMS.Umkm.MediatR.Features.RfBranchess.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.RfBranches
{
    public class RfBranchesController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RfBranches
        /// </summary>
        /// <param name="mediator"></param>
        public RfBranchesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RfBranches By Code
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        [HttpGet("get/{Code}", Name = "GetRfBranchesByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RfBranchesResponseDto))]
        public async Task<IActionResult> GetRfBranchesByCode(string Code)
        {
            var getStatusTargetQuery = new RfBranchesGetByCodeQuery { Code = Code };
            var result = await _mediator.Send(getStatusTargetQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RfBranches List
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRfBranchesList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RfBranchesResponseDto>>))]
        public async Task<IActionResult> GetRfBranchesList(RfBranchessGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RfBranches
        /// </summary>
        /// <param name="postRfBranches"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRfBranches")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RfBranchesResponseDto>))]
        public async Task<IActionResult> AddRfBranches(RfBranchesPostCommand postRfBranches)
        {
            var result = await _mediator.Send(postRfBranches);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRfBranchesByCode", new { Code = result.Data.Code }, result.Data);
        }

        /// <summary>
        /// Put Edit RfBranches
        /// </summary>
        /// <param name="Code"></param>
        /// <param name="putRfBranches"></param>
        /// <returns></returns>
        [HttpPut("put/{Code}", Name = "EditRfBranches")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RfBranchesResponseDto>))]
        public async Task<IActionResult> EditRfBranches([FromRoute] string Code, [FromBody] RfBranchesPutCommand putRfBranches)
        {
            putRfBranches.Code = Code;
            var result = await _mediator.Send(putRfBranches);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RfBranches
        /// </summary>
        /// <param name="Code"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Code}", Name = "DeleteRfBranches")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRfBranches([FromRoute] string Code, [FromBody] RfBranchesDeleteCommand deleteCommand)
        {
            deleteCommand.Code = Code;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}