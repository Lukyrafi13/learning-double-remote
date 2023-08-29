using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.AppKeyPersons;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.AppKeyPersons.Commands;
using NewLMS.Umkm.MediatR.Features.AppKeyPersons.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.AppKeyPerson
{
    public class AppKeyPersonController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// AppKeyPerson
        /// </summary>
        /// <param name="mediator"></param>
        public AppKeyPersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get AppKeyPerson By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetAppKeyPersonByCode")]
        [Produces("application/json", "application/xml", Type = typeof(AppKeyPersonResponseDto))]
        public async Task<IActionResult> GetAppKeyPersonByCode(Guid Id)
        {
            var getSCOQuery = new AppKeyPersonGetQuery { Id = Id };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get AppKeyPerson
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetAppKeyPersonList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<AppKeyPersonResponseDto>>))]
        public async Task<IActionResult> GetAppKeyPersonList(AppKeyPersonsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New AppKeyPerson
        /// </summary>
        /// <param name="postAppKeyPerson"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddAppKeyPerson")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<AppKeyPersonResponseDto>))]
        public async Task<IActionResult> AddAppKeyPerson(AppKeyPersonPostCommand postAppKeyPerson)
        {
            var result = await _mediator.Send(postAppKeyPerson);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetAppKeyPersonByCode", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit AppKeyPerson
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putAppKeyPerson"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditAppKeyPerson")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<AppKeyPersonResponseDto>))]
        public async Task<IActionResult> EditAppKeyPerson([FromRoute] Guid Id, [FromBody] AppKeyPersonPutCommand putAppKeyPerson)
        {
            putAppKeyPerson.Id = Id;
            var result = await _mediator.Send(putAppKeyPerson);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete AppKeyPerson
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteAppKeyPerson")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteAppKeyPerson([FromRoute] Guid Id, [FromBody]AppKeyPersonDeleteCommand deleteCommand)
        {
            deleteCommand.Id = Id;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}