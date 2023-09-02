using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfDocument;
using NewLMS.UMKM.Data.Dto.RfProduct;
using NewLMS.UMKM.MediatR.Features.RfDocuments.Queries.GetFilterRfDocuments;
using NewLMS.UMKM.MediatR.Features.RfProducts.Queries.GetFilterRfProducts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.UMKM.API.Controllers.RfDocument
{
    public class RfDocumentController : BaseController
    {
        /// <summary>
        /// GetFilter RfDocument
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [ProducesResponseType(type: typeof(PagedResponse<IEnumerable<RfDocumentResponse>>), statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> GetFilterRfDocument(RfDocumentsGetFilterQuery command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
