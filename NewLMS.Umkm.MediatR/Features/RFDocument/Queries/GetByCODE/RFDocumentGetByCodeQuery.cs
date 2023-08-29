using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFDocuments;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFDocuments.Queries
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