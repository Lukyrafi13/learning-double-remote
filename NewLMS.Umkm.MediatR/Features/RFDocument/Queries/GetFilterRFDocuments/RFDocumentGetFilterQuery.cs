using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFDocuments;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFDocuments.Queries
{
    public class RFDocumentsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFDocumentResponseDto>>>
    {
    }

    public class GetFilterRFDocumentQueryHandler : IRequestHandler<RFDocumentsGetFilterQuery, PagedResponse<IEnumerable<RFDocumentResponseDto>>>
    {
        private IGenericRepositoryAsync<RFDocument> _RFDocument;
        private readonly IMapper _mapper;

        public GetFilterRFDocumentQueryHandler(IGenericRepositoryAsync<RFDocument> RFDocument, IMapper mapper)
        {
            _RFDocument = RFDocument;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFDocumentResponseDto>>> Handle(RFDocumentsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFDocument.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFDocumentResponseDto>>(data.Results);
            IEnumerable<RFDocumentResponseDto> dataVm;
            var listResponse = new List<RFDocumentResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFDocumentResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFDocumentResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}