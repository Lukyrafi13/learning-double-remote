using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.PrescreeningDokumens;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.PrescreeningDokumens.Commands;
using NewLMS.Umkm.MediatR.Features.PrescreeningDokumens.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.PrescreeningDokumen
{
    public class PrescreeningDokumenController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// PrescreeningDokumen
        /// </summary>
        /// <param name="mediator"></param>
        public PrescreeningDokumenController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get PrescreeningDokumen By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetPrescreeningDokumenByCode")]
        [Produces("application/json", "application/xml", Type = typeof(PrescreeningDokumenResponseDto))]
        public async Task<IActionResult> GetPrescreeningDokumenByCode(Guid Id)
        {
            var getSCOQuery = new PrescreeningDokumenGetQuery { Id = Id };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get PrescreeningDokumen
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetPrescreeningDokumenList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<PrescreeningDokumenResponseDto>>))]
        public async Task<IActionResult> GetPrescreeningDokumenList(PrescreeningDokumensGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New PrescreeningDokumen
        /// </summary>
        /// <param name="postPrescreeningDokumen"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddPrescreeningDokumen")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<PrescreeningDokumenResponseDto>))]
        public async Task<IActionResult> AddPrescreeningDokumen([FromForm]PrescreeningDokumenPostCommand postPrescreeningDokumen)
        {
            var result = await _mediator.Send(postPrescreeningDokumen);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetPrescreeningDokumenByCode", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit PrescreeningDokumen
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putPrescreeningDokumen"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditPrescreeningDokumen")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<PrescreeningDokumenResponseDto>))]
        public async Task<IActionResult> EditPrescreeningDokumen([FromRoute] Guid Id, [FromForm] PrescreeningDokumenPutCommand putPrescreeningDokumen)
        {
            putPrescreeningDokumen.Id = Id;
            var result = await _mediator.Send(putPrescreeningDokumen);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete PrescreeningDokumen
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeletePrescreeningDokumen")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeletePrescreeningDokumen([FromRoute] Guid Id, [FromBody]PrescreeningDokumenDeleteCommand deleteCommand)
        {
            deleteCommand.Id = Id;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}