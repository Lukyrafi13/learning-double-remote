// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.Data.Dto.Apps;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.MediatR.Features.LoanApplications.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using System;
using NewLMS.UMKM.MediatR.Features.LoanApplications.Queries;

namespace NewLMS.UMKM.API.Controllers.LoanApplication
{
    [Authorize]
    public class LoanApplicationController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// App
        /// </summary>
        /// <param name="mediator"></param>
        public LoanApplicationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // /// <summary>
        // /// Get LoanApplication Inbox
        // /// </summary>
        // /// <returns></returns>
        // [HttpGet("get-loanapplication-inbox/{Page}/{Length}")]
        // [ProducesResponseType(type: typeof(ServiceResponse<AppInboxResponse>), statusCode: StatusCodes.Status200OK)]
        // public async Task<IActionResult> GetLoanApplicationInbox([FromRoute] GetAppInboxQuery command)
        // {
        //     return Ok(await Mediator.Send(command));
        // }

        /// <summary>
        /// Get IDE
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("ide/get/{Id}", Name = "GetAppIDE")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> GetAppIDE(Guid Id)
        {
            var result = await _mediator.Send(new LoanApplicationIdeGet{ Id = Id });
            return ReturnFormattedResponse(result);
        }
        
        // /// <summary>
        // /// Get App Validation
        // /// </summary>
        // /// <param name="Id"></param>
        // /// <returns></returns>
        // [HttpGet("validate/{Id}", Name = "GetAppValidation")]
        // [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        // public async Task<IActionResult> GetAppValidation(Guid Id)
        // {
        //     var result = await _mediator.Send(new AppValidateCommand{ Id = Id });
        //     return ReturnFormattedResponse(result);
        // }
        
        // /// <summary>
        // /// Get Pilihan Pemutus
        // /// </summary>
        // /// <param name="Id"></param>
        // /// <returns></returns>
        // [HttpGet("pilihan-pemutus/get/{Id}", Name = "GetAppPilihanPemutus")]
        // [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        // public async Task<IActionResult> GetAppPilihanPemutus(Guid Id)
        // {
        //     var result = await _mediator.Send(new AppPilihanPemutusGet{ Id = Id });
        //     return ReturnFormattedResponse(result);
        // }
        
        /// <summary>
        /// Get Data Pemohon Perorangan
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("pemohon/perorangan/get/{Id}", Name = "GetAppPemohonPerorangan")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> GetAppPemohonPerorangan(Guid Id)
        {
            var result = await _mediator.Send(new LoanApplicationPemohonPeroranganGet{ Id = Id });
            return ReturnFormattedResponse(result);
        }

        // /// <summary>
        // /// Get Data Pemohon Badan Usaha
        // /// </summary>
        // /// <param name="Id"></param>
        // /// <returns></returns>
        // [HttpGet("pemohon/badan-usaha/get/{Id}", Name = "GetAppPemohonBadanUsaha")]
        // [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        // public async Task<IActionResult> GetAppPemohonBadanUsaha(Guid Id)
        // {
        //     var result = await _mediator.Send(new AppPemohonBadanUsahaGet{ Id = Id });
        //     return ReturnFormattedResponse(result);
        // }

        // /// <summary>
        // /// Get Data Gudang
        // /// </summary>
        // /// <param name="Id"></param>
        // /// <returns></returns>
        // [HttpGet("gudang/get/{Id}", Name = "GetAppGudang")]
        // [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        // public async Task<IActionResult> GetAppGudang(Guid Id)
        // {
        //     var result = await _mediator.Send(new AppGudangGet{ Id = Id });
        //     return ReturnFormattedResponse(result);
        // }

        // /// <summary>
        // /// Get Data Pemohon Gapoktan/Koperasi
        // /// </summary>
        // /// <param name="Id"></param>
        // /// <returns></returns>
        // [HttpGet("pemohon/gapoktan-koperasi/get/{Id}", Name = "GetAppPemohonGapoktan")]
        // [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        // public async Task<IActionResult> GetAppPemohonGapoktan(Guid Id)
        // {
        //     var result = await _mediator.Send(new AppPemohonGapoktanGet{ Id = Id });
        //     return ReturnFormattedResponse(result);
        // }

        // /// <summary>
        // /// Get List Data Tabel App
        // /// </summary>
        // /// <param name="postListTable"></param>
        // /// <returns></returns>
        // [HttpPost("app/list", Name = "GetListAppTable")]
        // [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        // public async Task<IActionResult> GetListAppTable(AppTableGetFilterQuery postListTable)
        // {
        //     var result = await _mediator.Send(postListTable);
        //     return Ok(result);
        // }

        // /// <summary>
        // /// Proses App
        // /// </summary>
        // /// <param name="prosesApp"></param>
        // /// <returns></returns>
        // [HttpPost("proses", Name = "ProsesApp")]
        // [Produces("application/json", "application/xml", Type = typeof(AppProsesResponseDto))]
        // public async Task<IActionResult> ProsesApp(AppProsesCommand prosesApp)
        // {
        //     var result = await _mediator.Send(prosesApp);
        //     return ReturnFormattedResponse(result);
        // }

        // /// <summary>
        // /// Proses Prescreening App
        // /// </summary>
        // /// <param name="prosesPrescreeningApp"></param>
        // /// <returns></returns>
        // [HttpPost("proses/prescreening", Name = "ProsesPrescreeningApp")]
        // [Produces("application/json", "application/xml", Type = typeof(AppProsesResponseDto))]
        // public async Task<IActionResult> ProsesPrescreeningApp(AppProsesPrescreeningCommand prosesPrescreeningApp)
        // {
        //     var result = await _mediator.Send(prosesPrescreeningApp);
        //     return ReturnFormattedResponse(result);
        // }

        // /// <summary>
        // /// Proses SLIK App
        // /// </summary>
        // /// <param name="prosesSLIKApp"></param>
        // /// <returns></returns>
        // [HttpPost("proses/slik", Name = "ProsesSLIKApp")]
        // [Produces("application/json", "application/xml", Type = typeof(AppProsesResponseDto))]
        // public async Task<IActionResult> ProsesSLIKApp(AppProsesSLIKCommand prosesSLIKApp)
        // {
        //     var result = await _mediator.Send(prosesSLIKApp);
        //     return ReturnFormattedResponse(result);
        // }

        // /// <summary>
        // /// Tidak Process App
        // /// </summary>
        // /// <param name="postTidakProsesApp"></param>
        // /// <returns></returns>
        // [HttpPost("tidak-proses", Name = "TidakProsesApp")]
        // [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<AppProsesResponseDto>))]
        // public async Task<IActionResult> TidakProsesApp(AppTidakProsesCommand postTidakProsesApp)
        // {
        //     var result = await _mediator.Send(postTidakProsesApp);
        //     if (!result.Success)
        //     {
        //         return ReturnFormattedResponse(result);
        //     }
        //     return Ok(result);
        // }
        
        /// <summary>
        /// Put Update IDE
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putIDE"></param>
        /// <returns></returns>
        [HttpPut("ide/update/{Id}", Name = "EditLoanApplicationIDE")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> EditLoanApplicationIDE([FromRoute] Guid Id, [FromBody] LoanApplicationIDEPutCommand putIDE)
        {
            putIDE.Id = Id;
            var result = await _mediator.Send(putIDE);
            return Ok(result);
        }
        
        // /// <summary>
        // /// Put Update PilihanPemutus
        // /// </summary>
        // /// <param name="Id"></param>
        // /// <param name="putPilihanPemutus"></param>
        // /// <returns></returns>
        // [HttpPut("pilihan-pemutus/update/{Id}", Name = "EditAppPilihanPemutus")]
        // [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        // public async Task<IActionResult> EditAppPilihanPemutus([FromRoute] Guid Id, [FromBody] AppPilihanPemutusPutCommand putPilihanPemutus)
        // {
        //     putPilihanPemutus.Id = Id;
        //     var result = await _mediator.Send(putPilihanPemutus);
        //     return Ok(result);
        // }
        
        /// <summary>
        /// Put Update Data Pemohon Perorangan
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putDataPemohon"></param>
        /// <returns></returns>
        [HttpPut("pemohon/perorangan/update/{Id}", Name = "EditAppPemohonPerorangan")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> EditAppPemohonPerorangan([FromRoute] Guid Id, [FromBody] LoanApplicationPemohonPeroranganPutCommand putDataPemohon)
        {
            putDataPemohon.Id = Id;
            var result = await _mediator.Send(putDataPemohon);
            return Ok(result);
        }

        // /// <summary>
        // /// Put Update Data Pemohon Badan Usaha
        // /// </summary>
        // /// <param name="Id"></param>
        // /// <param name="putDataPemohon"></param>
        // /// <returns></returns>
        // [HttpPut("pemohon/badan-usaha/update/{Id}", Name = "EditAppPemohonBadanUsaha")]
        // [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        // public async Task<IActionResult> EditAppPemohonBadanUsaha([FromRoute] Guid Id, [FromBody] AppPemohonBadanUsahaPutCommand putDataPemohon)
        // {
        //     putDataPemohon.Id = Id;
        //     var result = await _mediator.Send(putDataPemohon);
        //     return Ok(result);
        // }

        // /// <summary>
        // /// Put Update Data Pemohon Gapoktan/Koperasi
        // /// </summary>
        // /// <param name="Id"></param>
        // /// <param name="putDataPemohon"></param>
        // /// <returns></returns>
        // [HttpPut("pemohon/gapoktan-koperasi/update/{Id}", Name = "EditAppPemohonGapoktan")]
        // [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        // public async Task<IActionResult> EditAppPemohonGapoktan([FromRoute] Guid Id, [FromBody] AppPemohonGapoktanPutCommand putDataPemohon)
        // {
        //     putDataPemohon.Id = Id;
        //     var result = await _mediator.Send(putDataPemohon);
        //     return Ok(result);
        // }

        // /// <summary>
        // /// Put Update Data Gudang
        // /// </summary>
        // /// <param name="Id"></param>
        // /// <param name="putDataGudang"></param>
        // /// <returns></returns>
        // [HttpPut("gudang/update/{Id}", Name = "EditAppDataGudang")]
        // [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        // public async Task<IActionResult> EditAppDataGudang([FromRoute] Guid Id, [FromBody] AppGudangPutCommand putDataGudang)
        // {
        //     putDataGudang.Id = Id;
        //     var result = await _mediator.Send(putDataGudang);
        //     return Ok(result);
        // }
    }
}
