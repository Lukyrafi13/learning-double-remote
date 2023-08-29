using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RfGenders;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RfGenders.Commands;
using NewLMS.UMKM.MediatR.Features.RfGenders.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RfGender
{
    public class RfGenderController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RfGender
        /// </summary>
        /// <param name="mediator"></param>
        public RfGenderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RfGender By GenderCode
        /// </summary>
        /// <param name="GenderCode"></param>
        /// <returns></returns>
        [HttpGet("get/{GenderCode}", Name = "GetRfGenderByGenderCode")]
        [Produces("application/json", "application/xml", Type = typeof(RfGenderResponseDto))]
        public async Task<IActionResult> GetRfGenderByGenderCode(string GenderCode)
        {
            var getGenderQuery = new RfGendersGetByGenderCodeQuery { GenderCode = GenderCode };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RfGender By GenderCode
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRfGenderList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RfGenderResponseDto>>))]
        public async Task<IActionResult> GetRfGenderList(RfGendersGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RfGender
        /// </summary>
        /// <param name="postRfGender"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRfGender")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RfGenderResponseDto>))]
        public async Task<IActionResult> AddRfGender(RfGenderPostCommand postRfGender)
        {
            var result = await _mediator.Send(postRfGender);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRfGenderByGenderCode", new { id = result.Data.GenderCode }, result.Data);
        }

        /// <summary>
        /// Put Edit RfGender
        /// </summary>
        /// <param name="GenderCode"></param>
        /// <param name="putRfGender"></param>
        /// <returns></returns>
        [HttpPut("put/{GenderCode}", Name = "EditRfGender")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RfGenderResponseDto>))]
        public async Task<IActionResult> EditRfGender([FromRoute] string GenderCode, [FromBody] RfGenderPutCommand putRfGender)
        {
            putRfGender.GenderCode = GenderCode;
            var result = await _mediator.Send(putRfGender);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RfGender
        /// </summary>
        /// <param name="GenderCode"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{GenderCode}", Name = "DeleteRfGender")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRfGender([FromRoute] string GenderCode, [FromBody]RfGenderDeleteCommand deleteCommand)
        {
            deleteCommand.GenderCode = GenderCode;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}