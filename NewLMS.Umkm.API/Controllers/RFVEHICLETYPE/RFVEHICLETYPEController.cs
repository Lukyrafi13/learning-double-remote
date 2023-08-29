using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RFVEHICLETYPEs;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.MediatR.Features.RFVEHICLETYPEss.Commands;
using NewLMS.Umkm.MediatR.Features.RFVEHICLETYPEss.Queries;

namespace NewLMS.Umkm.API.Controllers.RFVEHICLETYPE
{
    public class RFVEHICLETYPEController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFVEHICLETYPE
        /// </summary>
        /// <param name="mediator"></param>
        public RFVEHICLETYPEController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFVEHICLETYPE By VEH_CODE
        /// </summary>
        /// <param name="VEH_CODE"></param>
        /// <returns></returns>
        [HttpGet("get/{VEH_CODE}", Name = "GetRFVEHICLETYPEByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFVEHICLETYPEResponseDto))]
        public async Task<IActionResult> GetRFVEHICLETYPEByCode(string VEH_CODE)
        {
            var getSCOQuery = new RFVEHICLETYPEGetQuery { VEH_CODE = VEH_CODE };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFVEHICLETYPE By VCLS_CODE
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFVEHICLETYPEList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFVEHICLETYPEResponseDto>>))]
        public async Task<IActionResult> GetRFVEHICLETYPEList(RFVEHICLETYPEsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFVEHICLETYPE
        /// </summary>
        /// <param name="postRFVEHICLETYPE"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFVEHICLETYPE")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFVEHICLETYPEResponseDto>))]
        public async Task<IActionResult> AddRFVEHICLETYPE(RFVEHICLETYPEPostCommand postRFVEHICLETYPE)
        {
            var result = await _mediator.Send(postRFVEHICLETYPE);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFVEHICLETYPEByCode", new { id = result.Data.VEH_CODE }, result.Data);
        }

        /// <summary>
        /// Put Edit RFVEHICLETYPE
        /// </summary>
        /// <param name="VEH_CODE"></param>
        /// <param name="putRFVEHICLETYPE"></param>
        /// <returns></returns>
        [HttpPut("put/{VEH_CODE}", Name = "EditRFVEHICLETYPE")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFVEHICLETYPEResponseDto>))]
        public async Task<IActionResult> EditRFVEHICLETYPE([FromRoute] int VEH_CODE, [FromBody] RFVEHICLETYPEPutCommand putRFVEHICLETYPE)
        {
            putRFVEHICLETYPE.VEH_CODE = VEH_CODE;
            var result = await _mediator.Send(putRFVEHICLETYPE);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFVEHICLETYPE
        /// </summary>
        /// <param name="VEH_CODE"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{VEH_CODE}", Name = "DeleteRFVEHICLETYPE")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFVEHICLETYPE([FromRoute] string VEH_CODE, [FromBody] RFVEHICLETYPEDeleteCommand deleteCommand)
        {
            deleteCommand.VEH_CODE = VEH_CODE;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}