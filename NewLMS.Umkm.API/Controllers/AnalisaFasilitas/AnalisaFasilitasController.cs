using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.AnalisaFasilitass;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.AnalisaFasilitass.Commands;
using NewLMS.Umkm.MediatR.Features.AnalisaFasilitass.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.AnalisaFasilitas
{
    public class AnalisaFasilitasController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// AnalisaFasilitas
        /// </summary>
        /// <param name="mediator"></param>
        public AnalisaFasilitasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get AnalisaFasilitas By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetAnalisaFasilitasByCode")]
        [Produces("application/json", "application/xml", Type = typeof(AnalisaFasilitasResponseDto))]
        public async Task<IActionResult> GetAnalisaFasilitasByCode(Guid Id)
        {
            var getSCOQuery = new AnalisaFasilitasGetQuery { Id = Id };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get AnalisaFasilitas
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetAnalisaFasilitasList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<AnalisaFasilitasResponseDto>>))]
        public async Task<IActionResult> GetAnalisaFasilitasList(AnalisaFasilitassGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New AnalisaFasilitas
        /// </summary>
        /// <param name="postAnalisaFasilitas"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddAnalisaFasilitas")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<AnalisaFasilitasResponseDto>))]
        public async Task<IActionResult> AddAnalisaFasilitas(AnalisaFasilitasPostCommand postAnalisaFasilitas)
        {
            var result = await _mediator.Send(postAnalisaFasilitas);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetAnalisaFasilitasByCode", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit AnalisaFasilitas
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putAnalisaFasilitas"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditAnalisaFasilitas")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<AnalisaFasilitasResponseDto>))]
        public async Task<IActionResult> EditAnalisaFasilitas([FromRoute] Guid Id, [FromBody] AnalisaFasilitasPutCommand putAnalisaFasilitas)
        {
            putAnalisaFasilitas.Id = Id;
            var result = await _mediator.Send(putAnalisaFasilitas);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete AnalisaFasilitas
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteAnalisaFasilitas")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteAnalisaFasilitas([FromRoute] Guid Id, [FromBody]AnalisaFasilitasDeleteCommand deleteCommand)
        {
            deleteCommand.Id = Id;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}