using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.Reviews;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.Reviews.Commands;
using NewLMS.Umkm.MediatR.Features.Reviews.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.Review
{
    public class ReviewController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// Review
        /// </summary>
        /// <param name="mediator"></param>
        public ReviewController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        // /// <summary>
        // /// Get Informasi Usaha Review
        // /// </summary>
        // /// <param name="Id"></param>
        // /// <returns></returns>
        // [HttpGet("informasi-usaha/get/{Id}", Name = "GetInformasiUsahaReview")]
        // [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        // public async Task<IActionResult> GetInformasiUsahaReview(Guid Id)
        // {
        //     var result = await _mediator.Send(new ReviewInformasiUsahaGetQuery{ Id = Id });
        //     return ReturnFormattedResponse(result);
        // }

        /// <summary>
        /// Get List Review
        /// </summary>
        /// <param name="getReviewList"></param>
        /// <returns></returns>
        [HttpPost("app/list/get", Name = "ReviewListGet")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> ReviewListGet([FromBody] ReviewsGetFilterQuery getReviewList)
        {
            var result = await _mediator.Send(getReviewList);
            return Ok(result);
        }

        /// <summary>
        /// Proses Review
        /// </summary>
        /// <param name="prosesReview"></param>
        /// <returns></returns>
        [HttpPost("proses", Name = "ProsesReview")]
        [Produces("application/json", "application/xml", Type = typeof(ReviewProsesResponse))]
        public async Task<IActionResult> ProsesReview(ReviewProsesCommand prosesReview)
        {
            var result = await _mediator.Send(prosesReview);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Kembali ke Analisa
        /// </summary>
        /// <param name="KembaliKeAO"></param>
        /// <returns></returns>
        [HttpPost("kembali/ao", Name = "KembaliKeAO")]
        [Produces("application/json", "application/xml", Type = typeof(ReviewProsesResponse))]
        public async Task<IActionResult> KembaliKeAO(ReviewKembaliKeAOCommand KembaliKeAO)
        {
            var result = await _mediator.Send(KembaliKeAO);
            return ReturnFormattedResponse(result);
        }

        // /// <summary>
        // /// Put Update InformasiUsaha Review
        // /// </summary>
        // /// <param name="Id"></param>
        // /// <param name="putInformasiUsaha"></param>
        // /// <returns></returns>
        // [HttpPut("informasi-usaha/put/{Id}", Name = "PutInformasiUsahaReview")]
        // [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<ReviewTableResponse>>))]
        // public async Task<IActionResult> PutInformasiUsahaReview([FromRoute] Guid Id, [FromBody] ReviewInformasiUsahaPutCommand putInformasiUsaha)
        // {
        //     putInformasiUsaha.Id = Id;
        //     var result = await _mediator.Send(putInformasiUsaha);
        //     return Ok(result);
        // }
        
    }
}