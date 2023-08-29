using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RFJenisUsahaMaps;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFJenisUsahaMaps.Commands;
using NewLMS.Umkm.MediatR.Features.RFJenisUsahaMaps.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.RFJenisUsahaMap
{
    public class RFJenisUsahaMapController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFJenisUsahaMap
        /// </summary>
        /// <param name="mediator"></param>
        public RFJenisUsahaMapController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFJenisUsahaMap By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetRFJenisUsahaMapByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFJenisUsahaMapResponseDto))]
        public async Task<IActionResult> GetRFJenisUsahaMapByCode(Guid Id)
        {
            var getSCOQuery = new RFJenisUsahaMapGetQuery { Id = Id };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFJenisUsaha By RFKelompokUsaha KELOMPOK_CODE
        /// </summary>
        /// <param name="KELOMPOK_CODE"></param>
        /// <returns></returns>
        [HttpGet("jenis-by-kelompok/get/{KELOMPOK_CODE}", Name = "GetRFJenisUsahaByKelompokCode")]
        [Produces("application/json", "application/xml", Type = typeof(IEnumerable<RFJenisUsahaByKelompokResponse>))]
        public async Task<IActionResult> GetRFJenisUsahaByKelompokCode(string KELOMPOK_CODE)
        {
            var getSCOQuery = new RFJenisUsahaByKelompokCodeQuery { KELOMPOK_CODE = KELOMPOK_CODE };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFJenisUsahaMap
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFJenisUsahaMapList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFJenisUsahaMapResponseDto>>))]
        public async Task<IActionResult> GetRFJenisUsahaMapList(RFJenisUsahaMapsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFJenisUsahaMap
        /// </summary>
        /// <param name="postRFJenisUsahaMap"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFJenisUsahaMap")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFJenisUsahaMapResponseDto>))]
        public async Task<IActionResult> AddRFJenisUsahaMap(RFJenisUsahaMapPostCommand postRFJenisUsahaMap)
        {
            var result = await _mediator.Send(postRFJenisUsahaMap);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFJenisUsahaMapByCode", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit RFJenisUsahaMap
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putRFJenisUsahaMap"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditRFJenisUsahaMap")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFJenisUsahaMapResponseDto>))]
        public async Task<IActionResult> EditRFJenisUsahaMap([FromRoute] Guid Id, [FromBody] RFJenisUsahaMapPutCommand putRFJenisUsahaMap)
        {
            putRFJenisUsahaMap.Id = Id;
            var result = await _mediator.Send(putRFJenisUsahaMap);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFJenisUsahaMap
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteRFJenisUsahaMap")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFJenisUsahaMap([FromRoute] Guid Id, [FromBody]RFJenisUsahaMapDeleteCommand deleteCommand)
        {
            deleteCommand.Id = Id;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}