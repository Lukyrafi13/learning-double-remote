using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RfCategorys;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RfCategorys.Commands;
using NewLMS.UMKM.MediatR.Features.RfCategorys.Queries;
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
        /// Get RfCategory By KategoriCode
        /// </summary>
        /// <param name="KategoriCode"></param>
        /// <returns></returns>
        [HttpGet("get/{KategoriCode}", Name = "GetRfCategoryByKategoriCode")]
        [Produces("application/json", "application/xml", Type = typeof(RfCategoryResponseDto))]
        public async Task<IActionResult> GetRfCategoryByKategoriCode(string KategoriCode)
        {
            var getGenderQuery = new RfCategorysGetByKategoriCodeQuery { KategoriCode = KategoriCode };
            var result = await _mediator.Send(getGenderQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RfCategory By KategoriCode
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRfCategoryList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RfCategoryResponseDto>>))]
        public async Task<IActionResult> GetRfCategoryList(RfCategorysGetFilterQuery filterQuery)
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
            return CreatedAtAction("GetRfCategoryByKategoriCode", new { id = result.Data.KategoriCode }, result.Data);
        }

        /// <summary>
        /// Put Edit RfCategory
        /// </summary>
        /// <param name="KategoriCode"></param>
        /// <param name="putRfCategory"></param>
        /// <returns></returns>
        [HttpPut("put/{KategoriCode}", Name = "EditRfCategory")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RfCategoryResponseDto>))]
        public async Task<IActionResult> EditRfCategory([FromRoute] string KategoriCode, [FromBody] RfCategoryPutCommand putRfCategory)
        {
            putRfCategory.KategoriCode = KategoriCode;
            var result = await _mediator.Send(putRfCategory);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RfCategory
        /// </summary>
        /// <param name="KategoriCode"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{KategoriCode}", Name = "DeleteRfCategory")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRfCategory([FromRoute] string KategoriCode, [FromBody]RfCategoryDeleteCommand deleteCommand)
        {
            deleteCommand.KategoriCode = KategoriCode;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}