using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFMappingPrescreeningDocuments;
using NewLMS.UMKM.Data.Dto.RfSectorLBU3s;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFMappingPrescreeningDocuments.Commands;
using NewLMS.UMKM.MediatR.Features.RFMappingPrescreeningDocuments.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RFMappingPrescreeningDocument
{
    public class RFMappingPrescreeningDocumentController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFMappingPrescreeningDocument
        /// </summary>
        /// <param name="mediator"></param>
        public RFMappingPrescreeningDocumentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFMappingPrescreeningDocument By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetRFMappingPrescreeningDocumentBy")]
        [Produces("application/json", "application/xml", Type = typeof(RFMappingPrescreeningDocumentResponseDto))]
        public async Task<IActionResult> GetRFMappingPrescreeningDocumentBy(int Id)
        {
            var getGenderQuery = new RFMappingPrescreeningDocumentGetQuery { Id = Id };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFMappingPrescreeningDocument By Filter
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFMappingPrescreeningDocumentList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFMappingPrescreeningDocumentResponseDto>>))]
        public async Task<IActionResult> GetRFMappingPrescreeningDocumentList(RFMappingPrescreeningDocumentsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFMappingPrescreeningDocument
        /// </summary>
        /// <param name="postRFMappingPrescreeningDocument"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFMappingPrescreeningDocument")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFMappingPrescreeningDocumentResponseDto>))]
        public async Task<IActionResult> AddRFMappingPrescreeningDocument(RFMappingPrescreeningDocumentPostCommand postRFMappingPrescreeningDocument)
        {
            var result = await _mediator.Send(postRFMappingPrescreeningDocument);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFMappingPrescreeningDocumentById", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit RFMappingPrescreeningDocument
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putRFMappingPrescreeningDocument"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditRFMappingPrescreeningDocument")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFMappingPrescreeningDocumentResponseDto>))]
        public async Task<IActionResult> EditRFMappingPrescreeningDocument([FromRoute] int Id, [FromBody] RFMappingPrescreeningDocumentPutCommand putRFMappingPrescreeningDocument)
        {
            putRFMappingPrescreeningDocument.Id = Id;
            var result = await _mediator.Send(putRFMappingPrescreeningDocument);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFMappingPrescreeningDocument
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteRFMappingPrescreeningDocument")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFMappingPrescreeningDocument([FromRoute] int Id, [FromBody]RFMappingPrescreeningDocumentDeleteCommand deleteCommand)
        {
            deleteCommand.Id = Id;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}