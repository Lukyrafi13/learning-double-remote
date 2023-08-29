using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RFSCOPENGELOLAKEUANGANs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFSCOPENGELOLAKEUANGANs.Commands;
using NewLMS.Umkm.MediatR.Features.RFSCOPENGELOLAKEUANGANs.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.RFSCOPENGELOLAKEUANGAN
{
    public class RFSCOPENGELOLAKEUANGANController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFSCOPENGELOLAKEUANGAN
        /// </summary>
        /// <param name="mediator"></param>
        public RFSCOPENGELOLAKEUANGANController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFSCOPENGELOLAKEUANGAN By SCO_CODE
        /// </summary>
        /// <param name="SCO_CODE"></param>
        /// <returns></returns>
        [HttpGet("get/{SCO_CODE}", Name = "GetRFSCOPENGELOLAKEUANGANByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFSCOPENGELOLAKEUANGANResponseDto))]
        public async Task<IActionResult> GetRFSCOPENGELOLAKEUANGANByCode(string SCO_CODE)
        {
            var getSCOQuery = new RFSCOPENGELOLAKEUANGANGetByCodeQuery { SCO_CODE = SCO_CODE };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFSCOPENGELOLAKEUANGAN By SCO_CODE
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFSCOPENGELOLAKEUANGANList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFSCOPENGELOLAKEUANGANResponseDto>>))]
        public async Task<IActionResult> GetRFSCOPENGELOLAKEUANGANList(RFSCOPENGELOLAKEUANGANGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFSCOPENGELOLAKEUANGAN
        /// </summary>
        /// <param name="postRFSCOPENGELOLAKEUANGAN"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFSCOPENGELOLAKEUANGAN")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFSCOPENGELOLAKEUANGANResponseDto>))]
        public async Task<IActionResult> AddRFSCOPENGELOLAKEUANGAN(RFSCOPENGELOLAKEUANGANPostCommand postRFSCOPENGELOLAKEUANGAN)
        {
            var result = await _mediator.Send(postRFSCOPENGELOLAKEUANGAN);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFSCOPENGELOLAKEUANGANByCode", new { id = result.Data.SCO_CODE }, result.Data);
        }

        /// <summary>
        /// Put Edit RFSCOPENGELOLAKEUANGAN
        /// </summary>
        /// <param name="SCO_CODE"></param>
        /// <param name="putRFSCOPENGELOLAKEUANGAN"></param>
        /// <returns></returns>
        [HttpPut("put/{SCO_CODE}", Name = "EditRFSCOPENGELOLAKEUANGAN")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFSCOPENGELOLAKEUANGANResponseDto>))]
        public async Task<IActionResult> EditRFSCOPENGELOLAKEUANGAN([FromRoute] string SCO_CODE, [FromBody] RFSCOPENGELOLAKEUANGANPutCommand putRFSCOPENGELOLAKEUANGAN)
        {
            putRFSCOPENGELOLAKEUANGAN.SCO_CODE = SCO_CODE;
            var result = await _mediator.Send(putRFSCOPENGELOLAKEUANGAN);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFSCOPENGELOLAKEUANGAN
        /// </summary>
        /// <param name="SCO_CODE"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{SCO_CODE}", Name = "DeleteRFSCOPENGELOLAKEUANGAN")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFSCOPENGELOLAKEUANGAN([FromRoute] string SCO_CODE, [FromBody]RFSCOPENGELOLAKEUANGANDeleteCommand deleteCommand)
        {
            deleteCommand.SCO_CODE = SCO_CODE;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}