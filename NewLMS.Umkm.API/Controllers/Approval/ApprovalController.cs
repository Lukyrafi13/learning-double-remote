// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using NewLMS.UMKM.Data.Dto.Approvals;
// using MediatR;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using NewLMS.UMKM.MediatR.Features.Approvals.Commands;
// using NewLMS.UMKM.MediatR.Features.Approvals.Queries;
// using NewLMS.UMKM.Common.GenericRespository;
// using NewLMS.UMKM.Helper;

// namespace NewLMS.UMKM.API.Controllers.Approval
// {
//     public class ApprovalController : BaseController
//     {
//         public IMediator _mediator { get; set; }

//         /// <summary>
//         /// Approval
//         /// </summary>
//         /// <param name="mediator"></param>
//         public ApprovalController(IMediator mediator)
//         {
//             _mediator = mediator;
//         }
        
//         /// <summary>
//         /// Get Data Tab Approval
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <returns></returns>
//         [HttpGet("approval/get/{Id}", Name = "GetApprovalApproval")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
//         public async Task<IActionResult> GetApprovalApproval(Guid Id)
//         {
//             var result = await _mediator.Send(new ApprovalApprovalGetQuery{ Id = Id });
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Get List Approval
//         /// </summary>
//         /// <param name="getApprovalList"></param>
//         /// <returns></returns>
//         [HttpPost("app/list/get", Name = "ApprovalListGet")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
//         public async Task<IActionResult> ApprovalListGet([FromBody] ApprovalsGetFilterQuery getApprovalList)
//         {
//             var result = await _mediator.Send(getApprovalList);
//             return Ok(result);
//         }

//         /// <summary>
//         /// Proses Approval
//         /// </summary>
//         /// <param name="prosesApproval"></param>
//         /// <returns></returns>
//         [HttpPost("proses", Name = "ProsesApproval")]
//         [Produces("application/json", "application/xml", Type = typeof(ApprovalProsesResponse))]
//         public async Task<IActionResult> ProsesApproval(ApprovalProsesCommand prosesApproval)
//         {
//             var result = await _mediator.Send(prosesApproval);
//             return ReturnFormattedResponse(result);
//         }
        

//         /// <summary>
//         /// Kembali ke Analisa
//         /// </summary>
//         /// <param name="KembaliKeAnalisa"></param>
//         /// <returns></returns>
//         [HttpPost("kembali/analisa", Name = "KembaliKeAnalisa")]
//         [Produces("application/json", "application/xml", Type = typeof(ApprovalProsesResponse))]
//         public async Task<IActionResult> KembaliKeAnalisa(ApprovalKembaliKeAnalisaCommand KembaliKeAnalisa)
//         {
//             var result = await _mediator.Send(KembaliKeAnalisa);
//             return ReturnFormattedResponse(result);
//         }
        

//         /// <summary>
//         /// Kembali ke IDE
//         /// </summary>
//         /// <param name="ApprovalKembaliKeIDE"></param>
//         /// <returns></returns>
//         [HttpPost("kembali/ide", Name = "ApprovalKembaliKeIDE")]
//         [Produces("application/json", "application/xml", Type = typeof(ApprovalProsesResponse))]
//         public async Task<IActionResult> ApprovalKembaliKeIDE(ApprovalKembaliKeIDECommand ApprovalKembaliKeIDE)
//         {
//             var result = await _mediator.Send(ApprovalKembaliKeIDE);
//             return ReturnFormattedResponse(result);
//         }
        

//         /// <summary>
//         /// Put Update Approval Approval
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <param name="putApproval"></param>
//         /// <returns></returns>
//         [HttpPut("approval/put/{Id}", Name = "PutApprovalApproval")]
//         [Produces("application/json", "application/xml", Type = typeof(ApprovalApprovalResponse))]
//         public async Task<IActionResult> PutApprovalApproval([FromRoute] Guid Id, [FromBody] ApprovalApprovalPutCommand putApproval)
//         {
//             putApproval.Id = Id;
//             var result = await _mediator.Send(putApproval);
//             return Ok(result);
//         }
        
//     }
// }