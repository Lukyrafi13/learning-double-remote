using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFPilihanPemutuss;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFPilihanPemutuss.Commands;
using NewLMS.UMKM.MediatR.Features.RFPilihanPemutuss.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RFPilihanPemutus
{
    public class RFPilihanPemutusController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFPilihanPemutus
        /// </summary>
        /// <param name="mediator"></param>
        public RFPilihanPemutusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFPilihanPemutus By PemCode
        /// </summary>
        /// <param name="PemCode"></param>
        /// <returns></returns>
        [HttpGet("get/{PemCode}", Name = "GetRFPilihanPemutusBy")]
        [Produces("application/json", "application/xml", Type = typeof(RFPilihanPemutusResponseDto))]
        public async Task<IActionResult> GetRFPilihanPemutusBy(string PemCode)
        {
            var getGenderQuery = new RFPilihanPemutusGetQuery { PemCode = PemCode };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFPilihanPemutus By Filter
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFPilihanPemutusList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFPilihanPemutusResponseDto>>))]
        public async Task<IActionResult> GetRFPilihanPemutusList(RFPilihanPemutussGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFPilihanPemutus
        /// </summary>
        /// <param name="postRFPilihanPemutus"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFPilihanPemutus")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFPilihanPemutusResponseDto>))]
        public async Task<IActionResult> AddRFPilihanPemutus(RFPilihanPemutusPostCommand postRFPilihanPemutus)
        {
            var result = await _mediator.Send(postRFPilihanPemutus);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFPilihanPemutusByPemCode", new { id = result.Data.PemCode }, result.Data);
        }

        /// <summary>
        /// Put Edit RFPilihanPemutus
        /// </summary>
        /// <param name="PemCode"></param>
        /// <param name="putRFPilihanPemutus"></param>
        /// <returns></returns>
        [HttpPut("put/{PemCode}", Name = "EditRFPilihanPemutus")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFPilihanPemutusResponseDto>))]
        public async Task<IActionResult> EditRFPilihanPemutus([FromRoute] string PemCode, [FromBody] RFPilihanPemutusPutCommand putRFPilihanPemutus)
        {
            putRFPilihanPemutus.PemCode = PemCode;
            var result = await _mediator.Send(putRFPilihanPemutus);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFPilihanPemutus
        /// </summary>
        /// <param name="PemCode"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{PemCode}", Name = "DeleteRFPilihanPemutus")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFPilihanPemutus([FromRoute] string PemCode, [FromBody]RFPilihanPemutusDeleteCommand deleteCommand)
        {
            deleteCommand.PemCode = PemCode;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}