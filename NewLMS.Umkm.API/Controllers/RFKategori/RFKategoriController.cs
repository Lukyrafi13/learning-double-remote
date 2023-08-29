using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RFKategoris;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFKategoris.Commands;
using NewLMS.Umkm.MediatR.Features.RFKategoris.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.RFKategori
{
    public class RFKategoriController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFKategori
        /// </summary>
        /// <param name="mediator"></param>
        public RFKategoriController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFKategori By KategoriCode
        /// </summary>
        /// <param name="KategoriCode"></param>
        /// <returns></returns>
        [HttpGet("get/{KategoriCode}", Name = "GetRFKategoriByKategoriCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFKategoriResponseDto))]
        public async Task<IActionResult> GetRFKategoriByKategoriCode(string KategoriCode)
        {
            var getGenderQuery = new RFKategorisGetByKategoriCodeQuery { KategoriCode = KategoriCode };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFKategori By KategoriCode
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFKategoriList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFKategoriResponseDto>>))]
        public async Task<IActionResult> GetRFKategoriList(RFKategorisGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFKategori
        /// </summary>
        /// <param name="postRFKategori"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFKategori")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFKategoriResponseDto>))]
        public async Task<IActionResult> AddRFKategori(RFKategoriPostCommand postRFKategori)
        {
            var result = await _mediator.Send(postRFKategori);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFKategoriByKategoriCode", new { id = result.Data.KategoriCode }, result.Data);
        }

        /// <summary>
        /// Put Edit RFKategori
        /// </summary>
        /// <param name="KategoriCode"></param>
        /// <param name="putRFKategori"></param>
        /// <returns></returns>
        [HttpPut("put/{KategoriCode}", Name = "EditRFKategori")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFKategoriResponseDto>))]
        public async Task<IActionResult> EditRFKategori([FromRoute] string KategoriCode, [FromBody] RFKategoriPutCommand putRFKategori)
        {
            putRFKategori.KategoriCode = KategoriCode;
            var result = await _mediator.Send(putRFKategori);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFKategori
        /// </summary>
        /// <param name="KategoriCode"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{KategoriCode}", Name = "DeleteRFKategori")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFKategori([FromRoute] string KategoriCode, [FromBody]RFKategoriDeleteCommand deleteCommand)
        {
            deleteCommand.KategoriCode = KategoriCode;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}