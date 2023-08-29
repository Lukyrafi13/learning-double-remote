using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFApprKomoditis;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFApprKomoditis.Commands;
using NewLMS.UMKM.MediatR.Features.RFApprKomoditis.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RFApprKomoditi
{
    public class RFApprKomoditiController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFApprKomoditi
        /// </summary>
        /// <param name="mediator"></param>
        public RFApprKomoditiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFApprKomoditi By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetRFApprKomoditiById")]
        [Produces("application/json", "application/xml", Type = typeof(RFApprKomoditiResponseDto))]
        public async Task<IActionResult> GetRFApprKomoditiById(string APPR_CODE)
        {
            var getGenderQuery = new RFApprKomoditiGetQuery { APPR_CODE = APPR_CODE };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFApprKomoditi By Id
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFApprKomoditiList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFApprKomoditiResponseDto>>))]
        public async Task<IActionResult> GetRFApprKomoditiList(RFApprKomoditisGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFApprKomoditi
        /// </summary>
        /// <param name="postRFApprKomoditi"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFApprKomoditi")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFApprKomoditiResponseDto>))]
        public async Task<IActionResult> AddRFApprKomoditi(RFApprKomoditiPostCommand postRFApprKomoditi)
        {
            var result = await _mediator.Send(postRFApprKomoditi);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFApprKomoditiById", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit RFApprKomoditi
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putRFApprKomoditi"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditRFApprKomoditi")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFApprKomoditiResponseDto>))]
        public async Task<IActionResult> EditRFApprKomoditi([FromRoute] string APPR_CODE, [FromBody] RFApprKomoditiPutCommand putRFApprKomoditi)
        {
            putRFApprKomoditi.APPR_CODE = APPR_CODE;
            var result = await _mediator.Send(putRFApprKomoditi);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFApprKomoditi
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteRFApprKomoditi")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFApprKomoditi([FromRoute] string APPR_CODE, [FromBody] RFApprKomoditiDeleteCommand deleteCommand)
        {
            deleteCommand.APPR_CODE = APPR_CODE;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}