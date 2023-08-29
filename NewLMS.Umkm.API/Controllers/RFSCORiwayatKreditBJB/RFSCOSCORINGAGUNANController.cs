using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFSCORiwayatKreditBJBs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFSCORiwayatKreditBJBs.Commands;
using NewLMS.UMKM.MediatR.Features.RFSCORiwayatKreditBJBs.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RFSCORiwayatKreditBJB
{
    public class RFSCORiwayatKreditBJBController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFSCORiwayatKreditBJB
        /// </summary>
        /// <param name="mediator"></param>
        public RFSCORiwayatKreditBJBController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFSCORiwayatKreditBJB By SCO_CODE
        /// </summary>
        /// <param name="SCO_CODE"></param>
        /// <returns></returns>
        [HttpGet("get/{SCO_CODE}", Name = "GetRFSCORiwayatKreditBJBByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFSCORiwayatKreditBJBResponseDto))]
        public async Task<IActionResult> GetRFSCORiwayatKreditBJBByCode(string SCO_CODE)
        {
            var getSCOQuery = new RFSCORiwayatKreditBJBsGetByCodeQuery { SCO_CODE = SCO_CODE };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFSCORiwayatKreditBJB By SCO_CODE
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFSCORiwayatKreditBJBList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFSCORiwayatKreditBJBResponseDto>>))]
        public async Task<IActionResult> GetRFSCORiwayatKreditBJBList(RFSCORiwayatKreditBJBsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFSCORiwayatKreditBJB
        /// </summary>
        /// <param name="postRFSCORiwayatKreditBJB"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFSCORiwayatKreditBJB")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFSCORiwayatKreditBJBResponseDto>))]
        public async Task<IActionResult> AddRFSCORiwayatKreditBJB(RFSCORiwayatKreditBJBPostCommand postRFSCORiwayatKreditBJB)
        {
            var result = await _mediator.Send(postRFSCORiwayatKreditBJB);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFSCORiwayatKreditBJBByCode", new { id = result.Data.SCO_CODE }, result.Data);
        }

        /// <summary>
        /// Put Edit RFSCORiwayatKreditBJB
        /// </summary>
        /// <param name="SCO_CODE"></param>
        /// <param name="putRFSCORiwayatKreditBJB"></param>
        /// <returns></returns>
        [HttpPut("put/{SCO_CODE}", Name = "EditRFSCORiwayatKreditBJB")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFSCORiwayatKreditBJBResponseDto>))]
        public async Task<IActionResult> EditRFSCORiwayatKreditBJB([FromRoute] string SCO_CODE, [FromBody] RFSCORiwayatKreditBJBPutCommand putRFSCORiwayatKreditBJB)
        {
            putRFSCORiwayatKreditBJB.SCO_CODE = SCO_CODE;
            var result = await _mediator.Send(putRFSCORiwayatKreditBJB);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFSCORiwayatKreditBJB
        /// </summary>
        /// <param name="SCO_CODE"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{SCO_CODE}", Name = "DeleteRFSCORiwayatKreditBJB")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFSCORiwayatKreditBJB([FromRoute] string SCO_CODE, [FromBody]RFSCORiwayatKreditBJBDeleteCommand deleteCommand)
        {
            deleteCommand.SCO_CODE = SCO_CODE;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}