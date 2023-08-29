// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using NewLMS.UMKM.Data.Dto.AnalisaSandiOJKs;
// using MediatR;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using NewLMS.UMKM.MediatR.Features.AnalisaSandiOJKs.Commands;
// using NewLMS.UMKM.MediatR.Features.AnalisaSandiOJKs.Queries;
// using NewLMS.UMKM.Common.GenericRespository;
// using NewLMS.UMKM.Helper;

// namespace NewLMS.UMKM.API.Controllers.AnalisaSandiOJK
// {
//     public class AnalisaSandiOJKController : BaseController
//     {
//         public IMediator _mediator { get; set; }

//         /// <summary>
//         /// AnalisaSandiOJK
//         /// </summary>
//         /// <param name="mediator"></param>
//         public AnalisaSandiOJKController(IMediator mediator)
//         {
//             _mediator = mediator;
//         }

//         /// <summary>
//         /// Get AnalisaSandiOJK By Id
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <returns></returns>
//         [HttpGet("get/{Id}", Name = "GetAnalisaSandiOJKByCode")]
//         [Produces("application/json", "application/xml", Type = typeof(AnalisaSandiOJKResponseDto))]
//         public async Task<IActionResult> GetAnalisaSandiOJKByCode(Guid Id)
//         {
//             var getSCOQuery = new AnalisaSandiOJKGetQuery { Id = Id };
//             var result = await _mediator.Send(getSCOQuery);
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Get AnalisaSandiOJK
//         /// </summary>
//         /// <param name="filterQuery"></param>
//         /// <returns></returns>
//         [HttpPost("get", Name = "GetAnalisaSandiOJKList")]
//         [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<AnalisaSandiOJKResponseDto>>))]
//         public async Task<IActionResult> GetAnalisaSandiOJKList(AnalisaSandiOJKsGetFilterQuery filterQuery)
//         {
//             var result = await _mediator.Send(filterQuery);
//             return Ok(result);
//         }

//         /// <summary>
//         /// Post New AnalisaSandiOJK
//         /// </summary>
//         /// <param name="postAnalisaSandiOJK"></param>
//         /// <returns></returns>
//         [HttpPost("post", Name = "AddAnalisaSandiOJK")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<AnalisaSandiOJKResponseDto>))]
//         public async Task<IActionResult> AddAnalisaSandiOJK(AnalisaSandiOJKPostCommand postAnalisaSandiOJK)
//         {
//             var result = await _mediator.Send(postAnalisaSandiOJK);
//             if (!result.Success)
//             {
//                 return ReturnFormattedResponse(result);
//             }
//             return CreatedAtAction("GetAnalisaSandiOJKByCode", new { id = result.Data.Id }, result.Data);
//         }

//         /// <summary>
//         /// Put Edit AnalisaSandiOJK
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <param name="putAnalisaSandiOJK"></param>
//         /// <returns></returns>
//         [HttpPut("put/{Id}", Name = "EditAnalisaSandiOJK")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<AnalisaSandiOJKResponseDto>))]
//         public async Task<IActionResult> EditAnalisaSandiOJK([FromRoute] Guid Id, [FromBody] AnalisaSandiOJKPutCommand putAnalisaSandiOJK)
//         {
//             putAnalisaSandiOJK.Id = Id;
//             var result = await _mediator.Send(putAnalisaSandiOJK);
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Delete AnalisaSandiOJK
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <param name="deleteCommand"></param>
//         /// <returns></returns>
//         [HttpDelete("delete/{Id}", Name = "DeleteAnalisaSandiOJK")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
//         public async Task<IActionResult> DeleteAnalisaSandiOJK([FromRoute] Guid Id, [FromBody]AnalisaSandiOJKDeleteCommand deleteCommand)
//         {
//             deleteCommand.Id = Id;
//             return Ok(await _mediator.Send(deleteCommand));
//         }
//     }
// }