using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RFJenisPermohonans;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFJenisPermohonans.Commands;
using NewLMS.Umkm.MediatR.Features.RFJenisPermohonans.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.RFJenisPermohonan
{
    public class RFJenisPermohonanController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFJenisPermohonan
        /// </summary>
        /// <param name="mediator"></param>
        public RFJenisPermohonanController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFJenisPermohonan By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetRFJenisPermohonanById")]
        [Produces("application/json", "application/xml", Type = typeof(RFJenisPermohonanResponseDto))]
        public async Task<IActionResult> GetRFJenisPermohonanById(Guid Id)
        {
            var getGenderQuery = new RFJenisPermohonansGetByIdQuery { Id = Id };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFJenisPermohonan
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFJenisPermohonanList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFJenisPermohonanResponseDto>>))]
        public async Task<IActionResult> GetRFJenisPermohonanList(RFJenisPermohonansGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFJenisPermohonan
        /// </summary>
        /// <param name="postRFJenisPermohonan"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFJenisPermohonan")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFJenisPermohonanResponseDto>))]
        public async Task<IActionResult> AddRFJenisPermohonan(RFJenisPermohonanPostCommand postRFJenisPermohonan)
        {
            var result = await _mediator.Send(postRFJenisPermohonan);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFJenisPermohonanById", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit RFJenisPermohonan
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putRFJenisPermohonan"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditRFJenisPermohonan")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFJenisPermohonanResponseDto>))]
        public async Task<IActionResult> EditRFJenisPermohonan([FromRoute] Guid Id, [FromBody] RFJenisPermohonanPutCommand putRFJenisPermohonan)
        {
            putRFJenisPermohonan.Id = Id;
            var result = await _mediator.Send(putRFJenisPermohonan);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFJenisPermohonan
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteRFJenisPermohonan")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFJenisPermohonan([FromRoute] Guid Id, [FromBody]RFJenisPermohonanDeleteCommand deleteCommand)
        {
            deleteCommand.Id = Id;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}