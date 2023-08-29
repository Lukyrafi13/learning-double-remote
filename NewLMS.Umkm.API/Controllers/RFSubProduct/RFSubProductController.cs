using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewLMS.UMKM.Data.Dto.RFSubProducts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.MediatR.Features.RFSubProducts.Commands;
using NewLMS.UMKM.MediatR.Features.RFSubProducts.Queries;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Helper;

namespace NewLMS.UMKM.API.Controllers.RFSubProduct
{
    public class RFSubProductController : BaseController
    {
        public IMediator _mediator { get; set; }

        /// <summary>
        /// RFSubProduct
        /// </summary>
        /// <param name="mediator"></param>
        public RFSubProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get RFSubProduct By SubProductId
        /// </summary>
        /// <param name="SubProductId"></param>
        /// <returns></returns>
        [HttpGet("get/{SubProductId}", Name = "GetRFSubProductByCode")]
        [Produces("application/json", "application/xml", Type = typeof(RFSubProductResponseDto))]
        public async Task<IActionResult> GetRFSubProductByCode(string SubProductId)
        {
            var getSCOQuery = new RFSubProductGetQuery { SubProductId = SubProductId };
            var result = await _mediator.Send(getSCOQuery);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Get RFSubProduct By SubProductId
        /// </summary>
        /// <param name="filterQuery"></param>
        /// <returns></returns>
        [HttpPost("get", Name = "GetRFSubProductList")]
        [Produces("application/json", "application/xml", Type = typeof(PagedResponse<IEnumerable<RFSubProductResponseDto>>))]
        public async Task<IActionResult> GetRFSubProductList(RFSubProductsGetFilterQuery filterQuery)
        {
            var result = await _mediator.Send(filterQuery);
            return Ok(result);
        }

        /// <summary>
        /// Post New RFSubProduct
        /// </summary>
        /// <param name="postRFSubProduct"></param>
        /// <returns></returns>
        [HttpPost("post", Name = "AddRFSubProduct")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFSubProductResponseDto>))]
        public async Task<IActionResult> AddRFSubProduct(RFSubProductPostCommand postRFSubProduct)
        {
            var result = await _mediator.Send(postRFSubProduct);
            if (!result.Success)
            {
                return ReturnFormattedResponse(result);
            }
            return CreatedAtAction("GetRFSubProductByCode", new { id = result.Data.SubProductId }, result.Data);
        }

        /// <summary>
        /// Put Edit RFSubProduct
        /// </summary>
        /// <param name="SubProductId"></param>
        /// <param name="putRFSubProduct"></param>
        /// <returns></returns>
        [HttpPut("put/{SubProductId}", Name = "EditRFSubProduct")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<RFSubProductResponseDto>))]
        public async Task<IActionResult> EditRFSubProduct([FromRoute] string SubProductId, [FromBody] RFSubProductPutCommand putRFSubProduct)
        {
            putRFSubProduct.SubProductId = SubProductId;
            var result = await _mediator.Send(putRFSubProduct);
            return ReturnFormattedResponse(result);
        }

        /// <summary>
        /// Delete RFSubProduct
        /// </summary>
        /// <param name="SubProductId"></param>
        /// <param name="deleteCommand"></param>
        /// <returns></returns>
        [HttpDelete("delete/{SubProductId}", Name = "DeleteRFSubProduct")]
        [Produces("application/json", "application/xml", Type = typeof(ServiceResponse<Unit>))]
        public async Task<IActionResult> DeleteRFSubProduct([FromRoute] string SubProductId, [FromBody]RFSubProductDeleteCommand deleteCommand)
        {
            deleteCommand.SubProductId = SubProductId;
            return Ok(await _mediator.Send(deleteCommand));
        }
    }
}