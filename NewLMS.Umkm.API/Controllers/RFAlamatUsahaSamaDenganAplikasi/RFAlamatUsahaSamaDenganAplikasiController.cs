using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFAlamatUsahaSamaDenganAplikasis;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFAlamatUsahaSamaDenganAplikasis.Commands;
using NewLMS.UMKM.MediatR.Features.RFAlamatUsahaSamaDenganAplikasis.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RFAlamatUsahaSamaDenganAplikasi
{
    public class RFAlamatUsahaSamaDenganAplikasiController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFAlamatUsahaSamaDenganAplikasi
        /// </summary>
        /// <param name="mediator"></param>
        public RFAlamatUsahaSamaDenganAplikasiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFAlamatUsahaSamaDenganAplikasi By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetRFAlamatUsahaSamaDenganAplikasiById")]
        [Produces("application/json", "application/xml", Type = typeof(RFAlamatUsahaSamaDenganAplikasiResponseDto))]
        public async Task<IActionResult> GetRFAlamatUsahaSamaDenganAplikasiById(string StatusAlamat_Code)
        {
            var getGenderQuery = new RFAlamatUsahaSamaDenganAplikasiGetQuery { StatusAlamat_Code = StatusAlamat_Code };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFAlamatUsahaSamaDenganAplikasi By Id
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFAlamatUsahaSamaDenganAplikasiList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFAlamatUsahaSamaDenganAplikasiResponseDto>>))]
        public async Task<IActionResult> GetRFAlamatUsahaSamaDenganAplikasiList(RFAlamatUsahaSamaDenganAplikasisGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFAlamatUsahaSamaDenganAplikasi
        /// </summary>
        /// <param name="postRFAlamatUsahaSamaDenganAplikasi"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFAlamatUsahaSamaDenganAplikasi")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFAlamatUsahaSamaDenganAplikasiResponseDto>))]
        public async Task<IActionResult> AddRFAlamatUsahaSamaDenganAplikasi(RFAlamatUsahaSamaDenganAplikasiPostCommand postRFAlamatUsahaSamaDenganAplikasi)
        {
            var result = await _mediator.Send(postRFAlamatUsahaSamaDenganAplikasi);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFAlamatUsahaSamaDenganAplikasiById", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit RFAlamatUsahaSamaDenganAplikasi
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putRFAlamatUsahaSamaDenganAplikasi"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditRFAlamatUsahaSamaDenganAplikasi")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFAlamatUsahaSamaDenganAplikasiResponseDto>))]
        public async Task<IActionResult> EditRFAlamatUsahaSamaDenganAplikasi([FromRoute] string StatusAlamat_Code, [FromBody] RFAlamatUsahaSamaDenganAplikasiPutCommand putRFAlamatUsahaSamaDenganAplikasi)
        {
            putRFAlamatUsahaSamaDenganAplikasi.StatusAlamat_Code = StatusAlamat_Code;
            var result = await _mediator.Send(putRFAlamatUsahaSamaDenganAplikasi);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFAlamatUsahaSamaDenganAplikasi
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteRFAlamatUsahaSamaDenganAplikasi")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFAlamatUsahaSamaDenganAplikasi([FromRoute] string StatusAlamat_Code, [FromBody] RFAlamatUsahaSamaDenganAplikasiDeleteCommand deleteCommand)
        {
            deleteCommand.StatusAlamat_Code = StatusAlamat_Code;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}