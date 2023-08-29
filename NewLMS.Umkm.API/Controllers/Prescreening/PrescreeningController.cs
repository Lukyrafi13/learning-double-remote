using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.Prescreenings;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.Prescreenings.Commands;
using NewLMS.Umkm.MediatR.Features.Prescreenings.Queries;
using NewLMS.Umkm.MediatR.Features.SlikRequestDuplikasis.Commands;
// using NewLMS.Umkm.MediatR.Features.SlikRequestDuplikasis.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;
using Bjb.DigitalBisnis.SLIK.Models.GetResult;
using Microsoft.AspNetCore.Http;
using Hangfire;

namespace NewLMS.Umkm.API.Controllers.Prescreening
{
    public class PrescreeningController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// Prescreening
        /// </summary>
        /// <param name="mediator"></param>
        public PrescreeningController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        /// <summary>
        /// Get RAC Prescreening
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("rac/get/{Id}", Name = "GetRACPrescreening")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> GetRACPrescreening(Guid Id)
        {
            var result = await _mediator.Send(new PrescreeningRACGetQuery{ Id = Id });
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get List Prescreening
        /// </summary>
        /// <param name="getAppList"></param>
        /// <returns></returns>
        [HttpPost("app/list/get", Name = "PrescreeningListGet")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> PrescreeningListGet([FromBody] PrescreeningsGetFilterQuery getAppList)
        {
            var result = await _mediator.Send(getAppList);
            return Ok(result);
        }

        /// <summary>
        /// Proses Prescreening
        /// </summary>
        /// <param name="prosesPrescreening"></param>
        /// <returns></returns>
        [HttpPost("proses", Name = "ProsesPrescreening")]
        [Produces("application/json", "application/xml", Type = typeof(PrescreeningProsesResponse))]
        public async Task<IActionResult> ProsesPrescreening(PrescreeningProsesCommand prosesPrescreening)
        {
            var result = await _mediator.Send(prosesPrescreening);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Reject Prescreening
        /// </summary>
        /// <param name="RejectPrescreening"></param>
        /// <returns></returns>
        [HttpPost("reject", Name = "RejectPrescreening")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<PrescreeningProsesResponse>))]
        public async Task<IActionResult> RejectPrescreening(PrescreeningRejectCommand RejectPrescreening)
        {
            var result = await _mediator.Send(RejectPrescreening);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return Ok(result);
        }

        /// <summary>
        /// Kembali ke IDE
        /// </summary>
        /// <param name="KembaliKeIDE"></param>
        /// <returns></returns>
        [HttpPost("kembali/ide", Name = "KembaliKeIDE")]
        [Produces("application/json", "application/xml", Type = typeof(PrescreeningProsesResponse))]
        public async Task<IActionResult> KembaliKeIDE(PrescreeningKembaliKeIDECommand KembaliKeIDE)
        {
            var result = await _mediator.Send(KembaliKeIDE);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Kembali ke SLIK
        /// </summary>
        /// <param name="KembaliKeSLIK"></param>
        /// <returns></returns>
        [HttpPost("kembali/slik", Name = "KembaliKeSLIK")]
        [Produces("application/json", "application/xml", Type = typeof(PrescreeningProsesResponse))]
        public async Task<IActionResult> KembaliKeSLIK(PrescreeningKembaliKeSLIKCommand KembaliKeSLIK)
        {
            var result = await _mediator.Send(KembaliKeSLIK);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Put Update RAC Prescreening
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putRac"></param>
        /// <returns></returns>
        [HttpPut("rac/put/{Id}", Name = "PutRACPrescreening")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<PrescreeningTableResponse>>))]
        public async Task<IActionResult> PutRACPrescreening([FromRoute] Guid Id, [FromBody] PrescreeningRACPutCommand putRac)
        {
            putRac.Id = Id;
            var result = await _mediator.Send(putRac);
            return Ok(result);
        }
        
    }
}