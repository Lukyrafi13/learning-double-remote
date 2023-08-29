// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using NewLMS.UMKM.Data.Dto.AppContactPersons;
// using MediatR;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using NewLMS.UMKM.MediatR.Features.AppContactPersons.Commands;
// using NewLMS.UMKM.MediatR.Features.AppContactPersons.Queries;
// using NewLMS.UMKM.Common.GenericRespository;
// using NewLMS.UMKM.Helper;

// namespace NewLMS.UMKM.API.Controllers.AppContactPerson
// {
//     public class AppContactPersonController : BaseController
//     {
//         public IMediator _mediator { get; set; }

//         /// <summary>
//         /// AppContactPerson
//         /// </summary>
//         /// <param name="mediator"></param>
//         public AppContactPersonController(IMediator mediator)
//         {
//             _mediator = mediator;
//         }

//         /// <summary>
//         /// Get AppContactPerson By Id
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <returns></returns>
//         [HttpGet("get/{Id}", Name = "GetAppContactPersonByCode")]
//         [Produces("application/json", "application/xml", Type = typeof(AppContactPersonResponseDto))]
//         public async Task<IActionResult> GetAppContactPersonByCode(Guid Id)
//         {
//             var getSCOQuery = new AppContactPersonGetQuery { Id = Id };
//             var result = await _mediator.Send(getSCOQuery);
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Get AppContactPerson
//         /// </summary>
//         /// <param name="filterQuery"></param>
//         /// <returns></returns>
//         [HttpPost("get", Name = "GetAppContactPersonList")]
//         [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<AppContactPersonResponseDto>>))]
//         public async Task<IActionResult> GetAppContactPersonList(AppContactPersonsGetFilterQuery filterQuery)
//         {
//             var result = await _mediator.Send(filterQuery);
//             return Ok(result);
//         }

//         /// <summary>
//         /// Post New AppContactPerson
//         /// </summary>
//         /// <param name="postAppContactPerson"></param>
//         /// <returns></returns>
//         [HttpPost("post", Name = "AddAppContactPerson")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<AppContactPersonResponseDto>))]
//         public async Task<IActionResult> AddAppContactPerson(AppContactPersonPostCommand postAppContactPerson)
//         {
//             var result = await _mediator.Send(postAppContactPerson);
//             if (!result.Success)
//             {
//                 return ReturnFormattedResponse(result);
//             }
//             return CreatedAtAction("GetAppContactPersonByCode", new { id = result.Data.Id }, result.Data);
//         }

//         /// <summary>
//         /// Put Edit AppContactPerson
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <param name="putAppContactPerson"></param>
//         /// <returns></returns>
//         [HttpPut("put/{Id}", Name = "EditAppContactPerson")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<AppContactPersonResponseDto>))]
//         public async Task<IActionResult> EditAppContactPerson([FromRoute] Guid Id, [FromBody] AppContactPersonPutCommand putAppContactPerson)
//         {
//             putAppContactPerson.Id = Id;
//             var result = await _mediator.Send(putAppContactPerson);
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Delete AppContactPerson
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <param name="deleteCommand"></param>
//         /// <returns></returns>
//         [HttpDelete("delete/{Id}", Name = "DeleteAppContactPerson")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
//         public async Task<IActionResult> DeleteAppContactPerson([FromRoute] Guid Id, [FromBody]AppContactPersonDeleteCommand deleteCommand)
//         {
//             deleteCommand.Id = Id;
//             return Ok(await _mediator.Send(deleteCommand));
//         }
//     }
// }