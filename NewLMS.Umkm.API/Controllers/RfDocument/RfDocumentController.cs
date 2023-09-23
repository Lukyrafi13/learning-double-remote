using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfDocument;
using NewLMS.Umkm.MediatR.Features.RfDocuments.Queries.GetFilterRfDocuments;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewLMS.Umkm.API.Controllers.RfDocument
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
