using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFDocuments;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFDocuments.Queries
{
    public class RFDocumentsGetByCodeQuery : RFDocumentFindRequestDto, IRequest<ServiceResponse<RFDocumentResponseDto>>
    {
    }

    public class GetByCodeRFDocumentQueryHandler : IRequestHandler<RFDocumentsGetByCodeQuery, ServiceResponse<RFDocumentResponseDto>>
    {
        private IGenericRepositoryAsync<RFDocument> _RFDocument;
        private readonly IMapper _mapper;

        public GetByCodeRFDocumentQueryHandler(IGenericRepositoryAsync<RFDocument> RFDocument, IMapper mapper)
        {
            _RFDocument = RFDocument;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFDocumentResponseDto>> Handle(RFDocumentsGetByCodeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFDocument.GetByIdAsync(request.DocCode, "DocCode");
                if (data == null)
                    return ServiceResponse<RFDocumentResponseDto>.Return404("Data RFDocument not found");
                var response = _mapper.Map<RFDocumentResponseDto>(data);
                return ServiceResponse<RFDocumentResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFDocumentResponseDto>.ReturnException(ex);
            }
        }
    }
}