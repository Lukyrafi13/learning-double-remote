using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFMappingPrescreeningDocuments;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFMappingPrescreeningDocuments.Queries
{
    public class RFMappingPrescreeningDocumentsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFMappingPrescreeningDocumentResponseDto>>>
    {
    }

    public class RFMappingPrescreeningDocumentsGetFilterQueryHandler : IRequestHandler<RFMappingPrescreeningDocumentsGetFilterQuery, PagedResponse<IEnumerable<RFMappingPrescreeningDocumentResponseDto>>>
    {
        private IGenericRepositoryAsync<RFMappingPrescreeningDocument> _RFMappingPrescreeningDocument;
        private readonly IMapper _mapper;

        public RFMappingPrescreeningDocumentsGetFilterQueryHandler(IGenericRepositoryAsync<RFMappingPrescreeningDocument> RFMappingPrescreeningDocument, IMapper mapper)
        {
            _RFMappingPrescreeningDocument = RFMappingPrescreeningDocument;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFMappingPrescreeningDocumentResponseDto>>> Handle(RFMappingPrescreeningDocumentsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
                "RFDocument"
            };

            var data = await _RFMappingPrescreeningDocument.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFMappingPrescreeningDocumentResponseDto>>(data.Results);
            IEnumerable<RFMappingPrescreeningDocumentResponseDto> dataVm;
            var listResponse = new List<RFMappingPrescreeningDocumentResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFMappingPrescreeningDocumentResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFMappingPrescreeningDocumentResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}