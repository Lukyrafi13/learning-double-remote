using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RfCategories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RfCategories.Commands;
using NewLMS.UMKM.MediatR.Features.RfCategories.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RfCategory
{
    public class RfCategoryController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RfCategory
        /// </summary>
        /// <param name="mediator"></param>
        public RfCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RfCategory By CategoryCode
        /// </summary>
        /// <param name="CategoryCode"></param>
        /// <returns></returns>
        [HttpGet("get/{CategoryCode}", Name = "GetRfCategoryByCategoryCode")]
        [Produces("application/json", "application/xml", Type = typeof(RfCategoryResponseDto))]
        public async Task<IActionResult> GetRfCategoryByCategoryCode(string CategoryCode)
        {
            var getGenderQuery = new RfCategoriesGetByCategoryCodeQuery { CategoryCode = CategoryCode };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RfCategory By CategoryCode
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRfCategoryList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RfCategoryResponseDto>>))]
        public async Task<IActionResult> GetRfCategoryList(RfCategoriesGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RfCategory
        /// </summary>
        /// <param name="postRfCategory"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRfCategory")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RfCategoryResponseDto>))]
        public async Task<IActionResult> AddRfCategory(RfCategoryPostCommand postRfCategory)
        {
            var result = await _mediator.Send(postRfCategory);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRfCategoryByCategoryCode", new { id = result.Data.CategoryCode }, result.Data);
        }

        /// <summary>
        /// Put Edit RfCategory
        /// </summary>
        /// <param name="CategoryCode"></param>
        /// <param name="putRfCategory"></param>
        /// <returns></returns>
        [HttpPut("put/{CategoryCode}", Name = "EditRfCategory")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RfCategoryResponseDto>))]
        public async Task<IActionResult> EditRfCategory([FromRoute] string CategoryCode, [FromBody] RfCategoryPutCommand putRfCategory)
        {
            putRfCategory.CategoryCode = CategoryCode;
            var result = await _mediator.Send(putRfCategory);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RfCategory
        /// </summary>
        /// <param name="CategoryCode"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{CategoryCode}", Name = "DeleteRfCategory")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRfCategory([FromRoute] string CategoryCode, [FromBody]RfCategoryDeleteCommand deleteCommand)
        {
            deleteCommand.CategoryCode = CategoryCode;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}