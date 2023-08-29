using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.SurveySuppliers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.SurveySuppliers.Commands;
using NewLMS.Umkm.MediatR.Features.SurveySuppliers.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.SurveySupplier
{
    public class SurveySupplierController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// SurveySupplier
        /// </summary>
        /// <param name="mediator"></param>
        public SurveySupplierController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get SurveySupplier By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("get/{Id}", Name = "GetSurveySupplierByCode")]
        [Produces("application/json", "application/xml", Type = typeof(SurveySupplierResponseDto))]
        public async Task<IActionResult> GetSurveySupplierByCode(Guid Id)
        {
            var getSCOQuery = new SurveySupplierGetQuery { Id = Id };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get SurveySupplier
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetSurveySupplierList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<SurveySupplierResponseDto>>))]
        public async Task<IActionResult> GetSurveySupplierList(SurveySuppliersGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New SurveySupplier
        /// </summary>
        /// <param name="postSurveySupplier"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddSurveySupplier")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<SurveySupplierResponseDto>))]
        public async Task<IActionResult> AddSurveySupplier(SurveySupplierPostCommand postSurveySupplier)
        {
            var result = await _mediator.Send(postSurveySupplier);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetSurveySupplierByCode", new { id = result.Data.Id }, result.Data);
        }

        /// <summary>
        /// Put Edit SurveySupplier
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="putSurveySupplier"></param>
        /// <returns></returns>
        [HttpPut("put/{Id}", Name = "EditSurveySupplier")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<SurveySupplierResponseDto>))]
        public async Task<IActionResult> EditSurveySupplier([FromRoute] Guid Id, [FromBody] SurveySupplierPutCommand putSurveySupplier)
        {
            putSurveySupplier.Id = Id;
            var result = await _mediator.Send(putSurveySupplier);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete SurveySupplier
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{Id}", Name = "DeleteSurveySupplier")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteSurveySupplier([FromRoute] Guid Id, [FromBody]SurveySupplierDeleteCommand deleteCommand)
        {
            deleteCommand.Id = Id;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}