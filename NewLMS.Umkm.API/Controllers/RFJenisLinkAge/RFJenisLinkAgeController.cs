using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RFJenisLinkAges;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFJenisLinkAges.Commands;
using NewLMS.Umkm.MediatR.Features.RFJenisLinkAges.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.RFJenisLinkAge
{
    public class RFJenisLinkAgeController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFJenisLinkAge
        /// </summary>
        /// <param name="mediator"></param>
        public RFJenisLinkAgeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFJenisLinkAge By JenisLinkAgeCode
        /// </summary>
        /// <param name="JenisLinkAgeCode"></param>
        /// <returns></returns>
        [HttpGet("get/{JenisLinkAgeCode}", Name = "GetRFJenisLinkAgeByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFJenisLinkAgeResponseDto))]
        public async Task<IActionResult> GetRFJenisLinkAgeByCode(string JenisLinkAgeCode)
        {
            var getSCOQuery = new RFJenisLinkAgeGetQuery { JenisLinkAgeCode = JenisLinkAgeCode };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFJenisLinkAge By JenisLinkAgeCode
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFJenisLinkAgeList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFJenisLinkAgeResponseDto>>))]
        public async Task<IActionResult> GetRFJenisLinkAgeList(RFJenisLinkAgesGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFJenisLinkAge
        /// </summary>
        /// <param name="postRFJenisLinkAge"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFJenisLinkAge")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFJenisLinkAgeResponseDto>))]
        public async Task<IActionResult> AddRFJenisLinkAge(RFJenisLinkAgePostCommand postRFJenisLinkAge)
        {
            var result = await _mediator.Send(postRFJenisLinkAge);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFJenisLinkAgeByCode", new { JenisLinkAgeCode = result.Data.JenisLinkAgeCode }, result.Data);
        }

        /// <summary>
        /// Put Edit RFJenisLinkAge
        /// </summary>
        /// <param name="JenisLinkAgeCode"></param>
        /// <param name="putRFJenisLinkAge"></param>
        /// <returns></returns>
        [HttpPut("put/{JenisLinkAgeCode}", Name = "EditRFJenisLinkAge")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFJenisLinkAgeResponseDto>))]
        public async Task<IActionResult> EditRFJenisLinkAge([FromRoute] string JenisLinkAgeCode, [FromBody] RFJenisLinkAgePutCommand putRFJenisLinkAge)
        {
            putRFJenisLinkAge.JenisLinkAgeCode = JenisLinkAgeCode;
            var result = await _mediator.Send(putRFJenisLinkAge);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFJenisLinkAge
        /// </summary>
        /// <param name="JenisLinkAgeCode"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{JenisLinkAgeCode}", Name = "DeleteRFJenisLinkAge")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFJenisLinkAge([FromRoute] string JenisLinkAgeCode, [FromBody] RFJenisLinkAgeDeleteCommand deleteCommand)
        {
            deleteCommand.JenisLinkAgeCode = JenisLinkAgeCode;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}