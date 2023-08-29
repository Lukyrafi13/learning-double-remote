// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using NewLMS.UMKM.Data.Dto.Tenors;
// using MediatR;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using NewLMS.UMKM.MediatR.Features.Tenors.Commands;
// using NewLMS.UMKM.MediatR.Features.Tenors.Queries;
// using NewLMS.UMKM.Common.GenericRespository;
// using NewLMS.UMKM.Helper;

// namespace NewLMS.UMKM.API.Controllers.Tenor
// {
//     public class TenorController : BaseController
//     {
//         public IMediator _mediator { get; set; }

//         /// <summary>
//         /// Tenor
//         /// </summary>
//         /// <param name="mediator"></param>
//         public TenorController(IMediator mediator)
//         {
//             _mediator = mediator;
//         }

//         /// <summary>
//         /// Get Tenor By SCO_CODE
//         /// </summary>
//         /// <param name="SCO_CODE"></param>
//         /// <returns></returns>
//         [HttpGet("get/{SCO_CODE}", Name = "GetTenorByCode")]
//         [Produces("application/json", "application/xml", Type = typeof(TenorResponseDto))]
//         public async Task<IActionResult> GetTenorByCode(string SCO_CODE)
//         {
//             var getSCOQuery = new TenorsGetByCodeQuery { SCO_CODE = SCO_CODE };
//             var result = await _mediator.Send(getSCOQuery);
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Get Tenor By SCO_CODE
//         /// </summary>
//         /// <param name="filterQuery"></param>
//         /// <returns></returns>
//         [HttpPost("get", Name = "GetTenorList")]
//         [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<TenorResponseDto>>))]
//         public async Task<IActionResult> GetTenorList(TenorsGetFilterQuery filterQuery)
//         {
//             var result = await _mediator.Send(filterQuery);
//             return Ok(result);
//         }

//         /// <summary>
//         /// Post New Tenor
//         /// </summary>
//         /// <param name="postTenor"></param>
//         /// <returns></returns>
//         [HttpPost("post", Name = "AddTenor")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<TenorResponseDto>))]
//         public async Task<IActionResult> AddTenor(TenorPostCommand postTenor)
//         {
//             var result = await _mediator.Send(postTenor);
//             if (!result.Success)
//             {
//                 return ReturnFormattedResponse(result);
//             }
//             return CreatedAtAction("GetTenorByCode", new { id = result.Data.SCO_CODE }, result.Data);
//         }

//         /// <summary>
//         /// Put Edit Tenor
//         /// </summary>
//         /// <param name="SCO_CODE"></param>
//         /// <param name="putTenor"></param>
//         /// <returns></returns>
//         [HttpPut("put/{SCO_CODE}", Name = "EditTenor")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<TenorResponseDto>))]
//         public async Task<IActionResult> EditTenor([FromRoute] string SCO_CODE, [FromBody] TenorPutCommand putTenor)
//         {
//             putTenor.SCO_CODE = SCO_CODE;
//             var result = await _mediator.Send(putTenor);
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Delete Tenor
//         /// </summary>
//         /// <param name="SCO_CODE"></param>
//         /// <param name="deleteCommand"></param>
//         /// <returns></returns>
//         [HttpDelete("delete/{SCO_CODE}", Name = "DeleteTenor")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
//         public async Task<IActionResult> DeleteTenor([FromRoute] string SCO_CODE, [FromBody]TenorDeleteCommand deleteCommand)
//         {
//             deleteCommand.SCO_CODE = SCO_CODE;
//             return Ok(await _mediator.Send(deleteCommand));
//         }
//     }
// }