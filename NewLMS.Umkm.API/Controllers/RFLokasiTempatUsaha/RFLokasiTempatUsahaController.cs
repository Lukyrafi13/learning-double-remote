using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RFLokasiTempatUsahas;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFLokasiTempatUsahas.Commands;
using NewLMS.Umkm.MediatR.Features.RFLokasiTempatUsahas.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.RFLokasiTempatUsaha
{
    public class RFLokasiTempatUsahaController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFLokasiTempatUsaha
        /// </summary>
        /// <param name="mediator"></param>
        public RFLokasiTempatUsahaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFLokasiTempatUsaha By ANL_CODE
        /// </summary>
        /// <param name="ANL_CODE"></param>
        /// <returns></returns>
        [HttpGet("get/{ANL_CODE}", Name = "GetRFLokasiTempatUsahaByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFLokasiTempatUsahaResponseDto))]
        public async Task<IActionResult> GetRFLokasiTempatUsahaByCode(string ANL_CODE)
        {
            var getSCOQuery = new RFLokasiTempatUsahaGetQuery { ANL_CODE = ANL_CODE };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFLokasiTempatUsaha By ANL_CODE
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFLokasiTempatUsahaList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFLokasiTempatUsahaResponseDto>>))]
        public async Task<IActionResult> GetRFLokasiTempatUsahaList(RFLokasiTempatUsahasGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFLokasiTempatUsaha
        /// </summary>
        /// <param name="postRFLokasiTempatUsaha"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFLokasiTempatUsaha")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFLokasiTempatUsahaResponseDto>))]
        public async Task<IActionResult> AddRFLokasiTempatUsaha(RFLokasiTempatUsahaPostCommand postRFLokasiTempatUsaha)
        {
            var result = await _mediator.Send(postRFLokasiTempatUsaha);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFLokasiTempatUsahaByCode", new { id = result.Data.ANL_CODE }, result.Data);
        }

        /// <summary>
        /// Put Edit RFLokasiTempatUsaha
        /// </summary>
        /// <param name="ANL_CODE"></param>
        /// <param name="putRFLokasiTempatUsaha"></param>
        /// <returns></returns>
        [HttpPut("put/{ANL_CODE}", Name = "EditRFLokasiTempatUsaha")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFLokasiTempatUsahaResponseDto>))]
        public async Task<IActionResult> EditRFLokasiTempatUsaha([FromRoute] string ANL_CODE, [FromBody] RFLokasiTempatUsahaPutCommand putRFLokasiTempatUsaha)
        {
            putRFLokasiTempatUsaha.ANL_CODE = ANL_CODE;
            var result = await _mediator.Send(putRFLokasiTempatUsaha);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFLokasiTempatUsaha
        /// </summary>
        /// <param name="ANL_CODE"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{ANL_CODE}", Name = "DeleteRFLokasiTempatUsaha")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFLokasiTempatUsaha([FromRoute] string ANL_CODE, [FromBody]RFLokasiTempatUsahaDeleteCommand deleteCommand)
        {
            deleteCommand.ANL_CODE = ANL_CODE;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}