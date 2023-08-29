// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using NewLMS.UMKM.Data.Dto.ReviewPersiapanAkads;
// using MediatR;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// // using NewLMS.UMKM.MediatR.Features.ReviewPersiapanAkads.Commands;
// using NewLMS.UMKM.MediatR.Features.ReviewPersiapanAkads.Queries;
// using NewLMS.UMKM.Common.GenericRespository;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.MediatR.Features.ReviewPersiapanAkads.Commands;

// namespace NewLMS.UMKM.API.Controllers.ReviewPersiapanAkad
// {
//     public class ReviewPersiapanAkadController : BaseController
//     {
//         public IMediator _mediator { get; set; }

//         /// <summary>
//         /// ReviewPersiapanAkad
//         /// </summary>
//         /// <param name="mediator"></param>
//         public ReviewPersiapanAkadController(IMediator mediator)
//         {
//             _mediator = mediator;
//         }


//         /// <summary>
//         /// Get List ReviewPersiapanAkad
//         /// </summary>
//         /// <param name="getReviewPersiapanAkadList"></param>
//         /// <returns></returns>
//         [HttpPost("app/list/get", Name = "ReviewPersiapanAkadListGet")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
//         public async Task<IActionResult> ReviewPersiapanAkadListGet([FromBody] ReviewPersiapanAkadsGetFilterQuery getReviewPersiapanAkadList)
//         {
//             var result = await _mediator.Send(getReviewPersiapanAkadList);
//             return Ok(result);
//         }

//         /// <summary>
//         /// Proses ReviewPersiapanAkad
//         /// </summary>
//         /// <param name="prosesReviewPersiapanAkad"></param>
//         /// <returns></returns>
//         [HttpPost("proses", Name = "ProsesReviewPersiapanAkad")]
//         [Produces("application/json", "application/xml", Type = typeof(ReviewPersiapanAkadProsesResponse))]
//         public async Task<IActionResult> ProsesReviewPersiapanAkad(ReviewPersiapanAkadProsesCommand prosesReviewPersiapanAkad)
//         {
//             var result = await _mediator.Send(prosesReviewPersiapanAkad);
//             return ReturnFormattedResponse(result);
//         }
//     }
// }