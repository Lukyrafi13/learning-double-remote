using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFBentukLahans;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFBentukLahans.Commands;
using NewLMS.UMKM.MediatR.Features.RFBentukLahans.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RFBentukLahan
{
    public class RFBentukLahanController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFBentukLahan
        /// </summary>
        /// <param name="mediator"></param>
        public RFBentukLahanController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFBentukLahan By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetRFBentukLahanById")]
        [Produces("application/json", "application/xml", Type = typeof(RFBentukLahanResponseDto))]
        public async Task<IActionResult> GetRFBentukLahanById(string BentukLahan_Id)
        {
            var getGenderQuery = new RFBentukLahanGetQuery { BentukLahan_Id = BentukLahan_Id };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFBentukLahan
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFBentukLahanList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFBentukLahanResponseDto>>))]
        public async Task<IActionResult> GetRFBentukLahanList(RFBentukLahansGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFBentukLahan
        /// </summary>
        /// <param name="postRFBentukLahan"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFBentukLahan")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFBentukLahanResponseDto>))]
        public async Task<IActionResult> AddRFBentukLahan(RFBentukLahanPostCommand postRFBentukLahan)
        {
            var result = await _mediator.Send(postRFBentukLahan);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFBentukLahanById", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit RFBentukLahan
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putRFBentukLahan"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditRFBentukLahan")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFBentukLahanResponseDto>))]
        public async Task<IActionResult> EditRFBentukLahan([FromRoute] string BentukLahan_Id, [FromBody] RFBentukLahanPutCommand putRFBentukLahan)
        {
            putRFBentukLahan.BentukLahan_Id = BentukLahan_Id;
            var result = await _mediator.Send(putRFBentukLahan);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFBentukLahan
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteRFBentukLahan")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFBentukLahan([FromRoute] string BentukLahan_Id, [FromBody] RFBentukLahanDeleteCommand deleteCommand)
        {
            deleteCommand.BentukLahan_Id = BentukLahan_Id;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}