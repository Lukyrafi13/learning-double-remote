using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.BiayaTetaps;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.BiayaTetaps.Commands;
using NewLMS.Umkm.MediatR.Features.BiayaTetaps.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.BiayaTetap
{
    public class BiayaTetapController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// BiayaTetap
        /// </summary>
        /// <param name="mediator"></param>
        public BiayaTetapController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get BiayaTetap By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetBiayaTetapById")]
        [Produces("application/json", "application/xml", Type = typeof(BiayaTetapResponseDto))]
        public async Task<IActionResult> GetBiayaTetapById(Guid Id)
        {
            var getGenderQuery = new BiayaTetapGetQuery { Id = Id };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get BiayaTetap
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetBiayaTetapList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<BiayaTetapResponseDto>>))]
        public async Task<IActionResult> GetBiayaTetapList(BiayaTetapsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New BiayaTetap
        /// </summary>
        /// <param name="postBiayaTetap"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddBiayaTetap")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<BiayaTetapResponseDto>))]
        public async Task<IActionResult> AddBiayaTetap(BiayaTetapPostCommand postBiayaTetap)
        {
            var result = await _mediator.Send(postBiayaTetap);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetBiayaTetapById", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit BiayaTetap
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putBiayaTetap"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditBiayaTetap")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<BiayaTetapResponseDto>))]
        public async Task<IActionResult> EditBiayaTetap([FromRoute] Guid Id, [FromBody] BiayaTetapPutCommand putBiayaTetap)
        {
            putBiayaTetap.Id = Id;
            var result = await _mediator.Send(putBiayaTetap);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete BiayaTetap
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteBiayaTetap")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteBiayaTetap([FromRoute] Guid Id, [FromBody] BiayaTetapDeleteCommand deleteCommand)
        {
            deleteCommand.Id = Id;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}