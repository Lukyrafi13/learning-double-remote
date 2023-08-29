using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RFKelompokUsahas;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFKelompokUsahas.Commands;
using NewLMS.Umkm.MediatR.Features.RFKelompokUsahas.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.RFKelompokUsaha
{
    public class RFKelompokUsahaController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFKelompokUsaha
        /// </summary>
        /// <param name="mediator"></param>
        public RFKelompokUsahaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFKelompokUsaha By ANL_CODE
        /// </summary>
        /// <param name="ANL_CODE"></param>
        /// <returns></returns>
        [HttpGet("get/{ANL_CODE}", Name = "GetRFKelompokUsahaByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFKelompokUsahaResponseDto))]
        public async Task<IActionResult> GetRFKelompokUsahaByCode(string ANL_CODE)
        {
            var getSCOQuery = new RFKelompokUsahaGetQuery { ANL_CODE = ANL_CODE };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFKelompokUsaha By ANL_CODE
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFKelompokUsahaList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFKelompokUsahaResponseDto>>))]
        public async Task<IActionResult> GetRFKelompokUsahaList(RFKelompokUsahasGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFKelompokUsaha
        /// </summary>
        /// <param name="postRFKelompokUsaha"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFKelompokUsaha")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFKelompokUsahaResponseDto>))]
        public async Task<IActionResult> AddRFKelompokUsaha(RFKelompokUsahaPostCommand postRFKelompokUsaha)
        {
            var result = await _mediator.Send(postRFKelompokUsaha);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFKelompokUsahaByCode", new { id = result.Data.ANL_CODE }, result.Data);
        }

        /// <summary>
        /// Put Edit RFKelompokUsaha
        /// </summary>
        /// <param name="ANL_CODE"></param>
        /// <param name="putRFKelompokUsaha"></param>
        /// <returns></returns>
        [HttpPut("put/{ANL_CODE}", Name = "EditRFKelompokUsaha")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFKelompokUsahaResponseDto>))]
        public async Task<IActionResult> EditRFKelompokUsaha([FromRoute] string ANL_CODE, [FromBody] RFKelompokUsahaPutCommand putRFKelompokUsaha)
        {
            putRFKelompokUsaha.ANL_CODE = ANL_CODE;
            var result = await _mediator.Send(putRFKelompokUsaha);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFKelompokUsaha
        /// </summary>
        /// <param name="ANL_CODE"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{ANL_CODE}", Name = "DeleteRFKelompokUsaha")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFKelompokUsaha([FromRoute] string ANL_CODE, [FromBody]RFKelompokUsahaDeleteCommand deleteCommand)
        {
            deleteCommand.ANL_CODE = ANL_CODE;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}