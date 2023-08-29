using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RFKepemilikanTUs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFKepemilikanTUs.Commands;
using NewLMS.Umkm.MediatR.Features.RFKepemilikanTUs.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.RFKepemilikanTU
{
    public class RFKepemilikanTUController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFKepemilikanTU
        /// </summary>
        /// <param name="mediator"></param>
        public RFKepemilikanTUController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFKepemilikanTU By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetRFKepemilikanTUById")]
        [Produces("application/json", "application/xml", Type = typeof(RFKepemilikanTUResponseDto))]
        public async Task<IActionResult> GetRFKepemilikanTUById(string ANL_CODE)
        {
            var getGenderQuery = new RFKepemilikanTUGetQuery { ANL_CODE = ANL_CODE };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFKepemilikanTU
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFKepemilikanTUList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFKepemilikanTUResponseDto>>))]
        public async Task<IActionResult> GetRFKepemilikanTUList(RFKepemilikanTUsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFKepemilikanTU
        /// </summary>
        /// <param name="postRFKepemilikanTU"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFKepemilikanTU")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFKepemilikanTUResponseDto>))]
        public async Task<IActionResult> AddRFKepemilikanTU(RFKepemilikanTUPostCommand postRFKepemilikanTU)
        {
            var result = await _mediator.Send(postRFKepemilikanTU);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFKepemilikanTUById", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit RFKepemilikanTU
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putRFKepemilikanTU"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditRFKepemilikanTU")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFKepemilikanTUResponseDto>))]
        public async Task<IActionResult> EditRFKepemilikanTU([FromRoute] string ANL_CODE, [FromBody] RFKepemilikanTUPutCommand putRFKepemilikanTU)
        {
            putRFKepemilikanTU.ANL_CODE = ANL_CODE;
            var result = await _mediator.Send(putRFKepemilikanTU);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFKepemilikanTU
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteRFKepemilikanTU")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFKepemilikanTU([FromRoute] string ANL_CODE, [FromBody] RFKepemilikanTUDeleteCommand deleteCommand)
        {
            deleteCommand.ANL_CODE = ANL_CODE;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}