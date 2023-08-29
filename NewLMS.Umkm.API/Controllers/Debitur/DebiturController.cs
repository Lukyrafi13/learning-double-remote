using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.Debiturs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.Debiturs.Commands;
using NewLMS.Umkm.MediatR.Features.Debiturs.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.Debitur
{
    public class DebiturController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// Debitur
        /// </summary>
        /// <param name="mediator"></param>
        public DebiturController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get Debitur By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetDebiturById")]
        [Produces("application/json", "application/xml", Type = typeof(DebiturResponseDto))]
        public async Task<IActionResult> GetDebiturById(string Id)
        {
            var getStatusTargetQuery = new DebitursGetByIdQuery { Id = Id };
            var result = await _mediator.Send(getStatusTargetQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get Debitur List
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetDebiturList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<DebiturResponseDto>>))]
        public async Task<IActionResult> GetDebiturList(DebitursGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New Debitur
        /// </summary>
        /// <param name="postDebitur"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddDebitur")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<DebiturResponseDto>))]
        public async Task<IActionResult> AddDebitur(DebiturPostCommand postDebitur)
        {
            var result = await _mediator.Send(postDebitur);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetDebiturById", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit Debitur
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putDebitur"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditDebitur")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<DebiturResponseDto>))]
        public async Task<IActionResult> EditDebitur([FromRoute] string Id, [FromBody] DebiturPutCommand putDebitur)
        {
            putDebitur.Id = Id;
            var result = await _mediator.Send(putDebitur);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete Debitur
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteDebitur")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteDebitur([FromRoute] string Id, [FromBody]DebiturDeleteCommand deleteCommand)
        {
            deleteCommand.Id = Id;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}