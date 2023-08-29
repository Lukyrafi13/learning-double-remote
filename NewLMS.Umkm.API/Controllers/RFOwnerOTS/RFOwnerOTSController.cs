using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFOwnerOTSs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFOwnerOTSs.Commands;
using NewLMS.UMKM.MediatR.Features.RFOwnerOTSs.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RFOwnerOTS
{
    public class RFOwnerOTSController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFOwnerOTS
        /// </summary>
        /// <param name="mediator"></param>
        public RFOwnerOTSController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFOwnerOTS By OWN_CODE
        /// </summary>
        /// <param name="OWN_CODE"></param>
        /// <returns></returns>
        [HttpGet("get/{OWN_CODE}", Name = "GetRFOwnerOTSBy")]
        [Produces("application/json", "application/xml", Type = typeof(RFOwnerOTSResponseDto))]
        public async Task<IActionResult> GetRFOwnerOTSBy(string OWN_CODE)
        {
            var getGenderQuery = new RFOwnerOTSGetQuery { OWN_CODE = OWN_CODE };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFOwnerOTS By Filter
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFOwnerOTSList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFOwnerOTSResponseDto>>))]
        public async Task<IActionResult> GetRFOwnerOTSList(RFOwnerOTSGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFOwnerOTS
        /// </summary>
        /// <param name="postRFOwnerOTS"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFOwnerOTS")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFOwnerOTSResponseDto>))]
        public async Task<IActionResult> AddRFOwnerOTS(RFOwnerOTSPostCommand postRFOwnerOTS)
        {
            var result = await _mediator.Send(postRFOwnerOTS);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFOwnerOTSByOWN_CODE", new { id = result.Data.OWN_CODE }, result.Data);
        }

        /// <summary>
        /// Put Edit RFOwnerOTS
        /// </summary>
        /// <param name="OWN_CODE"></param>
        /// <param name="putRFOwnerOTS"></param>
        /// <returns></returns>
        [HttpPut("put/{OWN_CODE}", Name = "EditRFOwnerOTS")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFOwnerOTSResponseDto>))]
        public async Task<IActionResult> EditRFOwnerOTS([FromRoute] string OWN_CODE, [FromBody] RFOwnerOTSPutCommand putRFOwnerOTS)
        {
            putRFOwnerOTS.OWN_CODE = OWN_CODE;
            var result = await _mediator.Send(putRFOwnerOTS);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFOwnerOTS
        /// </summary>
        /// <param name="OWN_CODE"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{OWN_CODE}", Name = "DeleteRFOwnerOTS")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFOwnerOTS([FromRoute] string OWN_CODE, [FromBody]RFOwnerOTSDeleteCommand deleteCommand)
        {
            deleteCommand.OWN_CODE = OWN_CODE;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}