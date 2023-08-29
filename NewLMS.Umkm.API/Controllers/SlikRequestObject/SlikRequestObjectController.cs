// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using NewLMS.UMKM.Data.Dto.SlikRequestObjects;
// using MediatR;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using NewLMS.UMKM.MediatR.Features.SlikRequestObjects.Commands;
// using NewLMS.UMKM.MediatR.Features.SlikRequestObjects.Queries;
// using NewLMS.UMKM.Common.GenericRespository;
// using NewLMS.UMKM.Helper;

// namespace NewLMS.UMKM.API.Controllers.SlikRequestObject
// {
//     public class SlikRequestObjectController : BaseController
//     {
//         public IMediator _mediator { get; set; }

//         /// <summary>
//         /// SlikRequestObject
//         /// </summary>
//         /// <param name="mediator"></param>
//         public SlikRequestObjectController(IMediator mediator)
//         {
//             _mediator = mediator;
//         }

//         /// <summary>
//         /// Get SlikRequestObject By Id
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <returns></returns>
//         [HttpGet("get/{Id}", Name = "GetSlikRequestObjectByCode")]
//         [Produces("application/json", "application/xml", Type = typeof(SlikRequestObjectResponseDto))]
//         public async Task<IActionResult> GetSlikRequestObjectByCode(Guid Id)
//         {
//             var getSCOQuery = new SlikRequestObjectGetQuery { Id = Id };
//             var result = await _mediator.Send(getSCOQuery);
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Get SlikRequestObject
//         /// </summary>
//         /// <param name="filterQuery"></param>
//         /// <returns></returns>
//         [HttpPost("get", Name = "GetSlikRequestObjectList")]
//         [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<SlikRequestObjectResponseDto>>))]
//         public async Task<IActionResult> GetSlikRequestObjectList(SlikRequestObjectsGetFilterQuery filterQuery)
//         {
//             var result = await _mediator.Send(filterQuery);
//             return Ok(result);
//         }

//         /// <summary>
//         /// Post New SlikRequestObject
//         /// </summary>
//         /// <param name="postSlikRequestObject"></param>
//         /// <returns></returns>
//         [HttpPost("post", Name = "AddSlikRequestObject")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<SlikRequestObjectResponseDto>))]
//         public async Task<IActionResult> AddSlikRequestObject(SlikRequestObjectPostCommand postSlikRequestObject)
//         {
//             var result = await _mediator.Send(postSlikRequestObject);
//             if (!result.Success)
//             {
//                 return ReturnFormattedResponse(result);
//             }
//             return CreatedAtAction("GetSlikRequestObjectByCode", new { id = result.Data.Id }, result.Data);
//         }

//         /// <summary>
//         /// UploadFile SlikRequestObject
//         /// </summary>
//         /// <param name="UploadFileSlikRequestObject"></param>
//         /// <returns></returns>
//         [HttpPost("upload", Name = "UploadFileSlikRequestObject")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<SlikRequestObjectResponseDto>))]
//         public async Task<IActionResult> UploadFileSlikRequestObject([FromForm] SlikRequestObjectUploadCommandPostCommand UploadFileSlikRequestObject)
//         {
//             var result = await _mediator.Send(UploadFileSlikRequestObject);
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Put Edit SlikRequestObject
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <param name="putSlikRequestObject"></param>
//         /// <returns></returns>
//         [HttpPut("put/{Id}", Name = "EditSlikRequestObject")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<SlikRequestObjectResponseDto>))]
//         public async Task<IActionResult> EditSlikRequestObject([FromRoute] Guid Id, [FromBody] SlikRequestObjectPutCommand putSlikRequestObject)
//         {
//             putSlikRequestObject.Id = Id;
//             var result = await _mediator.Send(putSlikRequestObject);
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Delete SlikRequestObject
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <param name="deleteCommand"></param>
//         /// <returns></returns>
//         [HttpDelete("delete/{Id}", Name = "DeleteSlikRequestObject")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
//         public async Task<IActionResult> DeleteSlikRequestObject([FromRoute] Guid Id, [FromBody]SlikRequestObjectDeleteCommand deleteCommand)
//         {
//             deleteCommand.Id = Id;
//             return Ok(await _mediator.Send(deleteCommand));
//         }
//     }
// }