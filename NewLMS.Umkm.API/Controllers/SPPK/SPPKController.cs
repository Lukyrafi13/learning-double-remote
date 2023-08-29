// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using NewLMS.UMKM.Data.Dto.SPPKs;
// using MediatR;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using NewLMS.UMKM.MediatR.Features.SPPKs.Commands;
// using NewLMS.UMKM.MediatR.Features.SPPKs.Queries;
// using NewLMS.UMKM.Common.GenericRespository;
// using NewLMS.UMKM.Helper;

// namespace NewLMS.UMKM.API.Controllers.SPPK
// {
//     public class SPPKController : BaseController
//     {
//         public IMediator _mediator { get; set; }

//         /// <summary>
//         /// SPPK
//         /// </summary>
//         /// <param name="mediator"></param>
//         public SPPKController(IMediator mediator)
//         {
//             _mediator = mediator;
//         }

//         /// <summary>
//         /// Get Halaman Utama SPPK
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <returns></returns>
//         [HttpGet("halaman-utama/get/{Id}", Name = "GetHalamanUtamaSPPK")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
//         public async Task<IActionResult> GetHalamanUtamaSPPK(Guid Id)
//         {
//             var result = await _mediator.Send(new SPPKHalamanUtamaGetQuery { Id = Id });
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Get List SPPK
//         /// </summary>
//         /// <param name="getSPPKList"></param>
//         /// <returns></returns>
//         [HttpPost("app/list/get", Name = "SPPKListGet")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
//         public async Task<IActionResult> SPPKListGet([FromBody] SPPKsGetFilterQuery getSPPKList)
//         {
//             var result = await _mediator.Send(getSPPKList);
//             return Ok(result);
//         }

//         /// <summary>
//         /// Proses SPPK
//         /// </summary>
//         /// <param name="prosesSPPK"></param>
//         /// <returns></returns>
//         [HttpPost("proses", Name = "ProsesSPPK")]
//         [Produces("application/json", "application/xml", Type = typeof(SPPKProsesResponse))]
//         public async Task<IActionResult> ProsesSPPK(SPPKProsesCommand prosesSPPK)
//         {
//             var result = await _mediator.Send(prosesSPPK);
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Put Update Halaman Utama SPPK
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <param name="putHalamanUtama"></param>
//         /// <returns></returns>
//         [HttpPut("informasi-usaha/put/{Id}", Name = "PutHalamanUtamaSPPK")]
//         [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<SPPKTableResponse>>))]
//         public async Task<IActionResult> PutHalamanUtamaSPPK([FromRoute] Guid Id, [FromBody] SPPKHalamanUtamaPutCommand putHalamanUtama)
//         {
//             putHalamanUtama.Id = Id;
//             var result = await _mediator.Send(putHalamanUtama);
//             return Ok(result);
//         }

//     }
// }