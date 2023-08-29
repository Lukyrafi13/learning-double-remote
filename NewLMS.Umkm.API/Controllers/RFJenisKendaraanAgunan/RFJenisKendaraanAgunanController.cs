using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RFJenisKendaraanAgunans;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFJenisKendaraanAgunans.Commands;
using NewLMS.Umkm.MediatR.Features.RFJenisKendaraanAgunans.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.RFJenisKendaraanAgunan
{
    public class RFJenisKendaraanAgunanController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFJenisKendaraanAgunan
        /// </summary>
        /// <param name="mediator"></param>
        public RFJenisKendaraanAgunanController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFJenisKendaraanAgunan By VEH_CODE
        /// </summary>
        /// <param name="VEH_CODE"></param>
        /// <returns></returns>
        [HttpGet("get/{VEH_CODE}", Name = "GetRFJenisKendaraanAgunanByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFJenisKendaraanAgunanResponseDto))]
        public async Task<IActionResult> GetRFJenisKendaraanAgunanByCode(string VEH_CODE)
        {
            var getSCOQuery = new RFJenisKendaraanAgunanGetQuery { VEH_CODE = VEH_CODE };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFJenisKendaraanAgunan By VEH_CODE
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFJenisKendaraanAgunanList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFJenisKendaraanAgunanResponseDto>>))]
        public async Task<IActionResult> GetRFJenisKendaraanAgunanList(RFJenisKendaraanAgunansGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFJenisKendaraanAgunan
        /// </summary>
        /// <param name="postRFJenisKendaraanAgunan"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFJenisKendaraanAgunan")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFJenisKendaraanAgunanResponseDto>))]
        public async Task<IActionResult> AddRFJenisKendaraanAgunan(RFJenisKendaraanAgunanPostCommand postRFJenisKendaraanAgunan)
        {
            var result = await _mediator.Send(postRFJenisKendaraanAgunan);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFJenisKendaraanAgunanByCode", new { id = result.Data.VEH_CODE }, result.Data);
        }

        /// <summary>
        /// Put Edit RFJenisKendaraanAgunan
        /// </summary>
        /// <param name="VEH_CODE"></param>
        /// <param name="putRFJenisKendaraanAgunan"></param>
        /// <returns></returns>
        [HttpPut("put/{VEH_CODE}", Name = "EditRFJenisKendaraanAgunan")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFJenisKendaraanAgunanResponseDto>))]
        public async Task<IActionResult> EditRFJenisKendaraanAgunan([FromRoute] string VEH_CODE, [FromBody] RFJenisKendaraanAgunanPutCommand putRFJenisKendaraanAgunan)
        {
            putRFJenisKendaraanAgunan.VEH_CODE = VEH_CODE;
            var result = await _mediator.Send(putRFJenisKendaraanAgunan);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFJenisKendaraanAgunan
        /// </summary>
        /// <param name="VEH_CODE"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{VEH_CODE}", Name = "DeleteRFJenisKendaraanAgunan")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFJenisKendaraanAgunan([FromRoute] string VEH_CODE, [FromBody]RFJenisKendaraanAgunanDeleteCommand deleteCommand)
        {
            deleteCommand.VEH_CODE = VEH_CODE;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}