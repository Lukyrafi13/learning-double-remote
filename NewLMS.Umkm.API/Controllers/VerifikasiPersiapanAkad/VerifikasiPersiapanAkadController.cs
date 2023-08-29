using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.VerifikasiPersiapanAkads;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.VerifikasiPersiapanAkads.Commands;
using NewLMS.Umkm.MediatR.Features.VerifikasiPersiapanAkads.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.VerifikasiPersiapanAkad
{
    public class VerifikasiPersiapanAkadController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// VerifikasiPersiapanAkad
        /// </summary>
        /// <param name="mediator"></param>
        public VerifikasiPersiapanAkadController(IMediator mediator)
        {
            _mediator = mediator;
        }


        /// <summary>
        /// Get List VerifikasiPersiapanAkad
        /// </summary>
        /// <param name="getVerifikasiPersiapanAkadList"></param>
        /// <returns></returns>
        [HttpPost("app/list/get", Name = "VerifikasiPersiapanAkadListGet")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> VerifikasiPersiapanAkadListGet([FromBody] VerifikasiPersiapanAkadsGetFilterQuery getVerifikasiPersiapanAkadList)
        {
            var result = await _mediator.Send(getVerifikasiPersiapanAkadList);
            return Ok(result);
        }

        /// <summary>
        /// Proses VerifikasiPersiapanAkad
        /// </summary>
        /// <param name="prosesVerifikasiPersiapanAkad"></param>
        /// <returns></returns>
        [HttpPost("proses", Name = "ProsesVerifikasiPersiapanAkad")]
        [Produces("application/json", "application/xml", Type = typeof(VerifikasiPersiapanAkadProsesResponse))]
        public async Task<IActionResult> ProsesVerifikasiPersiapanAkad(VerifikasiPersiapanAkadProsesCommand prosesVerifikasiPersiapanAkad)
        {
            var result = await _mediator.Send(prosesVerifikasiPersiapanAkad);
            return ReturnFormattedResponse(result);
        }




    }
}