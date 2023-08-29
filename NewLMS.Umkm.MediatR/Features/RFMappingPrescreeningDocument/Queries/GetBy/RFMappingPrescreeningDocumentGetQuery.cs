using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFMappingPrescreeningDocuments;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFMappingPrescreeningDocuments.Queries
{
    public class RFMappingPrescreeningDocumentGetQuery : RFMappingPrescreeningDocumentFindRequestDto, IRequest<ServiceResponse<RFMappingPrescreeningDocumentResponseDto>>
    {
    }

    public class RFMappingPrescreeningDocumentGetQueryHandler : IRequestHandler<RFMappingPrescreeningDocumentGetQuery, ServiceResponse<RFMappingPrescreeningDocumentResponseDto>>
    {
        private IGenericRepositoryAsync<RFMappingPrescreeningDocument> _RFMappingPrescreeningDocument;
        private readonly IMapper _mapper;

        public RFMappingPrescreeningDocumentGetQueryHandler(IGenericRepositoryAsync<RFMappingPrescreeningDocument> RFMappingPrescreeningDocument, IMapper mapper)
        {
            _RFMappingPrescreeningDocument = RFMappingPrescreeningDocument;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFMappingPrescreeningDocumentResponseDto>> Handle(RFMappingPrescreeningDocumentGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                    "RFDocument"
                };

                var data = await _RFMappingPrescreeningDocument.GetByIdAsync(request.Id, "Id");
                if (data == null)
                    return ServiceResponse<RFMappingPrescreeningDocumentResponseDto>.Return404("Data RFMappingPrescreeningDocument not found");
                var response = _mapper.Map<RFMappingPrescreeningDocumentResponseDto>(data);
                return ServiceResponse<RFMappingPrescreeningDocumentResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFMappingPrescreeningDocumentResponseDto>.ReturnException(ex);
            }
        }
    }
}