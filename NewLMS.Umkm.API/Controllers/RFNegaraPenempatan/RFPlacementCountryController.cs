using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFNegaraPenempatans;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFNegaraPenempatans.Commands;
using NewLMS.UMKM.MediatR.Features.RFNegaraPenempatans.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RFNegaraPenempatan
{
    public class RFPlacementCountryController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFNegaraPenempatan
        /// </summary>
        /// <param name="mediator"></param>
        public RFPlacementCountryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFNegaraPenempatan By NegaraCode
        /// </summary>
        /// <param name="NegaraCode"></param>
        /// <returns></returns>
        [HttpGet("get/{NegaraCode}", Name = "GetRFNegaraPenempatanByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFPlacementCountryResponseDto))]
        public async Task<IActionResult> GetRFNegaraPenempatanByCode(string NegaraCode)
        {
            var getSCOQuery = new RFNegaraPenempatanGetQuery { NegaraCode = NegaraCode };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFNegaraPenempatan By NegaraCode
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFNegaraPenempatanList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFPlacementCountryResponseDto>>))]
        public async Task<IActionResult> GetRFNegaraPenempatanList(RFNegaraPenempatansGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFNegaraPenempatan
        /// </summary>
        /// <param name="postRFNegaraPenempatan"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFNegaraPenempatan")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFPlacementCountryResponseDto>))]
        public async Task<IActionResult> AddRFNegaraPenempatan(RFNegaraPenempatanPostCommand postRFNegaraPenempatan)
        {
            var result = await _mediator.Send(postRFNegaraPenempatan);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFNegaraPenempatanByCode", new { id = result.Data.NegaraCode }, result.Data);
        }

        /// <summary>
        /// Put Edit RFNegaraPenempatan
        /// </summary>
        /// <param name="NegaraCode"></param>
        /// <param name="putRFNegaraPenempatan"></param>
        /// <returns></returns>
        [HttpPut("put/{NegaraCode}", Name = "EditRFNegaraPenempatan")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFPlacementCountryResponseDto>))]
        public async Task<IActionResult> EditRFNegaraPenempatan([FromRoute] string NegaraCode, [FromBody] RFNegaraPenempatanPutCommand putRFNegaraPenempatan)
        {
            putRFNegaraPenempatan.NegaraCode = NegaraCode;
            var result = await _mediator.Send(putRFNegaraPenempatan);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFNegaraPenempatan
        /// </summary>
        /// <param name="NegaraCode"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{NegaraCode}", Name = "DeleteRFNegaraPenempatan")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFNegaraPenempatan([FromRoute] string NegaraCode, [FromBody]RFNegaraPenempatanDeleteCommand deleteCommand)
        {
            deleteCommand.NegaraCode = NegaraCode;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}