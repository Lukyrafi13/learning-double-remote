// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using NewLMS.UMKM.Data.Dto.AnalisaPinjamanDariBanks;
// using MediatR;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using NewLMS.UMKM.MediatR.Features.AnalisaPinjamanDariBanks.Commands;
// using NewLMS.UMKM.MediatR.Features.AnalisaPinjamanDariBanks.Queries;
// using NewLMS.UMKM.Common.GenericRespository;
// using NewLMS.UMKM.Helper;

// namespace NewLMS.UMKM.API.Controllers.AnalisaPinjamanDariBank
// {
//     public class AnalisaPinjamanDariBankController : BaseController
//     {
//         public IMediator _mediator { get; set; }

//         /// <summary>
//         /// AnalisaPinjamanDariBank
//         /// </summary>
//         /// <param name="mediator"></param>
//         public AnalisaPinjamanDariBankController(IMediator mediator)
//         {
//             _mediator = mediator;
//         }

//         /// <summary>
//         /// Get AnalisaPinjamanDariBank By Id
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <returns></returns>
//         [HttpGet("get/{Id}", Name = "GetAnalisaPinjamanDariBankByCode")]
//         [Produces("application/json", "application/xml", Type = typeof(AnalisaPinjamanDariBankResponseDto))]
//         public async Task<IActionResult> GetAnalisaPinjamanDariBankByCode(Guid Id)
//         {
//             var getSCOQuery = new AnalisaPinjamanDariBankGetQuery { Id = Id };
//             var result = await _mediator.Send(getSCOQuery);
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Get AnalisaPinjamanDariBank
//         /// </summary>
//         /// <param name="filterQuery"></param>
//         /// <returns></returns>
//         [HttpPost("get", Name = "GetAnalisaPinjamanDariBankList")]
//         [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<AnalisaPinjamanDariBankResponseDto>>))]
//         public async Task<IActionResult> GetAnalisaPinjamanDariBankList(AnalisaPinjamanDariBanksGetFilterQuery filterQuery)
//         {
//             var result = await _mediator.Send(filterQuery);
//             return Ok(result);
//         }

//         /// <summary>
//         /// Post New AnalisaPinjamanDariBank
//         /// </summary>
//         /// <param name="postAnalisaPinjamanDariBank"></param>
//         /// <returns></returns>
//         [HttpPost("post", Name = "AddAnalisaPinjamanDariBank")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<AnalisaPinjamanDariBankResponseDto>))]
//         public async Task<IActionResult> AddAnalisaPinjamanDariBank(AnalisaPinjamanDariBankPostCommand postAnalisaPinjamanDariBank)
//         {
//             var result = await _mediator.Send(postAnalisaPinjamanDariBank);
//             if (!result.Success)
//             {
//                 return ReturnFormattedResponse(result);
//             }
//             return CreatedAtAction("GetAnalisaPinjamanDariBankByCode", new { id = result.Data.Id }, result.Data);
//         }

//         /// <summary>
//         /// Put Edit AnalisaPinjamanDariBank
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <param name="putAnalisaPinjamanDariBank"></param>
//         /// <returns></returns>
//         [HttpPut("put/{Id}", Name = "EditAnalisaPinjamanDariBank")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<AnalisaPinjamanDariBankResponseDto>))]
//         public async Task<IActionResult> EditAnalisaPinjamanDariBank([FromRoute] Guid Id, [FromBody] AnalisaPinjamanDariBankPutCommand putAnalisaPinjamanDariBank)
//         {
//             putAnalisaPinjamanDariBank.Id = Id;
//             var result = await _mediator.Send(putAnalisaPinjamanDariBank);
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Delete AnalisaPinjamanDariBank
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <param name="deleteCommand"></param>
//         /// <returns></returns>
//         [HttpDelete("delete/{Id}", Name = "DeleteAnalisaPinjamanDariBank")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
//         public async Task<IActionResult> DeleteAnalisaPinjamanDariBank([FromRoute] Guid Id, [FromBody]AnalisaPinjamanDariBankDeleteCommand deleteCommand)
//         {
//             deleteCommand.Id = Id;
//             return Ok(await _mediator.Send(deleteCommand));
//         }
//     }
// }