using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.SurveyBuyers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.SurveyBuyers.Commands;
using NewLMS.Umkm.MediatR.Features.SurveyBuyers.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.SurveyBuyer
{
    public class SurveyBuyerController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// SurveyBuyer
        /// </summary>
        /// <param name="mediator"></param>
        public SurveyBuyerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get SurveyBuyer By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetSurveyBuyerByCode")]
        [Produces("application/json", "application/xml", Type = typeof(SurveyBuyerResponseDto))]
        public async Task<IActionResult> GetSurveyBuyerByCode(Guid Id)
        {
            var getSCOQuery = new SurveyBuyerGetQuery { Id = Id };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get SurveyBuyer
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetSurveyBuyerList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<SurveyBuyerResponseDto>>))]
        public async Task<IActionResult> GetSurveyBuyerList(SurveyBuyersGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New SurveyBuyer
        /// </summary>
        /// <param name="postSurveyBuyer"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddSurveyBuyer")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<SurveyBuyerResponseDto>))]
        public async Task<IActionResult> AddSurveyBuyer(SurveyBuyerPostCommand postSurveyBuyer)
        {
            var result = await _mediator.Send(postSurveyBuyer);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetSurveyBuyerByCode", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit SurveyBuyer
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putSurveyBuyer"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditSurveyBuyer")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<SurveyBuyerResponseDto>))]
        public async Task<IActionResult> EditSurveyBuyer([FromRoute] Guid Id, [FromBody] SurveyBuyerPutCommand putSurveyBuyer)
        {
            putSurveyBuyer.Id = Id;
            var result = await _mediator.Send(putSurveyBuyer);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete SurveyBuyer
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteSurveyBuyer")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteSurveyBuyer([FromRoute] Guid Id, [FromBody]SurveyBuyerDeleteCommand deleteCommand)
        {
            deleteCommand.Id = Id;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}