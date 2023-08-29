// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using NewLMS.UMKM.Data.Dto.AppFasilitasKredits;
// using MediatR;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using NewLMS.UMKM.MediatR.Features.AppFasilitasKredits.Commands;
// using NewLMS.UMKM.MediatR.Features.AppFasilitasKredits.Queries;
// using NewLMS.UMKM.Common.GenericRespository;
// using NewLMS.UMKM.Helper;

// namespace NewLMS.UMKM.API.Controllers.AppFasilitasKredit
// {
//     public class AppFasilitasKreditController : BaseController
//     {
//         public IMediator _mediator { get; set; }

//         /// <summary>
//         /// AppFasilitasKredit
//         /// </summary>
//         /// <param name="mediator"></param>
//         public AppFasilitasKreditController(IMediator mediator)
//         {
//             _mediator = mediator;
//         }

//         /// <summary>
//         /// Get AppFasilitasKredit By Id
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <returns></returns>
//         [HttpGet("get/{Id}", Name = "GetAppFasilitasKreditByCode")]
//         [Produces("application/json", "application/xml", Type = typeof(Unit))]
//         public async Task<IActionResult> GetAppFasilitasKreditByCode(Guid Id)
//         {
//             var getSCOQuery = new AppFasilitasKreditGetQuery { Id = Id };
//             var result = await _mediator.Send(getSCOQuery);
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Get AppFasilitasKredit
//         /// </summary>
//         /// <param name="filterQuery"></param>
//         /// <returns></returns>
//         [HttpPost("get", Name = "GetAppFasilitasKreditList")]
//         [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<Unit>>))]
//         public async Task<IActionResult> GetAppFasilitasKreditList(AppFasilitasKreditsGetFilterQuery filterQuery)
//         {
//             var result = await _mediator.Send(filterQuery);
//             return Ok(result);
//         }

//         /// <summary>
//         /// Post New AppFasilitasKredit
//         /// </summary>
//         /// <param name="postAppFasilitasKredit"></param>
//         /// <returns></returns>
//         [HttpPost("post", Name = "AddAppFasilitasKredit")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
//         public async Task<IActionResult> AddAppFasilitasKredit(AppFasilitasKreditPostCommand postAppFasilitasKredit)
//         {
//             var result = await _mediator.Send(postAppFasilitasKredit);
//             if (!result.Success)
//             {
//                 return ReturnFormattedResponse(result);
//             }
//             return CreatedAtAction("GetAppFasilitasKreditByCode", new { id = result.Data.Id }, result.Data);
//         }

//         /// <summary>
//         /// Put Edit AppFasilitasKredit
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <param name="putAppFasilitasKredit"></param>
//         /// <returns></returns>
//         [HttpPut("put/{Id}", Name = "EditAppFasilitasKredit")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
//         public async Task<IActionResult> EditAppFasilitasKredit([FromRoute] Guid Id, [FromBody] AppFasilitasKreditPutCommand putAppFasilitasKredit)
//         {
//             putAppFasilitasKredit.Id = Id;
//             var result = await _mediator.Send(putAppFasilitasKredit);
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Delete AppFasilitasKredit
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <param name="deleteCommand"></param>
//         /// <returns></returns>
//         [HttpDelete("delete/{Id}", Name = "DeleteAppFasilitasKredit")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
//         public async Task<IActionResult> DeleteAppFasilitasKredit([FromRoute] Guid Id, [FromBody]AppFasilitasKreditDeleteCommand deleteCommand)
//         {
//             deleteCommand.Id = Id;
//             return Ok(await _mediator.Send(deleteCommand));
//         }
//     }
// }