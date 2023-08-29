using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFSCOSALDOREKRATAs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFSCOSALDOREKRATAs.Commands;
using NewLMS.UMKM.MediatR.Features.RFSCOSALDOREKRATAs.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RFSCOSALDOREKRATA
{
    public class RFSCOSALDOREKRATAController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFSCOSALDOREKRATA
        /// </summary>
        /// <param name="mediator"></param>
        public RFSCOSALDOREKRATAController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFSCOSALDOREKRATA By SCO_CODE
        /// </summary>
        /// <param name="SCO_CODE"></param>
        /// <returns></returns>
        [HttpGet("get/{SCO_CODE}", Name = "GetRFSCOSALDOREKRATAByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFSCOSALDOREKRATAResponseDto))]
        public async Task<IActionResult> GetRFSCOSALDOREKRATAByCode(string SCO_CODE)
        {
            var getSCOQuery = new RFSCOSALDOREKRATAsGetByCodeQuery { SCO_CODE = SCO_CODE };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFSCOSALDOREKRATA By SCO_CODE
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFSCOSALDOREKRATAList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFSCOSALDOREKRATAResponseDto>>))]
        public async Task<IActionResult> GetRFSCOSALDOREKRATAList(RFSCOSALDOREKRATAsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFSCOSALDOREKRATA
        /// </summary>
        /// <param name="postRFSCOSALDOREKRATA"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFSCOSALDOREKRATA")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFSCOSALDOREKRATAResponseDto>))]
        public async Task<IActionResult> AddRFSCOSALDOREKRATA(RFSCOSALDOREKRATAPostCommand postRFSCOSALDOREKRATA)
        {
            var result = await _mediator.Send(postRFSCOSALDOREKRATA);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFSCOSALDOREKRATAByCode", new { id = result.Data.SCO_CODE }, result.Data);
        }

        /// <summary>
        /// Put Edit RFSCOSALDOREKRATA
        /// </summary>
        /// <param name="SCO_CODE"></param>
        /// <param name="putRFSCOSALDOREKRATA"></param>
        /// <returns></returns>
        [HttpPut("put/{SCO_CODE}", Name = "EditRFSCOSALDOREKRATA")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFSCOSALDOREKRATAResponseDto>))]
        public async Task<IActionResult> EditRFSCOSALDOREKRATA([FromRoute] string SCO_CODE, [FromBody] RFSCOSALDOREKRATAPutCommand putRFSCOSALDOREKRATA)
        {
            putRFSCOSALDOREKRATA.SCO_CODE = SCO_CODE;
            var result = await _mediator.Send(putRFSCOSALDOREKRATA);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFSCOSALDOREKRATA
        /// </summary>
        /// <param name="SCO_CODE"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{SCO_CODE}", Name = "DeleteRFSCOSALDOREKRATA")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFSCOSALDOREKRATA([FromRoute] string SCO_CODE, [FromBody]RFSCOSALDOREKRATADeleteCommand deleteCommand)
        {
            deleteCommand.SCO_CODE = SCO_CODE;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}