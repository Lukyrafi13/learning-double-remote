// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using NewLMS.UMKM.Data.Dto.SlikRequests;
// using MediatR;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using NewLMS.UMKM.MediatR.Features.SlikRequests.Commands;
// using NewLMS.UMKM.MediatR.Features.SlikRequests.Queries;
// using NewLMS.UMKM.Common.GenericRespository;
// using NewLMS.UMKM.Helper;
// using Hangfire;
// using Bjb.DigitalBisnis.SLIK.Models.GetResult;
// using Microsoft.AspNetCore.Http;
// using NewLMS.UMKM.MediatR.Features.SlikRequestDuplikasis.Commands;

// namespace NewLMS.UMKM.API.Controllers.SlikRequest
// {
//     public class SlikRequestController : BaseController
//     {
//         public IMediator _mediator { get; set; }

//         /// <summary>
//         /// SlikRequest
//         /// </summary>
//         /// <param name="mediator"></param>
//         public SlikRequestController(IMediator mediator)
//         {
//             _mediator = mediator;
//         }

//         /// <summary>
//         /// Get Summary SlikRequest
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <returns></returns>
//         [HttpGet("summary/get/{Id}", Name = "GetSummarySlikRequest")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
//         public async Task<IActionResult> GetSummarySlikRequest(Guid Id)
//         {
//             var result = await _mediator.Send(new SlikRequestSummaryGetQuery { Id = Id });
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Get List SlikRequest
//         /// </summary>
//         /// <param name="getAppList"></param>
//         /// <returns></returns>
//         [HttpPost("app/list/get", Name = "SLIKRequestListGet")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
//         public async Task<IActionResult> SLIKRequestListGet([FromBody] SlikRequestsGetFilterQuery getAppList)
//         {
//             var result = await _mediator.Send(getAppList);
//             return Ok(result);
//         }

//         /// <summary>
//         /// Proses SlikRequest
//         /// </summary>
//         /// <param name="prosesSlikRequest"></param>
//         /// <returns></returns>
//         [HttpPost("proses", Name = "ProsesSlikRequest")]
//         [Produces("application/json", "application/xml", Type = typeof(SlikRequestProsesResponse))]
//         public async Task<IActionResult> ProsesSlikRequest(SlikRequestProsesCommand prosesSlikRequest)
//         {
//             var result = await _mediator.Send(prosesSlikRequest);
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Reject SlikRequest
//         /// </summary>
//         /// <param name="RejectSlikRequest"></param>
//         /// <returns></returns>
//         [HttpPost("reject", Name = "RejectSlikRequest")]
//         [Produces("application/json", "application/xml", Type = typeof(SlikRequestProsesResponse))]
//         public async Task<IActionResult> RejectSlikRequest(SlikRequestRejectCommand RejectSlikRequest)
//         {
//             var result = await _mediator.Send(RejectSlikRequest);
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Reject SlikRequest Multiple
//         /// </summary>
//         /// <param name="RejectSlikRequestMultiple"></param>
//         /// <returns></returns>
//         [HttpPost("reject/multiple", Name = "RejectSlikRequestMultiple")]
//         [Produces("application/json", "application/xml", Type = typeof(SlikRequestProsesResponse))]
//         public async Task<IActionResult> RejectSlikRequestMultiple(SlikRequestRejectMultipleCommand RejectSlikRequestMultiple)
//         {
//             var result = await _mediator.Send(RejectSlikRequestMultiple);
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// KembaliKeIDE SlikRequest
//         /// </summary>
//         /// <param name="KembaliKeIDESlikRequest"></param>
//         /// <returns></returns>
//         [HttpPost("kembali/ide", Name = "KembaliKeIDESlikRequest")]
//         [Produces("application/json", "application/xml", Type = typeof(SlikRequestProsesResponse))]
//         public async Task<IActionResult> KembaliKeIDESlikRequest(SlikRequestKembaliKeIDECommand KembaliKeIDESlikRequest)
//         {
//             var result = await _mediator.Send(KembaliKeIDESlikRequest);
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// KembaliKeIDE SlikRequest Multiple
//         /// </summary>
//         /// <param name="KembaliKeIDESlikRequestMultiple"></param>
//         /// <returns></returns>
//         [HttpPost("kembali/ide/multiple", Name = "KembaliKeIDESlikRequestMultiple")]
//         [Produces("application/json", "application/xml", Type = typeof(SlikRequestProsesResponse))]
//         public async Task<IActionResult> KembaliKeIDESlikRequestMultiple(SlikRequestKembaliKeIDEMultipleCommand KembaliKeIDESlikRequestMultiple)
//         {
//             var result = await _mediator.Send(KembaliKeIDESlikRequestMultiple);
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Proses Admin SlikRequest
//         /// </summary>
//         /// <param name="prosesAdminSlik"></param>
//         /// <returns></returns>
//         [HttpPost("proses/admin", Name = "prosesAdminSlik")]
//         [Produces("application/json", "application/xml", Type = typeof(SlikRequestProsesAdminResponse))]
//         public async Task<IActionResult> prosesAdminSlik(SlikRequestProsesAdminCommand prosesAdminSlik)
//         {
//             var result = await _mediator.Send(prosesAdminSlik);
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Proses Admin Prescreening SlikRequest
//         /// </summary>
//         /// <param name="prosesAdminPrescreeningSlik"></param>
//         /// <returns></returns>
//         [HttpPost("proses/admin/prescreening", Name = "prosesAdminPrescreeningSlik")]
//         [Produces("application/json", "application/xml", Type = typeof(SlikRequestProsesAdminResponse))]
//         public async Task<IActionResult> prosesAdminPrescreeningSlik(SlikRequestProsesAdminPrescreeningCommand prosesAdminPrescreeningSlik)
//         {
//             var result = await _mediator.Send(prosesAdminPrescreeningSlik);
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Proses Kontingensi SlikRequest
//         /// </summary>
//         /// <param name="prosesKontingensiSlik"></param>
//         /// <returns></returns>
//         [HttpPost("proses/kontingensi", Name = "prosesKontingensiSlik")]
//         [Produces("application/json", "application/xml", Type = typeof(byte[]))]
//         public async Task<IActionResult> prosesKontingensiSlik(SlikRequestProsesKontingensiCommand prosesKontingensiSlik)
//         {
//             var result = await _mediator.Send(prosesKontingensiSlik);
//             return File(result, "text/plain", $"SLIK_KONTIGENSI_{DateTime.Now.ToString("dd_MM_yyyy")}.txt");
//         }

//         /// <summary>
//         /// Upload History Credit SlikRequest
//         /// </summary>
//         /// <param name="uploadManualHistoryKredit"></param>
//         /// <returns></returns>
//         [HttpPost("upload/history", Name = "uploadManualHistoryKredit")]
//         [Produces("application/json", "application/xml", Type = typeof(SlikRequestProsesAdminResponse))]
//         public async Task<IActionResult> uploadManualHistoryKredit([FromForm] UploadSlikManualCommand uploadManualHistoryKredit)
//         {
//             var result = await _mediator.Send(uploadManualHistoryKredit);
//             return Ok(result);
//         }

//         /// <summary>
//         /// Post Check Duplikasi
//         /// </summary>
//         /// <param name="SlikRequestId"></param>
//         /// <returns></returns>
//         [HttpPost("duplikasi/check/", Name = "CheckDuplication")]
//         [ProducesResponseType(type: typeof(ServiceResponse<SlikGetIndividualResultResponse>), statusCode: StatusCodes.Status200OK)]
//         public IActionResult CheckDuplication(Guid SlikRequestId)
//         {
//             BackgroundJob.Enqueue<DuplicationCheckTask>(x => x.DuplicationCheck(SlikRequestId));
//             return Ok();
//         }

//         /// <summary>
//         /// Post Test Duplikasi
//         /// </summary>
//         /// <param name="TestDuplikasi"></param>
//         /// <returns></returns>
//         [HttpPost("duplikasi/test/", Name = "TestDuplikasi")]
//         [ProducesResponseType(type: typeof(ServiceResponse<SlikGetIndividualResultResponse>), statusCode: StatusCodes.Status200OK)]
//         public async Task<IActionResult> TestDuplikasi(DuplicationCheckPostCommand TestDuplikasi)
//         {
//             var res =await _mediator.Send(TestDuplikasi);

//             return Ok(res);
//         }

//         /// <summary>
//         /// Put Update Summary SlikRequest
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <param name="putSummary"></param>
//         /// <returns></returns>
//         [HttpPut("summary/put/{Id}", Name = "PutSummarySlikRequest")]
//         [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<SlikRequestTableResponse>>))]
//         public async Task<IActionResult> PutSummarySlikRequest([FromRoute] Guid Id, [FromBody] SlikRequestSummaryPutCommand putSummary)
//         {
//             putSummary.Id = Id;
//             var result = await _mediator.Send(putSummary);
//             return Ok(result);
//         }
        
//     }
// }