/*using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.AppAgunans;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
*//*using NewLMS.UMKM.MediatR.Features.AppAgunans.Commands;
using NewLMS.UMKM.MediatR.Features.AppAgunans.Queries;*//*
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.AppAgunan
{
    public class AppAgunanController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// AppAgunan
        /// </summary>
        /// <param name="mediator"></param>
        public AppAgunanController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get AppAgunan By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetAppAgunanByCode")]
        [Produces("application/json", "application/xml", Type = typeof(AppAgunanResponseDto))]
        public async Task<IActionResult> GetAppAgunanByCode(Guid Id)
        {
            var getSCOQuery = new AppAgunanGetQuery { Id = Id };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get AppAgunan
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetAppAgunanList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<AppAgunanResponseDto>>))]
        public async Task<IActionResult> GetAppAgunanList(AppAgunansGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New AppAgunan
        /// </summary>
        /// <param name="postAppAgunan"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddAppAgunan")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<AppAgunanResponseDto>))]
        public async Task<IActionResult> AddAppAgunan(AppAgunanPostCommand postAppAgunan)
        {
            var result = await _mediator.Send(postAppAgunan);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetAppAgunanByCode", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit AppAgunan
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putAppAgunan"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditAppAgunan")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<AppAgunanResponseDto>))]
        public async Task<IActionResult> EditAppAgunan([FromRoute] Guid Id, [FromBody] AppAgunanPutCommand putAppAgunan)
        {
            putAppAgunan.Id = Id;
            var result = await _mediator.Send(putAppAgunan);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete AppAgunan
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteAppAgunan")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteAppAgunan([FromRoute] Guid Id, [FromBody] AppAgunanDeleteCommand deleteCommand)
        {
            deleteCommand.Id = Id;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}*/