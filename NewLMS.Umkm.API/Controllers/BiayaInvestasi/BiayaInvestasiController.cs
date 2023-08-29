// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using NewLMS.UMKM.Data.Dto.BiayaInvestasis;
// using MediatR;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using NewLMS.UMKM.MediatR.Features.BiayaInvestasis.Commands;
// using NewLMS.UMKM.MediatR.Features.BiayaInvestasis.Queries;
// using NewLMS.UMKM.Common.GenericRespository;
// using NewLMS.UMKM.Helper;

// namespace NewLMS.UMKM.API.Controllers.BiayaInvestasi
// {
//     public class BiayaInvestasiController : BaseController
//     {
//         public IMediator _mediator { get; set; }

//         /// <summary>
//         /// BiayaInvestasi
//         /// </summary>
//         /// <param name="mediator"></param>
//         public BiayaInvestasiController(IMediator mediator)
//         {
//             _mediator = mediator;
//         }

//         /// <summary>
//         /// Get BiayaInvestasi By Id
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <returns></returns>
//         [HttpGet("get/{Id}", Name = "GetBiayaInvestasiById")]
//         [Produces("application/json", "application/xml", Type = typeof(BiayaInvestasiResponseDto))]
//         public async Task<IActionResult> GetBiayaInvestasiById(Guid Id)
//         {
//             var getGenderQuery = new BiayaInvestasiGetQuery { Id = Id };
//             var result = await _mediator.Send(getGenderQuery);
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Get BiayaInvestasi
//         /// </summary>
//         /// <param name="filterQuery"></param>
//         /// <returns></returns>
//         [HttpPost("get", Name = "GetBiayaInvestasiList")]
//         [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<BiayaInvestasiResponseDto>>))]
//         public async Task<IActionResult> GetBiayaInvestasiList(BiayaInvestasisGetFilterQuery filterQuery)
//         {
//             var result = await _mediator.Send(filterQuery);
//             return Ok(result);
//         }

//         /// <summary>
//         /// Post New BiayaInvestasi
//         /// </summary>
//         /// <param name="postBiayaInvestasi"></param>
//         /// <returns></returns>
//         [HttpPost("post", Name = "AddBiayaInvestasi")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<BiayaInvestasiResponseDto>))]
//         public async Task<IActionResult> AddBiayaInvestasi(BiayaInvestasiPostCommand postBiayaInvestasi)
//         {
//             var result = await _mediator.Send(postBiayaInvestasi);
//             if (!result.Success)
//             {
//                 return ReturnFormattedResponse(result);
//             }
//             return CreatedAtAction("GetBiayaInvestasiById", new { id = result.Data.Id }, result.Data);
//         }

//         /// <summary>
//         /// Put Edit BiayaInvestasi
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <param name="putBiayaInvestasi"></param>
//         /// <returns></returns>
//         [HttpPut("put/{Id}", Name = "EditBiayaInvestasi")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<BiayaInvestasiResponseDto>))]
//         public async Task<IActionResult> EditBiayaInvestasi([FromRoute] Guid Id, [FromBody] BiayaInvestasiPutCommand putBiayaInvestasi)
//         {
//             putBiayaInvestasi.Id = Id;
//             var result = await _mediator.Send(putBiayaInvestasi);
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Delete BiayaInvestasi
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <param name="deleteCommand"></param>
//         /// <returns></returns>
//         [HttpDelete("delete/{Id}", Name = "DeleteBiayaInvestasi")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
//         public async Task<IActionResult> DeleteBiayaInvestasi([FromRoute] Guid Id, [FromBody] BiayaInvestasiDeleteCommand deleteCommand)
//         {
//             deleteCommand.Id = Id;
//             return Ok(await _mediator.Send(deleteCommand));
//         }
//     }
// }