using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.AnalisaSyaratKredits;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.AnalisaSyaratKredits.Commands;
using NewLMS.Umkm.MediatR.Features.AnalisaSyaratKredits.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.AnalisaSyaratKredit
{
    public class AnalisaSyaratKreditController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// AnalisaSyaratKredit
        /// </summary>
        /// <param name="mediator"></param>
        public AnalisaSyaratKreditController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get AnalisaSyaratKredit By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetAnalisaSyaratKreditByCode")]
        [Produces("application/json", "application/xml", Type = typeof(AnalisaSyaratKreditResponseDto))]
        public async Task<IActionResult> GetAnalisaSyaratKreditByCode(Guid Id)
        {
            var getSCOQuery = new AnalisaSyaratKreditGetQuery { Id = Id };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get AnalisaSyaratKredit
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetAnalisaSyaratKreditList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<AnalisaSyaratKreditResponseDto>>))]
        public async Task<IActionResult> GetAnalisaSyaratKreditList(AnalisaSyaratKreditsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New AnalisaSyaratKredit
        /// </summary>
        /// <param name="postAnalisaSyaratKredit"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddAnalisaSyaratKredit")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<AnalisaSyaratKreditResponseDto>))]
        public async Task<IActionResult> AddAnalisaSyaratKredit(AnalisaSyaratKreditPostCommand postAnalisaSyaratKredit)
        {
            var result = await _mediator.Send(postAnalisaSyaratKredit);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetAnalisaSyaratKreditByCode", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit AnalisaSyaratKredit
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putAnalisaSyaratKredit"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditAnalisaSyaratKredit")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<AnalisaSyaratKreditResponseDto>))]
        public async Task<IActionResult> EditAnalisaSyaratKredit([FromRoute] Guid Id, [FromBody] AnalisaSyaratKreditPutCommand putAnalisaSyaratKredit)
        {
            putAnalisaSyaratKredit.Id = Id;
            var result = await _mediator.Send(putAnalisaSyaratKredit);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete AnalisaSyaratKredit
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteAnalisaSyaratKredit")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteAnalisaSyaratKredit([FromRoute] Guid Id, [FromBody]AnalisaSyaratKreditDeleteCommand deleteCommand)
        {
            deleteCommand.Id = Id;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}