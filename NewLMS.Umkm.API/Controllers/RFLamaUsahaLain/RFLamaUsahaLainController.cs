using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RFLamaUsahaLains;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFLamaUsahaLains.Commands;
using NewLMS.Umkm.MediatR.Features.RFLamaUsahaLains.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.RFLamaUsahaLain
{
    public class RFLamaUsahaLainController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFLamaUsahaLain
        /// </summary>
        /// <param name="mediator"></param>
        public RFLamaUsahaLainController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFLamaUsahaLain By ANLCode
        /// </summary>
        /// <param name="ANLCode"></param>
        /// <returns></returns>
        [HttpGet("get/{ANLCode}", Name = "GetRFLamaUsahaLainBy")]
        [Produces("application/json", "application/xml", Type = typeof(RFLamaUsahaLainResponseDto))]
        public async Task<IActionResult> GetRFLamaUsahaLainBy(string ANLCode)
        {
            var getGenderQuery = new RFLamaUsahaLainGetQuery { ANLCode = ANLCode };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFLamaUsahaLain By Filter
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFLamaUsahaLainList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFLamaUsahaLainResponseDto>>))]
        public async Task<IActionResult> GetRFLamaUsahaLainList(RFLamaUsahaLainsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFLamaUsahaLain
        /// </summary>
        /// <param name="postRFLamaUsahaLain"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFLamaUsahaLain")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFLamaUsahaLainResponseDto>))]
        public async Task<IActionResult> AddRFLamaUsahaLain(RFLamaUsahaLainPostCommand postRFLamaUsahaLain)
        {
            var result = await _mediator.Send(postRFLamaUsahaLain);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFLamaUsahaLainByANLCode", new { id = result.Data.ANLCode }, result.Data);
        }

        /// <summary>
        /// Put Edit RFLamaUsahaLain
        /// </summary>
        /// <param name="ANLCode"></param>
        /// <param name="putRFLamaUsahaLain"></param>
        /// <returns></returns>
        [HttpPut("put/{ANLCode}", Name = "EditRFLamaUsahaLain")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFLamaUsahaLainResponseDto>))]
        public async Task<IActionResult> EditRFLamaUsahaLain([FromRoute] string ANLCode, [FromBody] RFLamaUsahaLainPutCommand putRFLamaUsahaLain)
        {
            putRFLamaUsahaLain.ANLCode = ANLCode;
            var result = await _mediator.Send(putRFLamaUsahaLain);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFLamaUsahaLain
        /// </summary>
        /// <param name="ANLCode"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{ANLCode}", Name = "DeleteRFLamaUsahaLain")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFLamaUsahaLain([FromRoute] string ANLCode, [FromBody]RFLamaUsahaLainDeleteCommand deleteCommand)
        {
            deleteCommand.ANLCode = ANLCode;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}