using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RFInsRateTemplates;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFInsRateTemplates.Commands;
using NewLMS.Umkm.MediatR.Features.RFInsRateTemplates.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.RFInsRateTemplate
{
    public class RFInsRateTemplateController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFInsRateTemplate
        /// </summary>
        /// <param name="mediator"></param>
        public RFInsRateTemplateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFInsRateTemplate By TPLCode
        /// </summary>
        /// <param name="TPLCode"></param>
        /// <returns></returns>
        [HttpGet("get/{TPLCode}", Name = "GetRFInsRateTemplateByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFInsRateTemplateResponseDto))]
        public async Task<IActionResult> GetRFInsRateTemplateByCode(string TPLCode)
        {
            var getSCOQuery = new RFInsRateTemplateGetQuery { TPLCode = TPLCode };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFInsRateTemplate By TPLCode
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFInsRateTemplateList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFInsRateTemplateResponseDto>>))]
        public async Task<IActionResult> GetRFInsRateTemplateList(RFInsRateTemplatesGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFInsRateTemplate
        /// </summary>
        /// <param name="postRFInsRateTemplate"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFInsRateTemplate")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFInsRateTemplateResponseDto>))]
        public async Task<IActionResult> AddRFInsRateTemplate(RFInsRateTemplatePostCommand postRFInsRateTemplate)
        {
            var result = await _mediator.Send(postRFInsRateTemplate);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFInsRateTemplateByCode", new { TPLCode = result.Data.TPLCode }, result.Data);
        }

        /// <summary>
        /// Put Edit RFInsRateTemplate
        /// </summary>
        /// <param name="TPLCode"></param>
        /// <param name="putRFInsRateTemplate"></param>
        /// <returns></returns>
        [HttpPut("put/{TPLCode}", Name = "EditRFInsRateTemplate")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFInsRateTemplateResponseDto>))]
        public async Task<IActionResult> EditRFInsRateTemplate([FromRoute] string TPLCode, [FromBody] RFInsRateTemplatePutCommand putRFInsRateTemplate)
        {
            putRFInsRateTemplate.TPLCode = TPLCode;
            var result = await _mediator.Send(putRFInsRateTemplate);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFInsRateTemplate
        /// </summary>
        /// <param name="TPLCode"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{TPLCode}", Name = "DeleteRFInsRateTemplate")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFInsRateTemplate([FromRoute] string TPLCode, [FromBody] RFInsRateTemplateDeleteCommand deleteCommand)
        {
            deleteCommand.TPLCode = TPLCode;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}