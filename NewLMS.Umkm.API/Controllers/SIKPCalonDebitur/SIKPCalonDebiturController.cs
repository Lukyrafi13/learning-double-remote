// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using NewLMS.UMKM.Data.Dto.SIKPCalonDebiturs;
// using MediatR;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using NewLMS.UMKM.MediatR.Features.SIKPCalonDebiturs.Commands;
// using NewLMS.UMKM.MediatR.Features.SIKPCalonDebiturs.Queries;
// using NewLMS.UMKM.Common.GenericRespository;
// using NewLMS.UMKM.Helper;

// namespace NewLMS.UMKM.API.Controllers.SIKPCalonDebitur
// {
//     public class SIKPCalonDebiturController : BaseController
//     {
//         public IMediator _mediator { get; set; }

//         /// <summary>
//         /// SIKPCalonDebitur
//         /// </summary>
//         /// <param name="mediator"></param>
//         public SIKPCalonDebiturController(IMediator mediator)
//         {
//             _mediator = mediator;
//         }

//         /// <summary>
//         /// Get SIKPCalonDebitur By Id
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <returns></returns>
//         [HttpGet("get/{Id}", Name = "GetSIKPCalonDebiturByCode")]
//         [Produces("application/json", "application/xml", Type = typeof(SIKPCalonDebiturResponseDto))]
//         public async Task<IActionResult> GetSIKPCalonDebiturByCode(Guid Id)
//         {
//             var getSCOQuery = new SIKPCalonDebiturGetQuery { Id = Id };
//             var result = await _mediator.Send(getSCOQuery);
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Get SIKPCalonDebitur
//         /// </summary>
//         /// <param name="filterQuery"></param>
//         /// <returns></returns>
//         [HttpPost("get", Name = "GetSIKPCalonDebiturList")]
//         [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<SIKPCalonDebiturResponseDto>>))]
//         public async Task<IActionResult> GetSIKPCalonDebiturList(SIKPCalonDebitursGetFilterQuery filterQuery)
//         {
//             var result = await _mediator.Send(filterQuery);
//             return Ok(result);
//         }

//         /// <summary>
//         /// Post New SIKPCalonDebitur
//         /// </summary>
//         /// <param name="postSIKPCalonDebitur"></param>
//         /// <returns></returns>
//         [HttpPost("post", Name = "AddSIKPCalonDebitur")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<SIKPCalonDebiturResponseDto>))]
//         public async Task<IActionResult> AddSIKPCalonDebitur(SIKPCalonDebiturPostCommand postSIKPCalonDebitur)
//         {
//             var result = await _mediator.Send(postSIKPCalonDebitur);
//             if (!result.Success)
//             {
//                 return ReturnFormattedResponse(result);
//             }
//             return CreatedAtAction("GetSIKPCalonDebiturByCode", new { id = result.Data.Id }, result.Data);
//         }

//         /// <summary>
//         /// Put Edit SIKPCalonDebitur
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <param name="putSIKPCalonDebitur"></param>
//         /// <returns></returns>
//         [HttpPut("put/{Id}", Name = "EditSIKPCalonDebitur")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<SIKPCalonDebiturResponseDto>))]
//         public async Task<IActionResult> EditSIKPCalonDebitur([FromRoute] Guid Id, [FromBody] SIKPCalonDebiturPutCommand putSIKPCalonDebitur)
//         {
//             putSIKPCalonDebitur.Id = Id;
//             var result = await _mediator.Send(putSIKPCalonDebitur);
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Delete SIKPCalonDebitur
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <param name="deleteCommand"></param>
//         /// <returns></returns>
//         [HttpDelete("delete/{Id}", Name = "DeleteSIKPCalonDebitur")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
//         public async Task<IActionResult> DeleteSIKPCalonDebitur([FromRoute] Guid Id, [FromBody]SIKPCalonDebiturDeleteCommand deleteCommand)
//         {
//             deleteCommand.Id = Id;
//             return Ok(await _mediator.Send(deleteCommand));
//         }
//     }
// }