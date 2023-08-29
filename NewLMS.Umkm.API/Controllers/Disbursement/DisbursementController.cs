// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using NewLMS.UMKM.Data.Dto.Disbursements;
// using MediatR;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// // using NewLMS.UMKM.MediatR.Features.Disbursements.Commands;
// using NewLMS.UMKM.MediatR.Features.Disbursements.Queries;
// using NewLMS.UMKM.Common.GenericRespository;
// using NewLMS.UMKM.Helper;

// namespace NewLMS.UMKM.API.Controllers.Disbursement
// {
//     public class DisbursementController : BaseController
//     {
//         public IMediator _mediator { get; set; }

//         /// <summary>
//         /// Disbursement
//         /// </summary>
//         /// <param name="mediator"></param>
//         public DisbursementController(IMediator mediator)
//         {
//             _mediator = mediator;
//         }


//         /// <summary>
//         /// Get List Disbursement
//         /// </summary>
//         /// <param name="getDisbursementList"></param>
//         /// <returns></returns>
//         [HttpPost("app/list/get", Name = "DisbursementListGet")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
//         public async Task<IActionResult> DisbursementListGet([FromBody] DisbursementsGetFilterQuery getDisbursementList)
//         {
//             var result = await _mediator.Send(getDisbursementList);
//             return Ok(result);
//         }

//         // /// <summary>
//         // /// Proses Disbursement
//         // /// </summary>
//         // /// <param name="prosesDisbursement"></param>
//         // /// <returns></returns>
//         // [HttpPost("proses", Name = "ProsesDisbursement")]
//         // [Produces("application/json", "application/xml", Type = typeof(DisbursementProsesResponse))]
//         // public async Task<IActionResult> ProsesDisbursement(DisbursementProsesCommand prosesDisbursement)
//         // {
//         //     var result = await _mediator.Send(prosesDisbursement);
//         //     return ReturnFormattedResponse(result);
//         // }




//     }
// }