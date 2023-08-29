using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RFVehModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFVehModels.Commands;
using NewLMS.Umkm.MediatR.Features.RFVehModels.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.RFVehModel
{
    public class RFVehModelController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFVehModel
        /// </summary>
        /// <param name="mediator"></param>
        public RFVehModelController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFVehModel By VMDL_CODE
        /// </summary>
        /// <param name="VMDL_CODE"></param>
        /// <returns></returns>
        [HttpGet("get/{VMDL_CODE}", Name = "GetRFVehModelByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFVehModelResponseDto))]
        public async Task<IActionResult> GetRFVehModelByCode(string VMDL_CODE)
        {
            var getSCOQuery = new RFVehModelGetQuery { VMDL_CODE = VMDL_CODE };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFVehModel By VMDL_CODE
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFVehModelList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFVehModelResponseDto>>))]
        public async Task<IActionResult> GetRFVehModelList(RFVehModelsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFVehModel
        /// </summary>
        /// <param name="postRFVehModel"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFVehModel")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFVehModelResponseDto>))]
        public async Task<IActionResult> AddRFVehModel(RFVehModelPostCommand postRFVehModel)
        {
            var result = await _mediator.Send(postRFVehModel);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFVehModelByCode", new { id = result.Data.VMDL_CODE }, result.Data);
        }

        /// <summary>
        /// Put Edit RFVehModel
        /// </summary>
        /// <param name="VMDL_CODE"></param>
        /// <param name="putRFVehModel"></param>
        /// <returns></returns>
        [HttpPut("put/{VMDL_CODE}", Name = "EditRFVehModel")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFVehModelResponseDto>))]
        public async Task<IActionResult> EditRFVehModel([FromRoute] string VMDL_CODE, [FromBody] RFVehModelPutCommand putRFVehModel)
        {
            putRFVehModel.VMDL_CODE = VMDL_CODE;
            var result = await _mediator.Send(putRFVehModel);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFVehModel
        /// </summary>
        /// <param name="VMDL_CODE"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{VMDL_CODE}", Name = "DeleteRFVehModel")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFVehModel([FromRoute] string VMDL_CODE, [FromBody]RFVehModelDeleteCommand deleteCommand)
        {
            deleteCommand.VMDL_CODE = VMDL_CODE;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}