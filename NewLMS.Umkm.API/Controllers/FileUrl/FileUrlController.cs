using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.FileUrls;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.FileUrls.Commands;
using NewLMS.Umkm.MediatR.Features.FileUrls.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.FileUrl
{
    public class FileUrlController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// FileUrl
        /// </summary>
        /// <param name="mediator"></param>
        public FileUrlController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get FileUrl By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetFileUrlByCode")]
        [Produces("application/json", "application/xml", Type = typeof(FileUrlResponseDto))]
        public async Task<IActionResult> GetFileUrlByCode(Guid Id)
        {
            var getSCOQuery = new FileUrlGetQuery { Id = Id };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get FileUrl By Filter
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetFileUrlList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<FileUrlResponseDto>>))]
        public async Task<IActionResult> GetFileUrlList(FileUrlsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New FileUrl
        /// </summary>
        /// <param name="postFileUrl"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddFileUrl")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<FileUrlResponseDto>))]
        public async Task<IActionResult> AddFileUrl(FileUrlPostCommand postFileUrl)
        {
            var result = await _mediator.Send(postFileUrl);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetFileUrlByCode", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit FileUrl
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putFileUrl"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditFileUrl")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<FileUrlResponseDto>))]
        public async Task<IActionResult> EditFileUrl([FromRoute] Guid Id, [FromBody] FileUrlPutCommand putFileUrl)
        {
            putFileUrl.Id = Id;
            var result = await _mediator.Send(putFileUrl);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete FileUrl
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteFileUrl")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteFileUrl([FromRoute] Guid Id, [FromBody]FileUrlDeleteCommand deleteCommand)
        {
            deleteCommand.Id = Id;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}