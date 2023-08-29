using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFLokasiUsahas;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFLokasiUsahas.Commands;
using NewLMS.UMKM.MediatR.Features.RFLokasiUsahas.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RFLokasiUsaha
{
    public class RFLokasiUsahaController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFLokasiUsaha
        /// </summary>
        /// <param name="mediator"></param>
        public RFLokasiUsahaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFLokasiUsaha By ANL_CODE
        /// </summary>
        /// <param name="ANL_CODE"></param>
        /// <returns></returns>
        [HttpGet("get/{ANL_CODE}", Name = "GetRFLokasiUsahaByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFLokasiUsahaResponseDto))]
        public async Task<IActionResult> GetRFLokasiUsahaByCode(string ANL_CODE)
        {
            var getSCOQuery = new RFLokasiUsahaGetQuery { ANL_CODE = ANL_CODE };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFLokasiUsaha By ANL_CODE
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFLokasiUsahaList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFLokasiUsahaResponseDto>>))]
        public async Task<IActionResult> GetRFLokasiUsahaList(RFLokasiUsahasGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFLokasiUsaha
        /// </summary>
        /// <param name="postRFLokasiUsaha"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFLokasiUsaha")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFLokasiUsahaResponseDto>))]
        public async Task<IActionResult> AddRFLokasiUsaha(RFLokasiUsahaPostCommand postRFLokasiUsaha)
        {
            var result = await _mediator.Send(postRFLokasiUsaha);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFLokasiUsahaByCode", new { id = result.Data.ANL_CODE }, result.Data);
        }

        /// <summary>
        /// Put Edit RFLokasiUsaha
        /// </summary>
        /// <param name="ANL_CODE"></param>
        /// <param name="putRFLokasiUsaha"></param>
        /// <returns></returns>
        [HttpPut("put/{ANL_CODE}", Name = "EditRFLokasiUsaha")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFLokasiUsahaResponseDto>))]
        public async Task<IActionResult> EditRFLokasiUsaha([FromRoute] string ANL_CODE, [FromBody] RFLokasiUsahaPutCommand putRFLokasiUsaha)
        {
            putRFLokasiUsaha.ANL_CODE = ANL_CODE;
            var result = await _mediator.Send(putRFLokasiUsaha);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFLokasiUsaha
        /// </summary>
        /// <param name="ANL_CODE"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{ANL_CODE}", Name = "DeleteRFLokasiUsaha")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFLokasiUsaha([FromRoute] string ANL_CODE, [FromBody]RFLokasiUsahaDeleteCommand deleteCommand)
        {
            deleteCommand.ANL_CODE = ANL_CODE;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}