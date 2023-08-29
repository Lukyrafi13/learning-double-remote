using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RFJenisDuplikasis;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFJenisDuplikasis.Commands;
using NewLMS.Umkm.MediatR.Features.RFJenisDuplikasis.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.RFJenisDuplikasi
{
    public class RFJenisDuplikasiController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFJenisDuplikasi
        /// </summary>
        /// <param name="mediator"></param>
        public RFJenisDuplikasiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFJenisDuplikasi By Id
        /// </summary>
        /// <param name="JenisCode"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetRFJenisDuplikasiById")]
        [Produces("application/json", "application/xml", Type = typeof(RFJenisDuplikasiResponseDto))]
        public async Task<IActionResult> GetRFJenisDuplikasiById(string JenisCode)
        {
            var getGenderQuery = new RFJenisDuplikasiGetQuery { JenisCode = JenisCode };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFJenisDuplikasi
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFJenisDuplikasiList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFJenisDuplikasiResponseDto>>))]
        public async Task<IActionResult> GetRFJenisDuplikasiList(RFJenisDuplikasisGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFJenisDuplikasi
        /// </summary>
        /// <param name="postRFJenisDuplikasi"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFJenisDuplikasi")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFJenisDuplikasiResponseDto>))]
        public async Task<IActionResult> AddRFJenisDuplikasi(RFJenisDuplikasiPostCommand postRFJenisDuplikasi)
        {
            var result = await _mediator.Send(postRFJenisDuplikasi);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFJenisDuplikasiById", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit RFJenisDuplikasi
        /// </summary>
        /// <param name="JenisCode"></param>
        /// <param name="putRFJenisDuplikasi"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditRFJenisDuplikasi")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFJenisDuplikasiResponseDto>))]
        public async Task<IActionResult> EditRFJenisDuplikasi([FromRoute] string JenisCode, [FromBody] RFJenisDuplikasiPutCommand putRFJenisDuplikasi)
        {
            putRFJenisDuplikasi.JenisCode = JenisCode;
            var result = await _mediator.Send(putRFJenisDuplikasi);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFJenisDuplikasi
        /// </summary>
        /// <param name="JenisCode"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteRFJenisDuplikasi")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFJenisDuplikasi([FromRoute] string JenisCode, [FromBody] RFJenisDuplikasiDeleteCommand deleteCommand)
        {
            deleteCommand.JenisCode = JenisCode;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}