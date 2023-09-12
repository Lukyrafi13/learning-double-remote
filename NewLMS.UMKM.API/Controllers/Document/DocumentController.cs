using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.Documents;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.MediatR.Features.Documents.Commands;
using NewLMS.UMKM.MediatR.Features.Documents.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.UMKM.API.Controllers.Document
{
    [Authorize]
    public class DocumentController : BaseController
    {
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<DocumentResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromBody] DocumentsGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(type: typeof(ServiceResponse<DocumentResponse>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById([FromRoute] DocumentsGetByIdQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Upload Documents
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Upload"), DisableRequestSizeLimit]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Upload([FromForm] DocumentsUploadCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{Id}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Put([FromRoute] Guid Id, [FromForm] DocumentsUpdateCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromRoute] DocumentsDeleteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{FileUrlId}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteFile([FromRoute] DocumentFilesDeleteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
