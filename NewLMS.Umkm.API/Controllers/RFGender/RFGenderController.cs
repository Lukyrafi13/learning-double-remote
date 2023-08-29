using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RFGenders;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFGenders.Commands;
using NewLMS.Umkm.MediatR.Features.RFGenders.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.RFGender
{
    public class RFGenderController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFGender
        /// </summary>
        /// <param name="mediator"></param>
        public RFGenderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFGender By GenderCode
        /// </summary>
        /// <param name="GenderCode"></param>
        /// <returns></returns>
        [HttpGet("get/{GenderCode}", Name = "GetRFGenderByGenderCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFGenderResponseDto))]
        public async Task<IActionResult> GetRFGenderByGenderCode(string GenderCode)
        {
            var getGenderQuery = new RFGendersGetByGenderCodeQuery { GenderCode = GenderCode };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFGender By GenderCode
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFGenderList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFGenderResponseDto>>))]
        public async Task<IActionResult> GetRFGenderList(RFGendersGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFGender
        /// </summary>
        /// <param name="postRFGender"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFGender")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFGenderResponseDto>))]
        public async Task<IActionResult> AddRFGender(RFGenderPostCommand postRFGender)
        {
            var result = await _mediator.Send(postRFGender);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFGenderByGenderCode", new { id = result.Data.GenderCode }, result.Data);
        }

        /// <summary>
        /// Put Edit RFGender
        /// </summary>
        /// <param name="GenderCode"></param>
        /// <param name="putRFGender"></param>
        /// <returns></returns>
        [HttpPut("put/{GenderCode}", Name = "EditRFGender")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFGenderResponseDto>))]
        public async Task<IActionResult> EditRFGender([FromRoute] string GenderCode, [FromBody] RFGenderPutCommand putRFGender)
        {
            putRFGender.GenderCode = GenderCode;
            var result = await _mediator.Send(putRFGender);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFGender
        /// </summary>
        /// <param name="GenderCode"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{GenderCode}", Name = "DeleteRFGender")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFGender([FromRoute] string GenderCode, [FromBody]RFGenderDeleteCommand deleteCommand)
        {
            deleteCommand.GenderCode = GenderCode;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}