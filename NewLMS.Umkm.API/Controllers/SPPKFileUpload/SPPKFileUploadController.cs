using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.SPPKFileUploads;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.SPPKFileUploads.Commands;
using NewLMS.Umkm.MediatR.Features.SPPKFileUploads.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.SPPKFileUpload
{
    public class SPPKFileUploadController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// SPPKFileUpload
        /// </summary>
        /// <param name="mediator"></param>
        public SPPKFileUploadController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get SPPKFileUpload By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetSPPKFileUploadByCode")]
        [Produces("application/json", "application/xml", Type = typeof(SPPKFileUploadResponseDto))]
        public async Task<IActionResult> GetSPPKFileUploadByCode(Guid Id)
        {
            var getSCOQuery = new SPPKFileUploadGetQuery { Id = Id };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get SPPKFileUpload
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetSPPKFileUploadList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<SPPKFileUploadResponseDto>>))]
        public async Task<IActionResult> GetSPPKFileUploadList(SPPKFileUploadsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New SPPKFileUpload
        /// </summary>
        /// <param name="postSPPKFileUpload"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddSPPKFileUpload")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<SPPKFileUploadResponseDto>))]
        public async Task<IActionResult> AddSPPKFileUpload([FromForm] SPPKFileUploadPostCommand postSPPKFileUpload)
        {
            var result = await _mediator.Send(postSPPKFileUpload);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetSPPKFileUploadByCode", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit SPPKFileUpload
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putSPPKFileUpload"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditSPPKFileUpload")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<SPPKFileUploadResponseDto>))]
        public async Task<IActionResult> EditSPPKFileUpload([FromRoute] Guid Id, [FromForm] SPPKFileUploadPutCommand putSPPKFileUpload)
        {
            putSPPKFileUpload.Id = Id;
            var result = await _mediator.Send(putSPPKFileUpload);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete SPPKFileUpload
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteSPPKFileUpload")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteSPPKFileUpload([FromRoute] Guid Id, [FromBody] SPPKFileUploadDeleteCommand deleteCommand)
        {
            deleteCommand.Id = Id;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}