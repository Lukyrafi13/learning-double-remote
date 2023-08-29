using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.PersiapanAkads;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.PersiapanAkads.Commands;
using NewLMS.Umkm.MediatR.Features.PersiapanAkads.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.PersiapanAkad
{
    public class PersiapanAkadController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// PersiapanAkad
        /// </summary>
        /// <param name="mediator"></param>
        public PersiapanAkadController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        
        /// <summary>
        /// Get BiayaAsuransi PersiapanAkad
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("biaya-asuransi/get/{Id}", Name = "GetBiayaAsuransiPersiapanAkad")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> GetBiayaAsuransiPersiapanAkad(Guid Id)
        {
            var result = await _mediator.Send(new PersiapanAkadBiayaAsuransiGetQuery{ Id = Id });
            return ReturnFormattedResponse(result);
        }


        /// <summary>
        /// Get List PersiapanAkad
        /// </summary>
        /// <param name="getPersiapanAkadList"></param>
        /// <returns></returns>
        [HttpPost("app/list/get", Name = "PersiapanAkadListGet")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> PersiapanAkadListGet([FromBody] PersiapanAkadsGetFilterQuery getPersiapanAkadList)
        {
            var result = await _mediator.Send(getPersiapanAkadList);
            return Ok(result);
        }

        /// <summary>
        /// Proses PersiapanAkad
        /// </summary>
        /// <param name="prosesPersiapanAkad"></param>
        /// <returns></returns>
        [HttpPost("proses", Name = "ProsesPersiapanAkad")]
        [Produces("application/json", "application/xml", Type = typeof(PersiapanAkadProsesResponse))]
        public async Task<IActionResult> ProsesPersiapanAkad(PersiapanAkadProsesCommand prosesPersiapanAkad)
        {
            var result = await _mediator.Send(prosesPersiapanAkad);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Put Update BiayaAsuransi PersiapanAkad
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putBiayaAsuransi"></param>
        /// <returns></returns>
        [HttpPut("biaya-asuransi/put/{Id}", Name = "PutBiayaAsuransiPersiapanAkad")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<PersiapanAkadTableResponse>>))]
        public async Task<IActionResult> PutBiayaAsuransiPersiapanAkad([FromRoute] Guid Id, [FromBody] PersiapanAkadBiayaAsuransiPutCommand putBiayaAsuransi)
        {
            putBiayaAsuransi.Id = Id;
            var result = await _mediator.Send(putBiayaAsuransi);
            return Ok(result);
        }


    }
}