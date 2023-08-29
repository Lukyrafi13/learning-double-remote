using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RFOwnerCategories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFOwnerCategories.Commands;
using NewLMS.Umkm.MediatR.Features.RFOwnerCategories.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.RFOwnerCategory
{
    public class RFOwnerCategoryController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFOwnerCategory
        /// </summary>
        /// <param name="mediator"></param>
        public RFOwnerCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFOwnerCategory By OwnCode
        /// </summary>
        /// <param name="OwnCode"></param>
        /// <returns></returns>
        [HttpGet("get/{OwnCode}", Name = "GetRFOwnerCategoryByOwnCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFOwnerCategoryResponseDto))]
        public async Task<IActionResult> GetRFOwnerCategoryByOwnCode(string OwnCode)
        {
            var query = new RFOwnerCategoryGetByOwnCodeQuery { OwnCode = OwnCode };
            var result = await _mediator.Send(query);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFOwnerCategory By OwnCode
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFOwnerCategoryList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFOwnerCategoryResponseDto>>))]
        public async Task<IActionResult> GetRFOwnerCategoryList(RFOwnerCategoriesGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFOwnerCategory
        /// </summary>
        /// <param name="postRFOwnerCategory"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFOwnerCategory")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFOwnerCategoryResponseDto>))]
        public async Task<IActionResult> AddRFOwnerCategory(RFOwnerCategoryPostCommand postRFOwnerCategory)
        {
            var result = await _mediator.Send(postRFOwnerCategory);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFOwnerCategoryByOwnCode", new { id = result.Data.OwnCode }, result.Data);
        }

        /// <summary>
        /// Put Edit RFOwnerCategory
        /// </summary>
        /// <param name="OwnCode"></param>
        /// <param name="putRFOwnerCategory"></param>
        /// <returns></returns>
        [HttpPut("put/{OwnCode}", Name = "EditRFOwnerCategory")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFOwnerCategoryResponseDto>))]
        public async Task<IActionResult> EditRFOwnerCategory([FromRoute] string OwnCode, [FromBody] RFOwnerCategoryPutCommand putRFOwnerCategory)
        {
            putRFOwnerCategory.OwnCode = OwnCode;
            var result = await _mediator.Send(putRFOwnerCategory);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFOwnerCategory
        /// </summary>
        /// <param name="OwnCode"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{OwnCode}", Name = "DeleteRFOwnerCategory")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFOwnerCategory([FromRoute] string OwnCode, [FromBody]RFOwnerCategoryDeleteCommand deleteCommand)
        {
            deleteCommand.OwnCode = OwnCode;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}