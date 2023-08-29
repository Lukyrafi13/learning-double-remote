using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RFApprTanahLnkPertumbuhans;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFApprTanahLnkPertumbuhans.Commands;
using NewLMS.Umkm.MediatR.Features.RFApprTanahLnkPertumbuhans.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.RFApprTanahLnkPertumbuhan
{
    public class RFApprTanahLnkPertumbuhanController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFApprTanahLnkPertumbuhan
        /// </summary>
        /// <param name="mediator"></param>
        public RFApprTanahLnkPertumbuhanController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFApprTanahLnkPertumbuhan By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetRFApprTanahLnkPertumbuhanById")]
        [Produces("application/json", "application/xml", Type = typeof(RFApprTanahLnkPertumbuhanResponseDto))]
        public async Task<IActionResult> GetRFApprTanahLnkPertumbuhanById(string APPR_CODE)
        {
            var getGenderQuery = new RFApprTanahLnkPertumbuhanGetQuery { APPR_CODE = APPR_CODE };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFApprTanahLnkPertumbuhan By Id
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFApprTanahLnkPertumbuhanList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFApprTanahLnkPertumbuhanResponseDto>>))]
        public async Task<IActionResult> GetRFApprTanahLnkPertumbuhanList(RFApprTanahLnkPertumbuhansGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFApprTanahLnkPertumbuhan
        /// </summary>
        /// <param name="postRFApprTanahLnkPertumbuhan"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFApprTanahLnkPertumbuhan")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFApprTanahLnkPertumbuhanResponseDto>))]
        public async Task<IActionResult> AddRFApprTanahLnkPertumbuhan(RFApprTanahLnkPertumbuhanPostCommand postRFApprTanahLnkPertumbuhan)
        {
            var result = await _mediator.Send(postRFApprTanahLnkPertumbuhan);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFApprTanahLnkPertumbuhanById", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit RFApprTanahLnkPertumbuhan
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putRFApprTanahLnkPertumbuhan"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditRFApprTanahLnkPertumbuhan")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFApprTanahLnkPertumbuhanResponseDto>))]
        public async Task<IActionResult> EditRFApprTanahLnkPertumbuhan([FromRoute] string APPR_CODE, [FromBody] RFApprTanahLnkPertumbuhanPutCommand putRFApprTanahLnkPertumbuhan)
        {
            putRFApprTanahLnkPertumbuhan.APPR_CODE = APPR_CODE;
            var result = await _mediator.Send(putRFApprTanahLnkPertumbuhan);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFApprTanahLnkPertumbuhan
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteRFApprTanahLnkPertumbuhan")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFApprTanahLnkPertumbuhan([FromRoute] string APPR_CODE, [FromBody] RFApprTanahLnkPertumbuhanDeleteCommand deleteCommand)
        {
            deleteCommand.APPR_CODE = APPR_CODE;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}