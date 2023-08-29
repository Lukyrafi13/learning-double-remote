using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFApprTanahLokasis;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFApprTanahLokasis.Commands;
using NewLMS.UMKM.MediatR.Features.RFApprTanahLokasis.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RFApprTanahLokasi
{
    public class RFApprTanahLokasiController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFApprTanahLokasi
        /// </summary>
        /// <param name="mediator"></param>
        public RFApprTanahLokasiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFApprTanahLokasi By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetRFApprTanahLokasiById")]
        [Produces("application/json", "application/xml", Type = typeof(RFApprTanahLokasiResponseDto))]
        public async Task<IActionResult> GetRFApprTanahLokasiById(string APPR_CODE)
        {
            var getGenderQuery = new RFApprTanahLokasiGetQuery { APPR_CODE = APPR_CODE };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFApprTanahLokasi By Id
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFApprTanahLokasiList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFApprTanahLokasiResponseDto>>))]
        public async Task<IActionResult> GetRFApprTanahLokasiList(RFApprTanahLokasisGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFApprTanahLokasi
        /// </summary>
        /// <param name="postRFApprTanahLokasi"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFApprTanahLokasi")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFApprTanahLokasiResponseDto>))]
        public async Task<IActionResult> AddRFApprTanahLokasi(RFApprTanahLokasiPostCommand postRFApprTanahLokasi)
        {
            var result = await _mediator.Send(postRFApprTanahLokasi);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFApprTanahLokasiById", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit RFApprTanahLokasi
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putRFApprTanahLokasi"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditRFApprTanahLokasi")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFApprTanahLokasiResponseDto>))]
        public async Task<IActionResult> EditRFApprTanahLokasi([FromRoute] string APPR_CODE, [FromBody] RFApprTanahLokasiPutCommand putRFApprTanahLokasi)
        {
            putRFApprTanahLokasi.APPR_CODE = APPR_CODE;
            var result = await _mediator.Send(putRFApprTanahLokasi);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFApprTanahLokasi
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteRFApprTanahLokasi")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFApprTanahLokasi([FromRoute] string APPR_CODE, [FromBody] RFApprTanahLokasiDeleteCommand deleteCommand)
        {
            deleteCommand.APPR_CODE = APPR_CODE;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}