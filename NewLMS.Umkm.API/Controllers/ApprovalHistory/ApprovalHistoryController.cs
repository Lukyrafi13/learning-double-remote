// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using NewLMS.UMKM.Data.Dto.ApprovalHistorys;
// using MediatR;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using NewLMS.UMKM.MediatR.Features.ApprovalHistorys.Commands;
// using NewLMS.UMKM.MediatR.Features.ApprovalHistorys.Queries;
// using NewLMS.UMKM.Common.GenericRespository;
// using NewLMS.UMKM.Helper;

// namespace NewLMS.UMKM.API.Controllers.ApprovalHistory
// {
//     public class ApprovalHistoryController : BaseController
//     {
//         public IMediator _mediator { get; set; }

//         /// <summary>
//         /// ApprovalHistory
//         /// </summary>
//         /// <param name="mediator"></param>
//         public ApprovalHistoryController(IMediator mediator)
//         {
//             _mediator = mediator;
//         }

//         /// <summary>
//         /// Get ApprovalHistory By Id
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <returns></returns>
//         [HttpGet("get/{Id}", Name = "GetApprovalHistoryById")]
//         [Produces("application/json", "application/xml", Type = typeof(ApprovalHistoryResponseDto))]
//         public async Task<IActionResult> GetApprovalHistoryById(Guid Id)
//         {
//             var getGenderQuery = new ApprovalHistoryGetQuery { Id = Id };
//             var result = await _mediator.Send(getGenderQuery);
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Get ApprovalHistory
//         /// </summary>
//         /// <param name="filterQuery"></param>
//         /// <returns></returns>
//         [HttpPost("get", Name = "GetApprovalHistoryList")]
//         [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<ApprovalHistoryResponseDto>>))]
//         public async Task<IActionResult> GetApprovalHistoryList(ApprovalHistorysGetFilterQuery filterQuery)
//         {
//             var result = await _mediator.Send(filterQuery);
//             return Ok(result);
//         }

//         /// <summary>
//         /// Post New ApprovalHistory
//         /// </summary>
//         /// <param name="postApprovalHistory"></param>
//         /// <returns></returns>
//         [HttpPost("post", Name = "AddApprovalHistory")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<ApprovalHistoryResponseDto>))]
//         public async Task<IActionResult> AddApprovalHistory(ApprovalHistoryPostCommand postApprovalHistory)
//         {
//             var result = await _mediator.Send(postApprovalHistory);
//             if (!result.Success)
//             {
//                 return ReturnFormattedResponse(result);
//             }
//             return CreatedAtAction("GetApprovalHistoryById", new { id = result.Data.Id }, result.Data);
//         }

//         /// <summary>
//         /// Put Edit ApprovalHistory
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <param name="putApprovalHistory"></param>
//         /// <returns></returns>
//         [HttpPut("put/{Id}", Name = "EditApprovalHistory")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<ApprovalHistoryResponseDto>))]
//         public async Task<IActionResult> EditApprovalHistory([FromRoute] Guid Id, [FromBody] ApprovalHistoryPutCommand putApprovalHistory)
//         {
//             putApprovalHistory.Id = Id;
//             var result = await _mediator.Send(putApprovalHistory);
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Delete ApprovalHistory
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <param name="deleteCommand"></param>
//         /// <returns></returns>
//         [HttpDelete("delete/{Id}", Name = "DeleteApprovalHistory")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
//         public async Task<IActionResult> DeleteApprovalHistory([FromRoute] Guid Id, [FromBody] ApprovalHistoryDeleteCommand deleteCommand)
//         {
//             deleteCommand.Id = Id;
//             return Ok(await _mediator.Send(deleteCommand));
//         }
//     }
// }