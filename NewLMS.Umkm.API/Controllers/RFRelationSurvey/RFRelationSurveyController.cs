using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RFRelationSurveys;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFRelationSurveys.Commands;
using NewLMS.Umkm.MediatR.Features.RFRelationSurveys.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.RFRelationSurvey
{
    public class RFRelationSurveyController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFRelationSurvey
        /// </summary>
        /// <param name="mediator"></param>
        public RFRelationSurveyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFRelationSurvey By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetRFRelationSurveysById")]
        [Produces("application/json", "application/xml", Type = typeof(RFRelationSurveyResponseDto))]
        public async Task<IActionResult> GetRFRelationSurveysById(string RE_CODE)
        {
            var getGenderQuery = new RFRelationSurveyGetQuery { RE_CODE = RE_CODE };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFRelationSurvey
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFRelationSurveysList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFRelationSurveyResponseDto>>))]
        public async Task<IActionResult> GetRFRelationSurveysList(RFRelationSurveysGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFRelationSurvey
        /// </summary>
        /// <param name="postRFRelationSurveys"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFRelationSurveys")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFRelationSurveyResponseDto>))]
        public async Task<IActionResult> AddRFRelationSurveys(RFRelationSurveyPostCommand postRFRelationSurveys)
        {
            var result = await _mediator.Send(postRFRelationSurveys);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFRelationSurveysById", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit RFRelationSurvey
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putRFRelationSurveys"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditRFRelationSurveys")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFRelationSurveyResponseDto>))]
        public async Task<IActionResult> EditRFRelationSurveys([FromRoute] string RE_CODE, [FromBody] RFRelationSurveyPutCommand putRFRelationSurveys)
        {
            putRFRelationSurveys.RE_CODE = RE_CODE;
            var result = await _mediator.Send(putRFRelationSurveys);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFRelationSurvey
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteRFRelationSurveys")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFRelationSurveys([FromRoute] string RE_CODE, [FromBody] RFRelationSurveyDeleteCommand deleteCommand)
        {
            deleteCommand.RE_CODE = RE_CODE;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}