// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using NewLMS.UMKM.Data.Dto.SurveyFileUploads;
// using MediatR;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using NewLMS.UMKM.MediatR.Features.SurveyFileUploads.Commands;
// using NewLMS.UMKM.MediatR.Features.SurveyFileUploads.Queries;
// using NewLMS.UMKM.Common.GenericRespository;
// using NewLMS.UMKM.Helper;

// namespace NewLMS.UMKM.API.Controllers.SurveyFileUpload
// {
//     public class SurveyFileUploadController : BaseController
//     {
//         public IMediator _mediator { get; set; }

//         /// <summary>
//         /// SurveyFileUpload
//         /// </summary>
//         /// <param name="mediator"></param>
//         public SurveyFileUploadController(IMediator mediator)
//         {
//             _mediator = mediator;
//         }

//         /// <summary>
//         /// Get SurveyFileUpload By Id
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <returns></returns>
//         [HttpGet("get/{Id}", Name = "GetSurveyFileUploadByCode")]
//         [Produces("application/json", "application/xml", Type = typeof(SurveyFileUploadResponseDto))]
//         public async Task<IActionResult> GetSurveyFileUploadByCode(Guid Id)
//         {
//             var getSCOQuery = new SurveyFileUploadGetQuery { Id = Id };
//             var result = await _mediator.Send(getSCOQuery);
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Get SurveyFileUpload
//         /// </summary>
//         /// <param name="filterQuery"></param>
//         /// <returns></returns>
//         [HttpPost("get", Name = "GetSurveyFileUploadList")]
//         [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<SurveyFileUploadResponseDto>>))]
//         public async Task<IActionResult> GetSurveyFileUploadList(SurveyFileUploadsGetFilterQuery filterQuery)
//         {
//             var result = await _mediator.Send(filterQuery);
//             return Ok(result);
//         }

//         /// <summary>
//         /// Post New SurveyFileUpload
//         /// </summary>
//         /// <param name="postSurveyFileUpload"></param>
//         /// <returns></returns>
//         [HttpPost("post", Name = "AddSurveyFileUpload")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<SurveyFileUploadResponseDto>))]
//         public async Task<IActionResult> AddSurveyFileUpload([FromForm]SurveyFileUploadPostCommand postSurveyFileUpload)
//         {
//             var result = await _mediator.Send(postSurveyFileUpload);
//             if (!result.Success)
//             {
//                 return ReturnFormattedResponse(result);
//             }
//             return CreatedAtAction("GetSurveyFileUploadByCode", new { id = result.Data.Id }, result.Data);
//         }

//         /// <summary>
//         /// Put Edit SurveyFileUpload
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <param name="putSurveyFileUpload"></param>
//         /// <returns></returns>
//         [HttpPut("put/{Id}", Name = "EditSurveyFileUpload")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<SurveyFileUploadResponseDto>))]
//         public async Task<IActionResult> EditSurveyFileUpload([FromRoute] Guid Id, [FromForm] SurveyFileUploadPutCommand putSurveyFileUpload)
//         {
//             putSurveyFileUpload.Id = Id;
//             var result = await _mediator.Send(putSurveyFileUpload);
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Delete SurveyFileUpload
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <param name="deleteCommand"></param>
//         /// <returns></returns>
//         [HttpDelete("delete/{Id}", Name = "DeleteSurveyFileUpload")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
//         public async Task<IActionResult> DeleteSurveyFileUpload([FromRoute] Guid Id, [FromBody]SurveyFileUploadDeleteCommand deleteCommand)
//         {
//             deleteCommand.Id = Id;
//             return Ok(await _mediator.Send(deleteCommand));
//         }
//     }
// }