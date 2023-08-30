// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using NewLMS.UMKM.Data.Dto.InformasiOmsets;
// using MediatR;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using NewLMS.UMKM.MediatR.Features.InformasiOmsets.Commands;
// using NewLMS.UMKM.MediatR.Features.InformasiOmsets.Queries;
// using NewLMS.UMKM.Common.GenericRespository;
// using NewLMS.UMKM.Helper;

// namespace NewLMS.UMKM.API.Controllers.InformasiOmset
// {
//     public class InformasiOmsetController : BaseController
//     {
//         public IMediator _mediator { get; set; }

//         /// <summary>
//         /// InformasiOmset
//         /// </summary>
//         /// <param name="mediator"></param>
//         public InformasiOmsetController(IMediator mediator)
//         {
//             _mediator = mediator;
//         }

//         /// <summary>
//         /// Get InformasiOmset By Id
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <returns></returns>
//         [HttpGet("get/{Id}", Name = "GetInformasiOmsetById")]
//         [Produces("application/json", "application/xml", Type = typeof(InformasiOmsetResponseDto))]
//         public async Task<IActionResult> GetInformasiOmsetById(Guid Id)
//         {
//             var getGenderQuery = new InformasiOmsetGetQuery { Id = Id };
//             var result = await _mediator.Send(getGenderQuery);
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Get InformasiOmset
//         /// </summary>
//         /// <param name="filterQuery"></param>
//         /// <returns></returns>
//         [HttpPost("get", Name = "GetInformasiOmsetList")]
//         [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<InformasiOmsetResponseDto>>))]
//         public async Task<IActionResult> GetInformasiOmsetList(InformasiOmsetsGetFilterQuery filterQuery)
//         {
//             var result = await _mediator.Send(filterQuery);
//             return Ok(result);
//         }

//         /// <summary>
//         /// Post New InformasiOmset
//         /// </summary>
//         /// <param name="postInformasiOmset"></param>
//         /// <returns></returns>
//         [HttpPost("post", Name = "AddInformasiOmset")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<InformasiOmsetResponseDto>))]
//         public async Task<IActionResult> AddInformasiOmset(InformasiOmsetPostCommand postInformasiOmset)
//         {
//             var result = await _mediator.Send(postInformasiOmset);
//             if (!result.Success)
//             {
//                 return ReturnFormattedResponse(result);
//             }
//             return CreatedAtAction("GetInformasiOmsetById", new { id = result.Data.Id }, result.Data);
//         }

//         /// <summary>
//         /// Put Edit InformasiOmset
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <param name="putInformasiOmset"></param>
//         /// <returns></returns>
//         [HttpPut("put/{Id}", Name = "EditInformasiOmset")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<InformasiOmsetResponseDto>))]
//         public async Task<IActionResult> EditInformasiOmset([FromRoute] Guid Id, [FromBody] InformasiOmsetPutCommand putInformasiOmset)
//         {
//             putInformasiOmset.Id = Id;
//             var result = await _mediator.Send(putInformasiOmset);
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Delete InformasiOmset
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <param name="deleteCommand"></param>
//         /// <returns></returns>
//         [HttpDelete("delete/{Id}", Name = "DeleteInformasiOmset")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
//         public async Task<IActionResult> DeleteInformasiOmset([FromRoute] Guid Id, [FromBody] InformasiOmsetDeleteCommand deleteCommand)
//         {
//             deleteCommand.Id = Id;
//             return Ok(await _mediator.Send(deleteCommand));
//         }
//     }
// }