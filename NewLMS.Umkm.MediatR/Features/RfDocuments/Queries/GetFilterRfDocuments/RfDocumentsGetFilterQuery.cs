using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfDocument;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfDocuments.Queries.GetFilterRfDocuments
{
    public class RfDocumentsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfDocumentResponse>>>
    {
    }

    public class RfDocumentsGetFilterQueryHandler : IRequestHandler<RfDocumentsGetFilterQuery, PagedResponse<IEnumerable<RfDocumentResponse>>>
    {
        private IGenericRepositoryAsync<RfDocument> _rfDocument;
        private readonly IMapper _mapper;

        public RfDocumentsGetFilterQueryHandler(IGenericRepositoryAsync<RfDocument> rfDocument, IMapper mapper)
        {
            _rfDocument = rfDocument;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfDocumentResponse>>> Handle(RfDocumentsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfDocument.GetPagedReponseAsync(request);
            var dataVm = _mapper.Map<IEnumerable<RfDocumentResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfDocumentResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
