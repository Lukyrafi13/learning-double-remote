using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFJumlahPegawais;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFJumlahPegawais.Commands;
using NewLMS.UMKM.MediatR.Features.RFJumlahPegawais.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RFJumlahPegawai
{
    public class RFJumlahPegawaiController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFJumlahPegawai
        /// </summary>
        /// <param name="mediator"></param>
        public RFJumlahPegawaiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFJumlahPegawai By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetRFJumlahPegawaiById")]
        [Produces("application/json", "application/xml", Type = typeof(RFJumlahPegawaiResponseDto))]
        public async Task<IActionResult> GetRFJumlahPegawaiById(string ANL_CODE)
        {
            var getGenderQuery = new RFJumlahPegawaiGetQuery { ANL_CODE = ANL_CODE };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFJumlahPegawai
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFJumlahPegawaiList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFJumlahPegawaiResponseDto>>))]
        public async Task<IActionResult> GetRFJumlahPegawaiList(RFJumlahPegawaisGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFJumlahPegawai
        /// </summary>
        /// <param name="postRFJumlahPegawai"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFJumlahPegawai")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFJumlahPegawaiResponseDto>))]
        public async Task<IActionResult> AddRFJumlahPegawai(RFJumlahPegawaiPostCommand postRFJumlahPegawai)
        {
            var result = await _mediator.Send(postRFJumlahPegawai);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFJumlahPegawaiById", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit RFJumlahPegawai
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putRFJumlahPegawai"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditRFJumlahPegawai")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFJumlahPegawaiResponseDto>))]
        public async Task<IActionResult> EditRFJumlahPegawai([FromRoute] string ANL_CODE, [FromBody] RFJumlahPegawaiPutCommand putRFJumlahPegawai)
        {
            putRFJumlahPegawai.ANL_CODE = ANL_CODE;
            var result = await _mediator.Send(putRFJumlahPegawai);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFJumlahPegawai
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteRFJumlahPegawai")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFJumlahPegawai([FromRoute] string ANL_CODE, [FromBody] RFJumlahPegawaiDeleteCommand deleteCommand)
        {
            deleteCommand.ANL_CODE = ANL_CODE;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}