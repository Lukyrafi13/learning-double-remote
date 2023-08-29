using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RFSubProductInts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFSubProductInts.Commands;
using NewLMS.Umkm.MediatR.Features.RFSubProductInts.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.RFSubProductInt
{
    public class RFSubProductIntController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFSubProductInt
        /// </summary>
        /// <param name="mediator"></param>
        public RFSubProductIntController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFSubProductInt By Id
        /// </summary>
        /// <param name="TPLCode"></param>
        /// <returns></returns>
        [HttpGet("get/{TPLCode}", Name = "GetRFSubProductIntById")]
        [Produces("application/json", "application/xml", Type = typeof(RFSubProductIntResponseDto))]
        public async Task<IActionResult> GetRFSubProductIntById(string TPLCode)
        {
            var getGenderQuery = new RFSubProductIntGetQuery { TPLCode = TPLCode };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFSubProductInt
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFSubProductIntList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFSubProductIntResponseDto>>))]
        public async Task<IActionResult> GetRFSubProductIntList(RFSubProductIntsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFSubProductInt
        /// </summary>
        /// <param name="postRFSubProductInt"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFSubProductInt")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFSubProductIntResponseDto>))]
        public async Task<IActionResult> AddRFSubProductInt(RFSubProductIntPostCommand postRFSubProductInt)
        {
            var result = await _mediator.Send(postRFSubProductInt);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFSubProductIntById", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit RFSubProductInt
        /// </summary>
        /// <param name="TPLCode"></param>
        /// <param name="putRFSubProductInt"></param>
        /// <returns></returns>
        [HttpPut("put/{TPLCode}", Name = "EditRFSubProductInt")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFSubProductIntResponseDto>))]
        public async Task<IActionResult> EditRFSubProductInt([FromRoute] string TPLCode, [FromBody] RFSubProductIntPutCommand putRFSubProductInt)
        {
            putRFSubProductInt.TPLCode = TPLCode;
            var result = await _mediator.Send(putRFSubProductInt);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFSubProductInt
        /// </summary>
        /// <param name="TPLCode"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{TPLCode}", Name = "DeleteRFSubProductInt")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFSubProductInt([FromRoute] string TPLCode, [FromBody] RFSubProductIntDeleteCommand deleteCommand)
        {
            deleteCommand.TPLCode = TPLCode;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}