using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RfProducts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RfProducts.Commands;
using NewLMS.UMKM.MediatR.Features.RfProducts.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RfProduct
{
    public class RfProductController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RfProduct
        /// </summary>
        /// <param name="mediator"></param>
        public RfProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RfProduct By ProductId
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet("get/{productId}", Name = "GetRfProductById")]
        [Produces("application/json", "application/xml", Type = typeof(RfProductResponseDto))]
        public async Task<IActionResult> GetRfProductById(string productId)
        {
            var getProductQuery = new RfProductsGetByIdQuery { ProductId = productId };
            var result = await _mediator.Send(getProductQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RfProduct By ProductId
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRfProductList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RfProductResponseDto>>))]
        public async Task<IActionResult> GetRfProductList(RfProductsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RfProduct
        /// </summary>
        /// <param name="postRfProduct"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRfProduct")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RfProductResponseDto>))]
        public async Task<IActionResult> AddRfProduct(RfProductPostCommand postRfProduct)
        {
            var result = await _mediator.Send(postRfProduct);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRfProductById", new { id = result.Data.ProductId }, result.Data);
        }

        /// <summary>
        /// Put Edit RfProduct
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="putRfProduct"></param>
        /// <returns></returns>
        [HttpPut("put/{productId}", Name = "EditRfProduct")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RfProductResponseDto>))]
        public async Task<IActionResult> EditRfProduct([FromRoute] string productId, [FromBody] RfProductPutCommand putRfProduct)
        {
            putRfProduct.ProductId = productId;
            var result = await _mediator.Send(putRfProduct);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RfProduct
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{productId}", Name = "DeleteRfProduct")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRfProduct([FromRoute] string productId, [FromBody]RfProductDeleteCommand deleteCommand)
        {
            deleteCommand.ProductId = productId;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}