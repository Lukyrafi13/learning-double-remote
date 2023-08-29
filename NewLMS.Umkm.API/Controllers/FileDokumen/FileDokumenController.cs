using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.FileDokumens;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.FileDokumens.Commands;
using NewLMS.Umkm.MediatR.Features.FileDokumens.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.FileDokumen
{
    public class FileDokumenController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// FileDokumen
        /// </summary>
        /// <param name="mediator"></param>
        public FileDokumenController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get FileDokumen By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetFileDokumenByCode")]
        [Produces("application/json", "application/xml", Type = typeof(FileDokumenResponseDto))]
        public async Task<IActionResult> GetFileDokumenByCode(Guid Id)
        {
            var getSCOQuery = new FileDokumenGetQuery { Id = Id };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get FileDokumen
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetFileDokumenList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<FileDokumenResponseDto>>))]
        public async Task<IActionResult> GetFileDokumenList(FileDokumensGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New FileDokumen
        /// </summary>
        /// <param name="postFileDokumen"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddFileDokumen")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<FileDokumenResponseDto>))]
        public async Task<IActionResult> AddFileDokumen(FileDokumenPostCommand postFileDokumen)
        {
            var result = await _mediator.Send(postFileDokumen);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetFileDokumenByCode", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit FileDokumen
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putFileDokumen"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditFileDokumen")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<FileDokumenResponseDto>))]
        public async Task<IActionResult> EditFileDokumen([FromRoute] Guid Id, [FromBody] FileDokumenPutCommand putFileDokumen)
        {
            putFileDokumen.Id = Id;
            var result = await _mediator.Send(putFileDokumen);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete FileDokumen
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteFileDokumen")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteFileDokumen([FromRoute] Guid Id, [FromBody]FileDokumenDeleteCommand deleteCommand)
        {
            deleteCommand.Id = Id;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}