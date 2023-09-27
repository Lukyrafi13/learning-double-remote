using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.DocumentSurveyors;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.MediatR.Features.DocumentSurveyors.Commands;
using NewLMS.Umkm.MediatR.Features.DocumentSurveyors.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.DocumentSurveyor
{
    [Authorize]
    public class DocumentSurveyorController : BaseController
    {
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<DocumentSurveyorResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromBody] DocumentSurveyorsGetFilterquery command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(type: typeof(ServiceResponse<DocumentSurveyorResponse>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById([FromRoute] DocumentSurveyorsGetByIdQuery command)
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
        public async Task<IActionResult> Upload([FromForm] DocumentSurveyorsUploadCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromRoute] DocumentSurveyorsDeleteCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
