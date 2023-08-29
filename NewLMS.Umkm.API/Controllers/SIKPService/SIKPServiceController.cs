using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.SIKP2.Models;
using NewLMS.Umkm.SIKP.Models;
using NewLMS.Umkm.MediatR.Features.SIKP.Queries;
using NewLMS.Umkm.MediatR.Features.SIKP.Queries.Commands;

namespace NewLMS.Umkm.API.Controllers.SIKPService
{
    public class SIKPServiceController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// SIKPService
        /// </summary>
        /// <param name="mediator"></param>
        public SIKPServiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get Rate Akad
        /// </summary>
        /// <param name="SIKPRateAkad"></param>
        /// <returns></returns>
        [HttpPost("rateakad", Name = "SIKPRateAkad")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RateAkadResponseModel>))]
        public async Task<IActionResult> SIKPRateAkad(SIKPGetRateAkadQuery SIKPRateAkad)
        {
            var result = await _mediator.Send(SIKPRateAkad);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get Validasi Debitur
        /// </summary>
        /// <param name="SIKPGetValidasiDebitur"></param>
        /// <returns></returns>
        [HttpPost("validasi", Name = "SIKPGetValidasiDebitur")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<ValidasiResponseModel>))]
        public async Task<IActionResult> SIKPGetValidasiDebitur(SIKPGetValidasiQuery SIKPGetValidasiDebitur)
        {
            var result = await _mediator.Send(SIKPGetValidasiDebitur);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get Validasi Debitur
        /// </summary>
        /// <param name="SIKPGetValidasiPostDebitur"></param>
        /// <returns></returns>
        [HttpPost("validasi-post", Name = "SIKPGetValidasiPostDebitur")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<ValidasiResponseModel>))]
        public async Task<IActionResult> SIKPGetValidasiPostDebitur(SIKPGetValidasiPostCalonQuery SIKPGetValidasiPostDebitur)
        {
            var result = await _mediator.Send(SIKPGetValidasiPostDebitur);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Post Calon Debitur
        /// </summary>
        /// <param name="SIKPPostCalonDebitur"></param>
        /// <returns></returns>
        [HttpPost("post/calon", Name = "SIKPPostCalonDebitur")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<PostCalonDebiturResponseModel>))]
        public async Task<IActionResult> SIKPPostCalonDebitur(SIKPPostCalonDebiturCommand SIKPPostCalonDebitur)
        {
            var result = await _mediator.Send(SIKPPostCalonDebitur);
            return ReturnFormattedResponse(result);
        }

        
    }
}