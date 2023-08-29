// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using NewLMS.UMKM.Data.Dto.Surveys;
// using MediatR;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using NewLMS.UMKM.MediatR.Features.Surveys.Commands;
// using NewLMS.UMKM.MediatR.Features.Surveys.Queries;
// using NewLMS.UMKM.Common.GenericRespository;
// using NewLMS.UMKM.Helper;

// namespace NewLMS.UMKM.API.Controllers.Survey
// {
//     public class SurveyController : BaseController
//     {
//         public IMediator _mediator { get; set; }

//         /// <summary>
//         /// Survey
//         /// </summary>
//         /// <param name="mediator"></param>
//         public SurveyController(IMediator mediator)
//         {
//             _mediator = mediator;
//         }

//         /// <summary>
//         /// Get OTS Survey
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <returns></returns>
//         [HttpGet("ots/get/{Id}", Name = "GetOTSSurvey")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
//         public async Task<IActionResult> GetRACSurvey(Guid Id)
//         {
//             var result = await _mediator.Send(new SurveyOTSGetQuery { Id = Id });
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Get Verifikasi Survey
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <returns></returns>
//         [HttpGet("verifikasi/get/{Id}", Name = "GetVerifikasiSurvey")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
//         public async Task<IActionResult> GetVerifikasiSurvey(Guid Id)
//         {
//             var result = await _mediator.Send(new SurveyVerifikasiGetQuery { Id = Id });
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Proses Prescreening
//         /// </summary>
//         /// <param name="prosesSurvey"></param>
//         /// <returns></returns>
//         [HttpPost("proses", Name = "ProsesSurvey")]
//         [Produces("application/json", "application/xml", Type = typeof(SurveyProsesResponse))]
//         public async Task<IActionResult> ProsesSurvey(SurveyProsesCommand prosesSurvey)
//         {
//             var result = await _mediator.Send(prosesSurvey);
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Reject Survey
//         /// </summary>
//         /// <param name="RejectSurvey"></param>
//         /// <returns></returns>
//         [HttpPost("reject", Name = "RejectSurvey")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<SurveyProsesResponse>))]
//         public async Task<IActionResult> RejectSurvey(SurveyRejectCommand RejectSurvey)
//         {
//             var result = await _mediator.Send(RejectSurvey);
//             if (!result.Success)
//             {
//                 return ReturnFormattedResponse(result);
//             }
//             return Ok(result);
//         }

//         /// <summary>
//         /// Kembali ke IDE
//         /// </summary>
//         /// <param name="SurveyKembaliKeIDE"></param>
//         /// <returns></returns>
//         [HttpPost("kembali/ide", Name = "SurveyKembaliKeIDE")]
//         [Produces("application/json", "application/xml", Type = typeof(SurveyProsesResponse))]
//         public async Task<IActionResult> SurveyKembaliKeIDE(SurveyKembaliKeIDECommand SurveyKembaliKeIDE)
//         {
//             var result = await _mediator.Send(SurveyKembaliKeIDE);
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Get List Survey
//         /// </summary>
//         /// <param name="getSurveyList"></param>
//         /// <returns></returns>
//         [HttpPost("survey/list/get", Name = "SurveyListGet")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
//         public async Task<IActionResult> SurveyListGet([FromBody] SurveyTableGetFilterQuery getSurveyList)
//         {
//             var result = await _mediator.Send(getSurveyList);
//             return Ok(result);
//         }

//         // /// <summary>
//         // /// Proses Survey
//         // /// </summary>
//         // /// <param name="prosesSurvey"></param>
//         // /// <returns></returns>
//         // [HttpPost("proses", Name = "ProsesSurvey")]
//         // [Produces("application/json", "application/xml", Type = typeof(SurveyProsesResponse))]
//         // public async Task<IActionResult> ProsesSurvey(SurveyProsesCommand prosesSurvey)
//         // {
//         //     var result = await _mediator.Send(prosesSurvey);
//         //     return ReturnFormattedResponse(result);
//         // }

//         /// <summary>
//         /// Put Update OTS Survey
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <param name="putOTS"></param>
//         /// <returns></returns>
//         [HttpPut("ots/put/{Id}", Name = "PutOTSSurvey")]
//         [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<SurveyTableResponse>>))]
//         public async Task<IActionResult> PutOTSSurvey([FromRoute] Guid Id, [FromBody] SurveyOTSPutCommand putOTS)
//         {
//             putOTS.Id = Id;
//             var result = await _mediator.Send(putOTS);
//             return Ok(result);
//         }

//         /// <summary>
//         /// Put Update Verifikasi Survey
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <param name="putVerifikasi"></param>
//         /// <returns></returns>
//         [HttpPut("verifikasi/put/{Id}", Name = "PutVerifikasiSurvey")]
//         [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<SurveyTableResponse>>))]
//         public async Task<IActionResult> PutVerifikasiSurvey([FromRoute] Guid Id, [FromBody] SurveyVerifikasiPutCommand putVerifikasi)
//         {
//             putVerifikasi.Id = Id;
//             var result = await _mediator.Send(putVerifikasi);
//             return Ok(result);
//         }

//     }
// }