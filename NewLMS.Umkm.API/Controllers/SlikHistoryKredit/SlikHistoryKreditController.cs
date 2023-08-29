// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using NewLMS.UMKM.Data.Dto.SlikHistoryKredits;
// using MediatR;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using NewLMS.UMKM.MediatR.Features.SlikHistoryKredits.Commands;
// using NewLMS.UMKM.MediatR.Features.SlikHistoryKredits.Queries;
// using NewLMS.UMKM.Common.GenericRespository;
// using NewLMS.UMKM.Helper;

// namespace NewLMS.UMKM.API.Controllers.SlikHistoryKredit
// {
//     public class SlikHistoryKreditController : BaseController
//     {
//         public IMediator _mediator { get; set; }

//         /// <summary>
//         /// SlikHistoryKredit
//         /// </summary>
//         /// <param name="mediator"></param>
//         public SlikHistoryKreditController(IMediator mediator)
//         {
//             _mediator = mediator;
//         }

//         /// <summary>
//         /// Get SlikHistoryKredit By Id
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <returns></returns>
//         [HttpGet("get/{Id}", Name = "GetSlikHistoryKreditByCode")]
//         [Produces("application/json", "application/xml", Type = typeof(SlikHistoryKreditResponseDto))]
//         public async Task<IActionResult> GetSlikHistoryKreditByCode(Guid Id)
//         {
//             var getSCOQuery = new SlikHistoryKreditGetQuery { Id = Id };
//             var result = await _mediator.Send(getSCOQuery);
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Get SlikHistoryKredit
//         /// </summary>
//         /// <param name="filterQuery"></param>
//         /// <returns></returns>
//         [HttpPost("get", Name = "GetSlikHistoryKreditList")]
//         [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<SlikHistoryKreditResponseDto>>))]
//         public async Task<IActionResult> GetSlikHistoryKreditList(SlikHistoryKreditsGetFilterQuery filterQuery)
//         {
//             var result = await _mediator.Send(filterQuery);
//             return Ok(result);
//         }

//         /// <summary>
//         /// Post New SlikHistoryKredit
//         /// </summary>
//         /// <param name="postSlikHistoryKredit"></param>
//         /// <returns></returns>
//         [HttpPost("post", Name = "AddSlikHistoryKredit")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<SlikHistoryKreditResponseDto>))]
//         public async Task<IActionResult> AddSlikHistoryKredit(SlikHistoryKreditPostCommand postSlikHistoryKredit)
//         {
//             var result = await _mediator.Send(postSlikHistoryKredit);
//             if (!result.Success)
//             {
//                 return ReturnFormattedResponse(result);
//             }
//             return CreatedAtAction("GetSlikHistoryKreditByCode", new { id = result.Data.Id }, result.Data);
//         }

//         /// <summary>
//         /// Put Edit SlikHistoryKredit
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <param name="putSlikHistoryKredit"></param>
//         /// <returns></returns>
//         [HttpPut("put/{Id}", Name = "EditSlikHistoryKredit")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<SlikHistoryKreditResponseDto>))]
//         public async Task<IActionResult> EditSlikHistoryKredit([FromRoute] Guid Id, [FromBody] SlikHistoryKreditPutCommand putSlikHistoryKredit)
//         {
//             putSlikHistoryKredit.Id = Id;
//             var result = await _mediator.Send(putSlikHistoryKredit);
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Delete SlikHistoryKredit
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <param name="deleteCommand"></param>
//         /// <returns></returns>
//         [HttpDelete("delete/{Id}", Name = "DeleteSlikHistoryKredit")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
//         public async Task<IActionResult> DeleteSlikHistoryKredit([FromRoute] Guid Id, [FromBody]SlikHistoryKreditDeleteCommand deleteCommand)
//         {
//             deleteCommand.Id = Id;
//             return Ok(await _mediator.Send(deleteCommand));
//         }
//     }
// }