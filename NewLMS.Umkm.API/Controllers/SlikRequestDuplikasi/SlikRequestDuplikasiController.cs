// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using NewLMS.UMKM.Data.Dto.SlikRequestDuplikasis;
// using MediatR;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using NewLMS.UMKM.MediatR.Features.SlikRequestDuplikasis.Commands;
// using NewLMS.UMKM.MediatR.Features.SlikRequestDuplikasis.Queries;
// using NewLMS.UMKM.Common.GenericRespository;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Data.Dto.MSearchs;

// namespace NewLMS.UMKM.API.Controllers.SlikRequestDuplikasi
// {
//     public class SlikRequestDuplikasiController : BaseController
//     {
//         public IMediator _mediator { get; set; }

//         /// <summary>
//         /// SlikRequestDuplikasi
//         /// </summary>
//         /// <param name="mediator"></param>
//         public SlikRequestDuplikasiController(IMediator mediator)
//         {
//             _mediator = mediator;
//         }

//         /// <summary>
//         /// Get SlikRequestDuplikasi By Id
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <returns></returns>
//         [HttpGet("get/{Id}", Name = "GetSlikRequestDuplikasiByCode")]
//         [Produces("application/json", "application/xml", Type = typeof(MSearchResponse))]
//         public async Task<IActionResult> GetSlikRequestDuplikasiByCode(Guid Id)
//         {
//             var getSCOQuery = new SlikRequestDuplikasiGetQuery { Id = Id };
//             var result = await _mediator.Send(getSCOQuery);
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Get SlikRequestDuplikasi
//         /// </summary>
//         /// <param name="filterQuery"></param>
//         /// <returns></returns>
//         [HttpPost("get", Name = "GetSlikRequestDuplikasiList")]
//         [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<MSearchResponse>>))]
//         public async Task<IActionResult> GetSlikRequestDuplikasiList(SlikRequestDuplikasisGetFilterQuery filterQuery)
//         {
//             var result = await _mediator.Send(filterQuery);
//             return Ok(result);
//         }

//         // /// <summary>
//         // /// Post New SlikRequestDuplikasi
//         // /// </summary>
//         // /// <param name="postSlikRequestDuplikasi"></param>
//         // /// <returns></returns>
//         // [HttpPost("post", Name = "AddSlikRequestDuplikasi")]
//         // [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<MSearchResponse>))]
//         // public async Task<IActionResult> AddSlikRequestDuplikasi([FromForm]SlikRequestDuplikasiPostCommand postSlikRequestDuplikasi)
//         // {
//         //     var result = await _mediator.Send(postSlikRequestDuplikasi);
//         //     if (!result.Success)
//         //     {
//         //         return ReturnFormattedResponse(result);
//         //     }
//         //     return CreatedAtAction("GetSlikRequestDuplikasiByCode", new { id = result.Data.Id }, result.Data);
//         // }

//         // /// <summary>
//         // /// Put Edit SlikRequestDuplikasi
//         // /// </summary>
//         // /// <param name="Id"></param>
//         // /// <param name="putSlikRequestDuplikasi"></param>
//         // /// <returns></returns>
//         // [HttpPut("put/{Id}", Name = "EditSlikRequestDuplikasi")]
//         // [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<MSearchResponse>))]
//         // public async Task<IActionResult> EditSlikRequestDuplikasi([FromRoute] Guid Id, [FromForm] SlikRequestDuplikasiPutCommand putSlikRequestDuplikasi)
//         // {
//         //     putSlikRequestDuplikasi.Id = Id;
//         //     var result = await _mediator.Send(putSlikRequestDuplikasi);
//         //     return ReturnFormattedResponse(result);
//         // }

//         // /// <summary>
//         // /// Delete SlikRequestDuplikasi
//         // /// </summary>
//         // /// <param name="Id"></param>
//         // /// <param name="deleteCommand"></param>
//         // /// <returns></returns>
//         // [HttpDelete("delete/{Id}", Name = "DeleteSlikRequestDuplikasi")]
//         // [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
//         // public async Task<IActionResult> DeleteSlikRequestDuplikasi([FromRoute] Guid Id, [FromBody]SlikRequestDuplikasiDeleteCommand deleteCommand)
//         // {
//         //     deleteCommand.Id = Id;
//         //     return Ok(await _mediator.Send(deleteCommand));
//         // }
//     }
// }