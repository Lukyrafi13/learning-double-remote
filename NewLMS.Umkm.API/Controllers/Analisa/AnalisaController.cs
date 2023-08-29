// using System;
// using System.Threading.Tasks;
// using NewLMS.UMKM.Data.Dto.Analisas;
// using MediatR;
// using Microsoft.AspNetCore.Mvc;
// using NewLMS.UMKM.MediatR.Features.Analisas.Commands;
// using NewLMS.UMKM.MediatR.Features.Analisas.Queries;
// using NewLMS.UMKM.Helper;

// namespace NewLMS.UMKM.API.Controllers.Analisa
// {
//     public class AnalisaController : BaseController
//     {
//         public IMediator _mediator { get; set; }

//         /// <summary>
//         /// Analisa
//         /// </summary>
//         /// <param name="mediator"></param>
//         public AnalisaController(IMediator mediator)
//         {
//             _mediator = mediator;
//         }
        
//         /// <summary>
//         /// Get Informasi Usaha Analisa
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <returns></returns>
//         [HttpGet("informasi-usaha/get/{Id}", Name = "GetInformasiUsahaAnalisa")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<AnalisaInformasiUsahaResponse>))]
//         public async Task<IActionResult> GetInformasiUsahaAnalisa(Guid Id)
//         {
//             var result = await _mediator.Send(new AnalisaInformasiUsahaGetQuery{ Id = Id });
//             return ReturnFormattedResponse(result);
//         }
        
//         /// <summary>
//         /// Get Kemampuan Membayar Analisa
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <returns></returns>
//         [HttpGet("kemampuan-membayar/get/{Id}", Name = "GetKemampuanMembayarAnalisa")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<AnalisaKemampuanMembayarResponse>))]
//         public async Task<IActionResult> GetKemampuanMembayarAnalisa(Guid Id)
//         {
//             var result = await _mediator.Send(new AnalisaKemampuanMembayarGetQuery{ Id = Id });
//             return ReturnFormattedResponse(result);
//         }
        
//         /// <summary>
//         /// Get Compliance Sheet Analisa
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <returns></returns>
//         [HttpGet("compliance-sheet/get/{Id}", Name = "GetComplianceSheetAnalisa")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<AnalisaComplianceSheetResponse>))]
//         public async Task<IActionResult> GetComplianceSheetAnalisa(Guid Id)
//         {
//             var result = await _mediator.Send(new AnalisaComplianceSheetGetQuery{ Id = Id });
//             return ReturnFormattedResponse(result);
//         }
        
//         /// <summary>
//         /// Get Hubungan Bank Analisa
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <returns></returns>
//         [HttpGet("hubungan-bank/get/{Id}", Name = "GetHubunganBankAnalisa")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<AnalisaHubunganBankResponse>))]
//         public async Task<IActionResult> GetHubunganBankAnalisa(Guid Id)
//         {
//             var result = await _mediator.Send(new AnalisaHubunganBankGetQuery{ Id = Id });
//             return ReturnFormattedResponse(result);
//         }
        
//         /// <summary>
//         /// Get Informasi Pencairan Analisa
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <returns></returns>
//         [HttpGet("informasi-pencairan/get/{Id}", Name = "GetInformasiPencairanAnalisa")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
//         public async Task<IActionResult> GetInformasiPencairanAnalisa(Guid Id)
//         {
//             var result = await _mediator.Send(new AnalisaInformasiPencairanGetQuery{ Id = Id });
//             return ReturnFormattedResponse(result);
//         }
        
//         /// <summary>
//         /// Get Hasil Rekomendasi Analisa
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <returns></returns>
//         [HttpGet("hasil-rekomendasi/get/{Id}", Name = "GetHasilRekomendasiAnalisa")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
//         public async Task<IActionResult> GetHasilRekomendasiAnalisa(Guid Id)
//         {
//             var result = await _mediator.Send(new AnalisaHasilRekomendasiGetQuery{ Id = Id });
//             return ReturnFormattedResponse(result);
//         }
        
//         /// <summary>
//         /// Get Hasil Rekomendasi Analisa Siklus
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <returns></returns>
//         [HttpGet("hasil-rekomendasi-siklus/get/{Id}", Name = "GetHasilRekomendasiSiklusAnalisa")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
//         public async Task<IActionResult> GetHasilRekomendasiSiklusAnalisa(Guid Id)
//         {
//             var result = await _mediator.Send(new AnalisaHasilRekomendasiSiklusGetQuery{ Id = Id });
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Get List Analisa
//         /// </summary>
//         /// <param name="getAnalisaList"></param>
//         /// <returns></returns>
//         [HttpPost("app/list/get", Name = "AnalisaListGet")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
//         public async Task<IActionResult> AnalisaListGet([FromBody] AnalisasGetFilterQuery getAnalisaList)
//         {
//             var result = await _mediator.Send(getAnalisaList);
//             return Ok(result);
//         }

//         /// <summary>
//         /// Proses Analisa
//         /// </summary>
//         /// <param name="FillSBDKBMPK"></param>
//         /// <returns></returns>
//         [HttpPost("fill/sbdkbmpk", Name = "FillSBDKBMPK")]
//         [Produces("application/json", "application/xml", Type = typeof(Unit))]
//         public async Task<IActionResult> FillSBDKBMPK(AnalisaFillBMPKSBDKCommand FillSBDKBMPK)
//         {
//             var result = await _mediator.Send(FillSBDKBMPK);
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Proses Analisa
//         /// </summary>
//         /// <param name="prosesAnalisa"></param>
//         /// <returns></returns>
//         [HttpPost("proses", Name = "ProsesAnalisa")]
//         [Produces("application/json", "application/xml", Type = typeof(AnalisaProsesResponse))]
//         public async Task<IActionResult> ProsesAnalisa(AnalisaProsesCommand prosesAnalisa)
//         {
//             var result = await _mediator.Send(prosesAnalisa);
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Reject Analisa
//         /// </summary>
//         /// <param name="RejectAnalisa"></param>
//         /// <returns></returns>
//         [HttpPost("reject", Name = "RejectAnalisa")]
//         [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<AnalisaProsesResponse>))]
//         public async Task<IActionResult> RejectAnalisa(AnalisaRejectCommand RejectAnalisa)
//         {
//             var result = await _mediator.Send(RejectAnalisa);
//             if (!result.Success)
//             {
//                 return ReturnFormattedResponse(result);
//             }
//             return Ok(result);
//         }

//         /// <summary>
//         /// Kembali ke IDE
//         /// </summary>
//         /// <param name="AnalisaKembaliKeIDE"></param>
//         /// <returns></returns>
//         [HttpPost("kembali/ide", Name = "AnalisaKembaliKeIDE")]
//         [Produces("application/json", "application/xml", Type = typeof(AnalisaProsesResponse))]
//         public async Task<IActionResult> AnalisaKembaliKeIDE(AnalisaKembaliKeIDECommand AnalisaKembaliKeIDE)
//         {
//             var result = await _mediator.Send(AnalisaKembaliKeIDE);
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Kembali ke Prescreening
//         /// </summary>
//         /// <param name="KembaliKePrescreening"></param>
//         /// <returns></returns>
//         [HttpPost("kembali/prescreening", Name = "KembaliKePrescreening")]
//         [Produces("application/json", "application/xml", Type = typeof(AnalisaProsesResponse))]
//         public async Task<IActionResult> KembaliKePrescreening(AnalisaKembaliKePrescreeningCommand KembaliKePrescreening)
//         {
//             var result = await _mediator.Send(KembaliKePrescreening);
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Kembali ke Survey
//         /// </summary>
//         /// <param name="KembaliKeSurvey"></param>
//         /// <returns></returns>
//         [HttpPost("kembali/survey", Name = "KembaliKeSurvey")]
//         [Produces("application/json", "application/xml", Type = typeof(AnalisaProsesResponse))]
//         public async Task<IActionResult> KembaliKeSurvey(AnalisaKembaliKeSurveyCommand KembaliKeSurvey)
//         {
//             var result = await _mediator.Send(KembaliKeSurvey);
//             return ReturnFormattedResponse(result);
//         }

//         /// <summary>
//         /// Put Update InformasiUsaha Analisa
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <param name="putInformasiUsaha"></param>
//         /// <returns></returns>
//         [HttpPut("informasi-usaha/put/{Id}", Name = "PutInformasiUsahaAnalisa")]
//         [Produces("application/json", "application/xml", Type = typeof(AnalisaInformasiUsahaResponse))]
//         public async Task<IActionResult> PutInformasiUsahaAnalisa([FromRoute] Guid Id, [FromBody] AnalisaInformasiUsahaPutCommand putInformasiUsaha)
//         {
//             putInformasiUsaha.Id = Id;
//             var result = await _mediator.Send(putInformasiUsaha);
//             return Ok(result);
//         }

//         /// <summary>
//         /// Put Update HubunganBank Analisa
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <param name="putHubunganBank"></param>
//         /// <returns></returns>
//         [HttpPut("hubungan-bank/put/{Id}", Name = "PutHubunganBankAnalisa")]
//         [Produces("application/json", "application/xml", Type = typeof(AnalisaHubunganBankResponse))]
//         public async Task<IActionResult> PutHubunganBankAnalisa([FromRoute] Guid Id, [FromBody] AnalisaHubunganBankPutCommand putHubunganBank)
//         {
//             putHubunganBank.Id = Id;
//             var result = await _mediator.Send(putHubunganBank);
//             return Ok(result);
//         }

//         /// <summary>
//         /// Put Update KemampuanMembayar Analisa
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <param name="putKemampuanMembayar"></param>
//         /// <returns></returns>
//         [HttpPut("kemampuan-membayar/put/{Id}", Name = "PutKemampuanMembayarAnalisa")]
//         [Produces("application/json", "application/xml", Type = typeof(AnalisaKemampuanMembayarResponse))]
//         public async Task<IActionResult> PutKemampuanMembayarAnalisa([FromRoute] Guid Id, [FromBody] AnalisaKemampuanMembayarPutCommand putKemampuanMembayar)
//         {
//             putKemampuanMembayar.Id = Id;
//             var result = await _mediator.Send(putKemampuanMembayar);
//             return Ok(result);
//         }

//         /// <summary>
//         /// Put Update ComplianceSheet Analisa
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <param name="putComplianceSheet"></param>
//         /// <returns></returns>
//         [HttpPut("compliance-sheet/put/{Id}", Name = "PutComplianceSheetAnalisa")]
//         [Produces("application/json", "application/xml", Type = typeof(AnalisaComplianceSheetResponse))]
//         public async Task<IActionResult> PutComplianceSheetAnalisa([FromRoute] Guid Id, [FromBody] AnalisaComplianceSheetPutCommand putComplianceSheet)
//         {
//             putComplianceSheet.Id = Id;
//             var result = await _mediator.Send(putComplianceSheet);
//             return Ok(result);
//         }

//         /// <summary>
//         /// Put Update Informasi Pencairan Analisa
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <param name="putInformasiPencairan"></param>
//         /// <returns></returns>
//         [HttpPut("informasi-pencairan/put/{Id}", Name = "PutInformasiPencairanAnalisa")]
//         [Produces("application/json", "application/xml", Type = typeof(AnalisaInformasiPencairanResponse))]
//         public async Task<IActionResult> PutInformasiPencairanAnalisa([FromRoute] Guid Id, [FromBody] AnalisaInformasiPencairanPutCommand putInformasiPencairan)
//         {
//             putInformasiPencairan.Id = Id;
//             var result = await _mediator.Send(putInformasiPencairan);
//             return Ok(result);
//         }

//         /// <summary>
//         /// Put Update Hasil Rekomendasi Analisa
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <param name="putHasilRekomendasi"></param>
//         /// <returns></returns>
//         [HttpPut("hasil-rekomendasi/put/{Id}", Name = "PutHasilRekomendasiAnalisa")]
//         [Produces("application/json", "application/xml", Type = typeof(AnalisaHasilRekomendasiResponse))]
//         public async Task<IActionResult> PutHasilRekomendasiAnalisa([FromRoute] Guid Id, [FromBody] AnalisaHasilRekomendasiPutCommand putHasilRekomendasi)
//         {
//             putHasilRekomendasi.Id = Id;
//             var result = await _mediator.Send(putHasilRekomendasi);
//             return Ok(result);
//         }

//         /// <summary>
//         /// Put Update Hasil Rekomendasi Analisa Siklus
//         /// </summary>
//         /// <param name="Id"></param>
//         /// <param name="putHasilRekomendasiSiklus"></param>
//         /// <returns></returns>
//         [HttpPut("hasil-rekomendasi-siklus/put/{Id}", Name = "PutHasilRekomendasiSiklusAnalisa")]
//         [Produces("application/json", "application/xml", Type = typeof(AnalisaHasilRekomendasiSiklusResponse))]
//         public async Task<IActionResult> PutHasilRekomendasiSiklusAnalisa([FromRoute] Guid Id, [FromBody] AnalisaHasilRekomendasiSiklusPutCommand putHasilRekomendasiSiklus)
//         {
//             putHasilRekomendasiSiklus.Id = Id;
//             var result = await _mediator.Send(putHasilRekomendasiSiklus);
//             return Ok(result);
//         }
        
//     }
// }