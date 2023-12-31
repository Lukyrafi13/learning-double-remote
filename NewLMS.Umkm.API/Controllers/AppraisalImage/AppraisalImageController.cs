﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using NewLMS.Umkm.Data.Dto.AppraisalImages;
using NewLMS.Umkm.MediatR.Features.AppraisalImages.Commands;
using NewLMS.Umkm.MediatR.Features.AppraisalImages.Queries;

namespace NewLMS.Umkm.API.Controllers.AppraisalImage
{
    [Authorize]
    public class AppraisalImageController : BaseController
    {
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<AppraisalImagesResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromBody] GetFilterAppraisalImagesQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(type: typeof(ServiceResponse<AppraisalImagesResponse>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById([FromRoute] GetByIdAppraisalImagesQuery command)
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
        public async Task<IActionResult> Upload([FromForm] UploadAppraisalImagesCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType(type: typeof(ServiceResponse<Unit>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete([FromRoute] DeleteAppraisalImageCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
