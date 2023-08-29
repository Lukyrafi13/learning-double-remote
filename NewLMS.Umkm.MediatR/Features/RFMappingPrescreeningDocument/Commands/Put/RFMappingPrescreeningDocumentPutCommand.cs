using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFMappingPrescreeningDocuments;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFMappingPrescreeningDocuments.Commands
{
    public class RFMappingPrescreeningDocumentPutCommand : RFMappingPrescreeningDocumentPutRequestDto, IRequest<ServiceResponse<RFMappingPrescreeningDocumentResponseDto>>
    {
    }

    public class RFMappingPrescreeningDocumentPutCommandHandler : IRequestHandler<RFMappingPrescreeningDocumentPutCommand, ServiceResponse<RFMappingPrescreeningDocumentResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFMappingPrescreeningDocument> _RFMappingPrescreeningDocument;
        private readonly IMapper _mapper;

        public RFMappingPrescreeningDocumentPutCommandHandler(IGenericRepositoryAsync<RFMappingPrescreeningDocument> RFMappingPrescreeningDocument, IMapper mapper)
        {
            _RFMappingPrescreeningDocument = RFMappingPrescreeningDocument;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFMappingPrescreeningDocumentResponseDto>> Handle(RFMappingPrescreeningDocumentPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFMappingPrescreeningDocument = await _RFMappingPrescreeningDocument.GetByIdAsync(request.Id, "Id");
                
                existingRFMappingPrescreeningDocument.TypeCode = request.TypeCode;
                existingRFMappingPrescreeningDocument.ProductId = request.ProductId;
                existingRFMappingPrescreeningDocument.OwnCode = request.OwnCode;
                existingRFMappingPrescreeningDocument.DocCode = request.DocCode;

                await _RFMappingPrescreeningDocument.UpdateAsync(existingRFMappingPrescreeningDocument);

                var response = _mapper.Map<RFMappingPrescreeningDocumentResponseDto>(existingRFMappingPrescreeningDocument);

                return ServiceResponse<RFMappingPrescreeningDocumentResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFMappingPrescreeningDocumentResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}