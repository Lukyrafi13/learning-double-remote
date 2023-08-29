using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.SCJabatans;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.MediatR.Features.SCJabatans.Commands;
using NewLMS.Umkm.MediatR.Features.SCJabatans.Queries;

namespace NewLMS.Umkm.API.Controllers.SCJabatan
{
    public class SCJabatanController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// SCJabatan
        /// </summary>
        /// <param name="mediator"></param>
        public SCJabatanController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get SCJabatan By JAB_CODE
        /// </summary>
        /// <param name="JAB_CODE"></param>
        /// <returns></returns>
        [HttpGet("get/{JAB_CODE}", Name = "GetSCJabatanByCode")]
        [Produces("application/json", "application/xml", Type = typeof(SCJabatanResponseDto))]
        public async Task<IActionResult> GetSCJabatanByCode(string JAB_CODE)
        {
            var getSCOQuery = new SCJabatansGetByGenderCodeQuery { JAB_CODE = JAB_CODE };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get SCJabatan By JAB_CODE
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetSCJabatanList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<SCJabatanResponseDto>>))]
        public async Task<IActionResult> GetSCJabatanList(SCJabatanGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New SCJabatan
        /// </summary>
        /// <param name="postSCJabatan"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddSCJabatan")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<SCJabatanResponseDto>))]
        public async Task<IActionResult> AddSCJabatan(SCJabatanPostCommand postSCJabatan)
        {
            var result = await _mediator.Send(postSCJabatan);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetSCJabatanByCode", new { id = result.Data.JAB_CODE }, result.Data);
        }

        /// <summary>
        /// Put Edit SCJabatan
        /// </summary>
        /// <param name="JAB_CODE"></param>
        /// <param name="putSCJabatan"></param>
        /// <returns></returns>
        [HttpPut("put/{JAB_CODE}", Name = "EditSCJabatan")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<SCJabatanResponseDto>))]
        public async Task<IActionResult> EditSCJabatan([FromRoute] string JAB_CODE, [FromBody] SCJabatanPutCommand putSCJabatan)
        {
            putSCJabatan.JAB_CODE = JAB_CODE;
            var result = await _mediator.Send(putSCJabatan);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete SCJabatan
        /// </summary>
        /// <param name="JAB_CODE"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{JAB_CODE}", Name = "DeleteSCJabatan")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteSCJabatan([FromRoute] string JAB_CODE, [FromBody] SCJabatanDeleteCommand deleteCommand)
        {
            deleteCommand.JAB_CODE = JAB_CODE;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}