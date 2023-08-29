using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RFJenisUsahaYangDihindaris;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFJenisUsahaYangDihindaris.Commands;
using NewLMS.Umkm.MediatR.Features.RFJenisUsahaYangDihindaris.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.RFJenisUsahaYangDihindari
{
    public class RFJenisUsahaYangDihindariController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFJenisUsahaYangDihindari
        /// </summary>
        /// <param name="mediator"></param>
        public RFJenisUsahaYangDihindariController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFJenisUsahaYangDihindari By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetRFJenisUsahaYangDihindariById")]
        [Produces("application/json", "application/xml", Type = typeof(RFJenisUsahaYangDihindariResponseDto))]
        public async Task<IActionResult> GetRFJenisUsahaYangDihindariById(string StatusJenisUsaha_Code)
        {
            var getGenderQuery = new RFJenisUsahaYangDihindariGetQuery { StatusJenisUsaha_Code = StatusJenisUsaha_Code };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFJenisUsahaYangDihindari
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFJenisUsahaYangDihindariList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFJenisUsahaYangDihindariResponseDto>>))]
        public async Task<IActionResult> GetRFJenisUsahaYangDihindariList(RFJenisUsahaYangDihindarisGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFJenisUsahaYangDihindari
        /// </summary>
        /// <param name="postRFJenisUsahaYangDihindari"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFJenisUsahaYangDihindari")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFJenisUsahaYangDihindariResponseDto>))]
        public async Task<IActionResult> AddRFJenisUsahaYangDihindari(RFJenisUsahaYangDihindariPostCommand postRFJenisUsahaYangDihindari)
        {
            var result = await _mediator.Send(postRFJenisUsahaYangDihindari);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFJenisUsahaYangDihindariById", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit RFJenisUsahaYangDihindari
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putRFJenisUsahaYangDihindari"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditRFJenisUsahaYangDihindari")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFJenisUsahaYangDihindariResponseDto>))]
        public async Task<IActionResult> EditRFJenisUsahaYangDihindari([FromRoute] string StatusJenisUsaha_Code, [FromBody] RFJenisUsahaYangDihindariPutCommand putRFJenisUsahaYangDihindari)
        {
            putRFJenisUsahaYangDihindari.StatusJenisUsaha_Code = StatusJenisUsaha_Code;
            var result = await _mediator.Send(putRFJenisUsahaYangDihindari);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFJenisUsahaYangDihindari
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteRFJenisUsahaYangDihindari")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFJenisUsahaYangDihindari([FromRoute] string StatusJenisUsaha_Code, [FromBody] RFJenisUsahaYangDihindariDeleteCommand deleteCommand)
        {
            deleteCommand.StatusJenisUsaha_Code = StatusJenisUsaha_Code;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}