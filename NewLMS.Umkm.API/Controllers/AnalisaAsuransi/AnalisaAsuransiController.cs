// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using NewLMS.UMKM.Data.Dto.AnalisaAsuransis;
// using MediatR;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using NewLMS.UMKM.MediatR.Features.AnalisaAsuransis.Commands;
// using NewLMS.UMKM.MediatR.Features.AnalisaAsuransis.Queries;
// using NewLMS.UMKM.Common.GenericRespository;
// using NewLMS.UMKM.Helper;

// namespace NewLMS.UMKM.API.Controllers.AnalisaAsuransi
// {
//     public class AnalisaAsuransiController : BaseController
//     {
//         public IMediator _mediator { get; set; }

//         /// <summary>
//         /// AnalisaAsuransi
//         /// </summary>
//         /// <param name="mediator"></param>
//         public AnalisaAsuransiController(IMediator mediator)
//         {
//             _mediator = mediator;
//         }

//         /// <summary>
//         /// Get AnalisaAsuransi By Id
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <returns></returns>
//         [HttpGet("get/{Id}", Name = "GetAnalisaAsuransiByCode")]
//         [Produces("application/json", "application/xml", Type = typeof(AnalisaAsuransiResponseDto))]
//         public async Task<IActionResult> GetAnalisaAsuransiByCode(Guid Id)
//         {
//             var getSCOQuery = new AnalisaAsuransiGetQuery { Id = Id };
//             var result = await _mediator.Send(getSCOQuery);
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Get AnalisaAsuransi
//         /// </summary>
//         /// <param name="filterQuery"></param>
//         /// <returns></returns>
//         [HttpPost("get", Name = "GetAnalisaAsuransiList")]
//         [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<AnalisaAsuransiResponseDto>>))]
//         public async Task<IActionResult> GetAnalisaAsuransiList(AnalisaAsuransisGetFilterQuery filterQuery)
//         {
//             var result = await _mediator.Send(filterQuery);
//             return Ok(result);
//         }

//         /// <summary>
//         /// Post New AnalisaAsuransi
//         /// </summary>
//         /// <param name="postAnalisaAsuransi"></param>
//         /// <returns></returns>
//         [HttpPost("post", Name = "AddAnalisaAsuransi")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<AnalisaAsuransiResponseDto>))]
//         public async Task<IActionResult> AddAnalisaAsuransi(AnalisaAsuransiPostCommand postAnalisaAsuransi)
//         {
//             var result = await _mediator.Send(postAnalisaAsuransi);
//             if (!result.Success)
//             {
//                 return ReturnFormattedResponse(result);
//             }
//             return CreatedAtAction("GetAnalisaAsuransiByCode", new { id = result.Data.Id }, result.Data);
//         }

//         /// <summary>
//         /// Put Edit AnalisaAsuransi
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <param name="putAnalisaAsuransi"></param>
//         /// <returns></returns>
//         [HttpPut("put/{Id}", Name = "EditAnalisaAsuransi")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<AnalisaAsuransiResponseDto>))]
//         public async Task<IActionResult> EditAnalisaAsuransi([FromRoute] Guid Id, [FromBody] AnalisaAsuransiPutCommand putAnalisaAsuransi)
//         {
//             putAnalisaAsuransi.Id = Id;
//             var result = await _mediator.Send(putAnalisaAsuransi);
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Delete AnalisaAsuransi
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <param name="deleteCommand"></param>
//         /// <returns></returns>
//         [HttpDelete("delete/{Id}", Name = "DeleteAnalisaAsuransi")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
//         public async Task<IActionResult> DeleteAnalisaAsuransi([FromRoute] Guid Id, [FromBody]AnalisaAsuransiDeleteCommand deleteCommand)
//         {
//             deleteCommand.Id = Id;
//             return Ok(await _mediator.Send(deleteCommand));
//         }
//     }
// }