using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RFKodeDinass;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFKodeDinass.Commands;
using NewLMS.Umkm.MediatR.Features.RFKodeDinass.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.RFKodeDinas
{
    public class RFKodeDinasController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFKodeDinas
        /// </summary>
        /// <param name="mediator"></param>
        public RFKodeDinasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFKodeDinas By KodeDinas
        /// </summary>
        /// <param name="KodeDinas"></param>
        /// <returns></returns>
        [HttpGet("get/{KodeDinas}", Name = "GetRFKodeDinasByKodeDinas")]
        [Produces("application/json", "application/xml", Type = typeof(RFKodeDinasResponseDto))]
        public async Task<IActionResult> GetRFKodeDinasByKodeDinas(string KodeDinas)
        {
            var getGenderQuery = new RFKodeDinassGetByKodeDinasQuery { KodeDinas = KodeDinas };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFKodeDinas By KodeDinas
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFKodeDinasList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFKodeDinasResponseDto>>))]
        public async Task<IActionResult> GetRFKodeDinasList(RFKodeDinassGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFKodeDinas
        /// </summary>
        /// <param name="postRFKodeDinas"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFKodeDinas")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFKodeDinasResponseDto>))]
        public async Task<IActionResult> AddRFKodeDinas(RFKodeDinasPostCommand postRFKodeDinas)
        {
            var result = await _mediator.Send(postRFKodeDinas);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFKodeDinasByKodeDinas", new { id = result.Data.KodeDinas }, result.Data);
        }

        /// <summary>
        /// Put Edit RFKodeDinas
        /// </summary>
        /// <param name="KodeDinas"></param>
        /// <param name="putRFKodeDinas"></param>
        /// <returns></returns>
        [HttpPut("put/{KodeDinas}", Name = "EditRFKodeDinas")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFKodeDinasResponseDto>))]
        public async Task<IActionResult> EditRFKodeDinas([FromRoute] string KodeDinas, [FromBody] RFKodeDinasPutCommand putRFKodeDinas)
        {
            putRFKodeDinas.KodeDinas = KodeDinas;
            var result = await _mediator.Send(putRFKodeDinas);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFKodeDinas
        /// </summary>
        /// <param name="KodeDinas"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{KodeDinas}", Name = "DeleteRFKodeDinas")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFKodeDinas([FromRoute] string KodeDinas, [FromBody]RFKodeDinasDeleteCommand deleteCommand)
        {
            deleteCommand.KodeDinas = KodeDinas;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}