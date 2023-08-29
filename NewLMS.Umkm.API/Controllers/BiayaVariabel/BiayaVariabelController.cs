using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.BiayaVariabels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.BiayaVariabels.Commands;
using NewLMS.Umkm.MediatR.Features.BiayaVariabels.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.BiayaVariabel
{
    public class BiayaVariabelController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// BiayaVariabel
        /// </summary>
        /// <param name="mediator"></param>
        public BiayaVariabelController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get BiayaVariabel By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetBiayaVariabelById")]
        [Produces("application/json", "application/xml", Type = typeof(BiayaVariabelResponseDto))]
        public async Task<IActionResult> GetBiayaVariabelById(Guid Id)
        {
            var getGenderQuery = new BiayaVariabelGetQuery { Id = Id };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get BiayaVariabel
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetBiayaVariabelList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<BiayaVariabelResponseDto>>))]
        public async Task<IActionResult> GetBiayaVariabelList(BiayaVariabelsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New BiayaVariabel
        /// </summary>
        /// <param name="postBiayaVariabel"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddBiayaVariabel")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<BiayaVariabelResponseDto>))]
        public async Task<IActionResult> AddBiayaVariabel(BiayaVariabelPostCommand postBiayaVariabel)
        {
            var result = await _mediator.Send(postBiayaVariabel);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetBiayaVariabelById", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit BiayaVariabel
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putBiayaVariabel"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditBiayaVariabel")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<BiayaVariabelResponseDto>))]
        public async Task<IActionResult> EditBiayaVariabel([FromRoute] Guid Id, [FromBody] BiayaVariabelPutCommand putBiayaVariabel)
        {
            putBiayaVariabel.Id = Id;
            var result = await _mediator.Send(putBiayaVariabel);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete BiayaVariabel
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteBiayaVariabel")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteBiayaVariabel([FromRoute] Guid Id, [FromBody] BiayaVariabelDeleteCommand deleteCommand)
        {
            deleteCommand.Id = Id;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}