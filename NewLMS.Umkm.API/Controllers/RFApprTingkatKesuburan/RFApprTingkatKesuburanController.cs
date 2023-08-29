using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFApprTingkatKesuburans;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFApprTingkatKesuburans.Commands;
using NewLMS.UMKM.MediatR.Features.RFApprTingkatKesuburans.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RFApprTingkatKesuburan
{
    public class RFApprTingkatKesuburanController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFApprTingkatKesuburan
        /// </summary>
        /// <param name="mediator"></param>
        public RFApprTingkatKesuburanController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFApprTingkatKesuburan By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetRFApprTingkatKesuburanById")]
        [Produces("application/json", "application/xml", Type = typeof(RFApprTingkatKesuburanResponseDto))]
        public async Task<IActionResult> GetRFApprTingkatKesuburanById(string APPR_CODE)
        {
            var getGenderQuery = new RFApprTingkatKesuburanGetQuery { APPR_CODE = APPR_CODE };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFApprTingkatKesuburan By Id
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFApprTingkatKesuburanList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFApprTingkatKesuburanResponseDto>>))]
        public async Task<IActionResult> GetRFApprTingkatKesuburanList(RFApprTingkatKesuburansGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFApprTingkatKesuburan
        /// </summary>
        /// <param name="postRFApprTingkatKesuburan"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFApprTingkatKesuburan")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFApprTingkatKesuburanResponseDto>))]
        public async Task<IActionResult> AddRFApprTingkatKesuburan(RFApprTingkatKesuburanPostCommand postRFApprTingkatKesuburan)
        {
            var result = await _mediator.Send(postRFApprTingkatKesuburan);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFApprTingkatKesuburanById", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit RFApprTingkatKesuburan
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putRFApprTingkatKesuburan"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditRFApprTingkatKesuburan")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFApprTingkatKesuburanResponseDto>))]
        public async Task<IActionResult> EditRFApprTingkatKesuburan([FromRoute] string APPR_CODE, [FromBody] RFApprTingkatKesuburanPutCommand putRFApprTingkatKesuburan)
        {
            putRFApprTingkatKesuburan.APPR_CODE = APPR_CODE;
            var result = await _mediator.Send(putRFApprTingkatKesuburan);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFApprTingkatKesuburan
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteRFApprTingkatKesuburan")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFApprTingkatKesuburan([FromRoute] string APPR_CODE, [FromBody] RFApprTingkatKesuburanDeleteCommand deleteCommand)
        {
            deleteCommand.APPR_CODE = APPR_CODE;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}