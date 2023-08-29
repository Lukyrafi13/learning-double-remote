using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFOwnerCategories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFOwnerCategories.Commands;
using NewLMS.UMKM.MediatR.Features.RFOwnerCategories.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RfOwnerCategory
{
    public class RfOwnerCategoryController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RfOwnerCategory
        /// </summary>
        /// <param name="mediator"></param>
        public RfOwnerCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RfOwnerCategory By OwnCode
        /// </summary>
        /// <param name="OwnCode"></param>
        /// <returns></returns>
        [HttpGet("get/{OwnCode}", Name = "GetRfOwnerCategoryByOwnCode")]
        [Produces("application/json", "application/xml", Type = typeof(RfOwnerCategoryResponseDto))]
        public async Task<IActionResult> GetRfOwnerCategoryByOwnCode(string OwnCode)
        {
            var query = new RfOwnerCategoryGetByOwnCodeQuery { OwnCode = OwnCode };
            var result = await _mediator.Send(query);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RfOwnerCategory By OwnCode
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRfOwnerCategoryList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RfOwnerCategoryResponseDto>>))]
        public async Task<IActionResult> GetRfOwnerCategoryList(RFOwnerCategoriesGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RfOwnerCategory
        /// </summary>
        /// <param name="postRfOwnerCategory"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRfOwnerCategory")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RfOwnerCategoryResponseDto>))]
        public async Task<IActionResult> AddRfOwnerCategory(RfOwnerCategoryPostCommand postRfOwnerCategory)
        {
            var result = await _mediator.Send(postRfOwnerCategory);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRfOwnerCategoryByOwnCode", new { id = result.Data.OwnCode }, result.Data);
        }

        /// <summary>
        /// Put Edit RfOwnerCategory
        /// </summary>
        /// <param name="OwnCode"></param>
        /// <param name="putRfOwnerCategory"></param>
        /// <returns></returns>
        [HttpPut("put/{OwnCode}", Name = "EditRfOwnerCategory")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RfOwnerCategoryResponseDto>))]
        public async Task<IActionResult> EditRfOwnerCategory([FromRoute] string OwnCode, [FromBody] RfOwnerCategoryPutCommand putRfOwnerCategory)
        {
            putRfOwnerCategory.OwnCode = OwnCode;
            var result = await _mediator.Send(putRfOwnerCategory);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RfOwnerCategory
        /// </summary>
        /// <param name="OwnCode"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{OwnCode}", Name = "DeleteRfOwnerCategory")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRfOwnerCategory([FromRoute] string OwnCode, [FromBody]RfOwnerCategoryDeleteCommand deleteCommand)
        {
            deleteCommand.OwnCode = OwnCode;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}