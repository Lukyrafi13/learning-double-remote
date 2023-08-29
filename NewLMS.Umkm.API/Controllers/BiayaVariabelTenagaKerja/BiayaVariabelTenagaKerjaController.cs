// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using NewLMS.UMKM.Data.Dto.BiayaVariabelTenagaKerjas;
// using MediatR;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using NewLMS.UMKM.MediatR.Features.BiayaVariabelTenagaKerjas.Commands;
// using NewLMS.UMKM.MediatR.Features.BiayaVariabelTenagaKerjas.Queries;
// using NewLMS.UMKM.Common.GenericRespository;
// using NewLMS.UMKM.Helper;

// namespace NewLMS.UMKM.API.Controllers.BiayaVariabelTenagaKerja
// {
//     public class BiayaVariabelTenagaKerjaController : BaseController
//     {
//         public IMediator _mediator { get; set; }

//         /// <summary>
//         /// BiayaVariabelTenagaKerja
//         /// </summary>
//         /// <param name="mediator"></param>
//         public BiayaVariabelTenagaKerjaController(IMediator mediator)
//         {
//             _mediator = mediator;
//         }

//         /// <summary>
//         /// Get BiayaVariabelTenagaKerja By Id
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <returns></returns>
//         [HttpGet("get/{Id}", Name = "GetBiayaVariabelTenagaKerjaById")]
//         [Produces("application/json", "application/xml", Type = typeof(BiayaVariabelTenagaKerjaResponseDto))]
//         public async Task<IActionResult> GetBiayaVariabelTenagaKerjaById(Guid Id)
//         {
//             var getGenderQuery = new BiayaVariabelTenagaKerjaGetQuery { Id = Id };
//             var result = await _mediator.Send(getGenderQuery);
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Get BiayaVariabelTenagaKerja
//         /// </summary>
//         /// <param name="filterQuery"></param>
//         /// <returns></returns>
//         [HttpPost("get", Name = "GetBiayaVariabelTenagaKerjaList")]
//         [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<BiayaVariabelTenagaKerjaResponseDto>>))]
//         public async Task<IActionResult> GetBiayaVariabelTenagaKerjaList(BiayaVariabelTenagaKerjasGetFilterQuery filterQuery)
//         {
//             var result = await _mediator.Send(filterQuery);
//             return Ok(result);
//         }

//         /// <summary>
//         /// Post New BiayaVariabelTenagaKerja
//         /// </summary>
//         /// <param name="postBiayaVariabelTenagaKerja"></param>
//         /// <returns></returns>
//         [HttpPost("post", Name = "AddBiayaVariabelTenagaKerja")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<BiayaVariabelTenagaKerjaResponseDto>))]
//         public async Task<IActionResult> AddBiayaVariabelTenagaKerja(BiayaVariabelTenagaKerjaPostCommand postBiayaVariabelTenagaKerja)
//         {
//             var result = await _mediator.Send(postBiayaVariabelTenagaKerja);
//             if (!result.Success)
//             {
//                 return ReturnFormattedResponse(result);
//             }
//             return CreatedAtAction("GetBiayaVariabelTenagaKerjaById", new { id = result.Data.Id }, result.Data);
//         }

//         /// <summary>
//         /// Put Edit BiayaVariabelTenagaKerja
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <param name="putBiayaVariabelTenagaKerja"></param>
//         /// <returns></returns>
//         [HttpPut("put/{Id}", Name = "EditBiayaVariabelTenagaKerja")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<BiayaVariabelTenagaKerjaResponseDto>))]
//         public async Task<IActionResult> EditBiayaVariabelTenagaKerja([FromRoute] Guid Id, [FromBody] BiayaVariabelTenagaKerjaPutCommand putBiayaVariabelTenagaKerja)
//         {
//             putBiayaVariabelTenagaKerja.Id = Id;
//             var result = await _mediator.Send(putBiayaVariabelTenagaKerja);
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Delete BiayaVariabelTenagaKerja
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <param name="deleteCommand"></param>
//         /// <returns></returns>
//         [HttpDelete("delete/{Id}", Name = "DeleteBiayaVariabelTenagaKerja")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
//         public async Task<IActionResult> DeleteBiayaVariabelTenagaKerja([FromRoute] Guid Id, [FromBody] BiayaVariabelTenagaKerjaDeleteCommand deleteCommand)
//         {
//             deleteCommand.Id = Id;
//             return Ok(await _mediator.Send(deleteCommand));
//         }
//     }
// }