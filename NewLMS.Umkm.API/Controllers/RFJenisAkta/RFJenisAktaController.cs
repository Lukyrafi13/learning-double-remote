using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFJenisAktas;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFJenisAktas.Commands;
using NewLMS.UMKM.MediatR.Features.RFJenisAktas.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RFJenisAkta
{
    public class RFJenisAktaController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFJenisAkta
        /// </summary>
        /// <param name="mediator"></param>
        public RFJenisAktaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFJenisAkta By AktaCode
        /// </summary>
        /// <param name="AktaCode"></param>
        /// <returns></returns>
        [HttpGet("get/{AktaCode}", Name = "GetRFJenisAktaByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFJenisAktaResponseDto))]
        public async Task<IActionResult> GetRFJenisAktaByCode(string AktaCode)
        {
            var getSCOQuery = new RFJenisAktaGetQuery { AktaCode = AktaCode };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFJenisAkta
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFJenisAktaList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFJenisAktaResponseDto>>))]
        public async Task<IActionResult> GetRFJenisAktaList(RFJenisAktasGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFJenisAkta
        /// </summary>
        /// <param name="postRFJenisAkta"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFJenisAkta")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFJenisAktaResponseDto>))]
        public async Task<IActionResult> AddRFJenisAkta(RFJenisAktaPostCommand postRFJenisAkta)
        {
            var result = await _mediator.Send(postRFJenisAkta);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFJenisAktaByCode", new { AktaCode = result.Data.AktaCode }, result.Data);
        }

        /// <summary>
        /// Put Edit RFJenisAkta
        /// </summary>
        /// <param name="AktaCode"></param>
        /// <param name="putRFJenisAkta"></param>
        /// <returns></returns>
        [HttpPut("put/{AktaCode}", Name = "EditRFJenisAkta")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFJenisAktaResponseDto>))]
        public async Task<IActionResult> EditRFJenisAkta([FromRoute] string AktaCode, [FromBody] RFJenisAktaPutCommand putRFJenisAkta)
        {
            putRFJenisAkta.AktaCode = AktaCode;
            var result = await _mediator.Send(putRFJenisAkta);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFJenisAkta
        /// </summary>
        /// <param name="AktaCode"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{AktaCode}", Name = "DeleteRFJenisAkta")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFJenisAkta([FromRoute] string AktaCode, [FromBody]RFJenisAktaDeleteCommand deleteCommand)
        {
            deleteCommand.AktaCode = AktaCode;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}