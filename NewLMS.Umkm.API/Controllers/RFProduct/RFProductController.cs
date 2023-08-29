using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.Umkm.Data.Dto.RFProducts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.MediatR.Features.RFProducts.Commands;
using NewLMS.Umkm.MediatR.Features.RFProducts.Queries;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Helper;

namespace NewLMS.Umkm.API.Controllers.RFProduct
{
    public class RFProductController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFProduct
        /// </summary>
        /// <param name="mediator"></param>
        public RFProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFProduct By ProductId
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet("get/{productId}", Name = "GetRFProductById")]
        [Produces("application/json", "application/xml", Type = typeof(RFProductResponseDto))]
        public async Task<IActionResult> GetRFProductById(string productId)
        {
            var getProductQuery = new RFProductsGetByIdQuery { ProductId = productId };
            var result = await _mediator.Send(getProductQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFProduct By ProductId
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFProductList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFProductResponseDto>>))]
        public async Task<IActionResult> GetRFProductList(RFProductsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFProduct
        /// </summary>
        /// <param name="postRFProduct"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFProduct")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFProductResponseDto>))]
        public async Task<IActionResult> AddRFProduct(RFProductPostCommand postRFProduct)
        {
            var result = await _mediator.Send(postRFProduct);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFProductById", new { id = result.Data.ProductId }, result.Data);
        }

        /// <summary>
        /// Put Edit RFProduct
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="putRFProduct"></param>
        /// <returns></returns>
        [HttpPut("put/{productId}", Name = "EditRFProduct")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFProductResponseDto>))]
        public async Task<IActionResult> EditRFProduct([FromRoute] string productId, [FromBody] RFProductPutCommand putRFProduct)
        {
            putRFProduct.ProductId = productId;
            var result = await _mediator.Send(putRFProduct);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFProduct
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{productId}", Name = "DeleteRFProduct")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFProduct([FromRoute] string productId, [FromBody]RFProductDeleteCommand deleteCommand)
        {
            deleteCommand.ProductId = productId;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}