using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RFAspekPemasarans;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFAspekPemasarans.Commands;
using NewLMS.Umkm.MediatR.Features.RFAspekPemasarans.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.RFAspekPemasaran
{
    public class RFAspekPemasaranController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFAspekPemasaran
        /// </summary>
        /// <param name="mediator"></param>
        public RFAspekPemasaranController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFAspekPemasaran By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetRFAspekPemasaranById")]
        [Produces("application/json", "application/xml", Type = typeof(RFAspekPemasaranResponseDto))]
        public async Task<IActionResult> GetRFAspekPemasaranById(string ANL_CODE)
        {
            var getGenderQuery = new RFAspekPemasaranGetQuery { ANL_CODE = ANL_CODE };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFAspekPemasaran
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFAspekPemasaranList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFAspekPemasaranResponseDto>>))]
        public async Task<IActionResult> GetRFAspekPemasaranList(RFAspekPemasaransGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFAspekPemasaran
        /// </summary>
        /// <param name="postRFAspekPemasaran"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFAspekPemasaran")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFAspekPemasaranResponseDto>))]
        public async Task<IActionResult> AddRFAspekPemasaran(RFAspekPemasaranPostCommand postRFAspekPemasaran)
        {
            var result = await _mediator.Send(postRFAspekPemasaran);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFAspekPemasaranById", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit RFAspekPemasaran
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putRFAspekPemasaran"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditRFAspekPemasaran")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFAspekPemasaranResponseDto>))]
        public async Task<IActionResult> EditRFAspekPemasaran([FromRoute] string ANL_CODE, [FromBody] RFAspekPemasaranPutCommand putRFAspekPemasaran)
        {
            putRFAspekPemasaran.ANL_CODE = ANL_CODE;
            var result = await _mediator.Send(putRFAspekPemasaran);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFAspekPemasaran
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteRFAspekPemasaran")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFAspekPemasaran([FromRoute] string ANL_CODE, [FromBody] RFAspekPemasaranDeleteCommand deleteCommand)
        {
            deleteCommand.ANL_CODE = ANL_CODE;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}