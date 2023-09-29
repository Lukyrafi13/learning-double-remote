using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.DocumentSurveys;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.MediatR.Features.DocumentSurveys.Commands;
using NewLMS.Umkm.MediatR.Features.DocumentSurveys.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.DocumentSurvey
{
    [Authorize]
    public class DocumentSurveyController : BaseController
    {
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<DocumentSurveyResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromBody] DocumentSurveyGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(type: typeof(ServiceResponse<DocumentSurveyResponse>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById([FromRoute] DocumentSurveyGetByIdQuery command)
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
        public async Task<IActionResult> Upload([FromForm] DocumentSurveyUploadCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromRoute] DocumentSurveyDeleteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
