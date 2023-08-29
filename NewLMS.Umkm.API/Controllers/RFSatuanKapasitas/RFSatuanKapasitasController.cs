using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RFSatuanKapasitass;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFSatuanKapasitass.Commands;
using NewLMS.Umkm.MediatR.Features.RFSatuanKapasitass.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.RFSatuanKapasitas
{
    public class RFSatuanKapasitasController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFSatuanKapasitas
        /// </summary>
        /// <param name="mediator"></param>
        public RFSatuanKapasitasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFSatuanKapasitas By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetRFSatuanKapasitasById")]
        [Produces("application/json", "application/xml", Type = typeof(RFSatuanKapasitasResponseDto))]
        public async Task<IActionResult> GetRFSatuanKapasitasById(string SatuanKapasitas_Id)
        {
            var getGenderQuery = new RFSatuanKapasitasGetQuery { SatuanKapasitas_Id = SatuanKapasitas_Id };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFSatuanKapasitas
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFSatuanKapasitasList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFSatuanKapasitasResponseDto>>))]
        public async Task<IActionResult> GetRFSatuanKapasitasList(RFSatuanKapasitassGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFSatuanKapasitas
        /// </summary>
        /// <param name="postRFSatuanKapasitas"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFSatuanKapasitas")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFSatuanKapasitasResponseDto>))]
        public async Task<IActionResult> AddRFSatuanKapasitas(RFSatuanKapasitasPostCommand postRFSatuanKapasitas)
        {
            var result = await _mediator.Send(postRFSatuanKapasitas);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFSatuanKapasitasById", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit RFSatuanKapasitas
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putRFSatuanKapasitas"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditRFSatuanKapasitas")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFSatuanKapasitasResponseDto>))]
        public async Task<IActionResult> EditRFSatuanKapasitas([FromRoute] string SatuanKapasitas_Id, [FromBody] RFSatuanKapasitasPutCommand putRFSatuanKapasitas)
        {
            putRFSatuanKapasitas.SatuanKapasitas_Id = SatuanKapasitas_Id;
            var result = await _mediator.Send(putRFSatuanKapasitas);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFSatuanKapasitas
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteRFSatuanKapasitas")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFSatuanKapasitas([FromRoute] string SatuanKapasitas_Id, [FromBody] RFSatuanKapasitasDeleteCommand deleteCommand)
        {
            deleteCommand.SatuanKapasitas_Id = SatuanKapasitas_Id;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}