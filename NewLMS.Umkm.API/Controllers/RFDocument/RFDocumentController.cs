using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RFDocuments;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFDocuments.Commands;
using NewLMS.Umkm.MediatR.Features.RFDocuments.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.RFDocument
{
    public class RFDocumentController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFDocument
        /// </summary>
        /// <param name="mediator"></param>
        public RFDocumentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFDocument By DocCode
        /// </summary>
        /// <param name="DocCode"></param>
        /// <returns></returns>
        [HttpGet("get/{DocCode}", Name = "GetRFDocumentByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFDocumentResponseDto))]
        public async Task<IActionResult> GetRFDocumentByCode(string DocCode)
        {
            var getSCOQuery = new RFDocumentsGetByCodeQuery { DocCode = DocCode };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFDocument By DocCode
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFDocumentList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFDocumentResponseDto>>))]
        public async Task<IActionResult> GetRFDocumentList(RFDocumentsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFDocument
        /// </summary>
        /// <param name="postRFDocument"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFDocument")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFDocumentResponseDto>))]
        public async Task<IActionResult> AddRFDocument(RFDocumentPostCommand postRFDocument)
        {
            var result = await _mediator.Send(postRFDocument);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFDocumentByCode", new { id = result.Data.DocCode }, result.Data);
        }

        /// <summary>
        /// Put Edit RFDocument
        /// </summary>
        /// <param name="DocCode"></param>
        /// <param name="putRFDocument"></param>
        /// <returns></returns>
        [HttpPut("put/{DocCode}", Name = "EditRFDocument")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFDocumentResponseDto>))]
        public async Task<IActionResult> EditRFDocument([FromRoute] string DocCode, [FromBody] RFDocumentPutCommand putRFDocument)
        {
            putRFDocument.DocCode = DocCode;
            var result = await _mediator.Send(putRFDocument);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFDocument
        /// </summary>
        /// <param name="DocCode"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{DocCode}", Name = "DeleteRFDocument")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFDocument([FromRoute] string DocCode, [FromBody]RFDocumentDeleteCommand deleteCommand)
        {
            deleteCommand.DocCode = DocCode;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}