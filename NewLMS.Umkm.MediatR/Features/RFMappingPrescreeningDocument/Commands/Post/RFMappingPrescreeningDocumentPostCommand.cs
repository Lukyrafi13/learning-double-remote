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
    public class RFMappingPrescreeningDocumentPostCommand : RFMappingPrescreeningDocumentPostRequestDto, IRequest<ServiceResponse<RFMappingPrescreeningDocumentResponseDto>>
    {

    }
    public class RFMappingPrescreeningDocumentPostCommandHandler : IRequestHandler<RFMappingPrescreeningDocumentPostCommand, ServiceResponse<RFMappingPrescreeningDocumentResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFMappingPrescreeningDocument> _RFMappingPrescreeningDocument;
        private readonly IMapper _mapper;

        public RFMappingPrescreeningDocumentPostCommandHandler(IGenericRepositoryAsync<RFMappingPrescreeningDocument> RFMappingPrescreeningDocument, IMapper mapper)
        {
            _RFMappingPrescreeningDocument = RFMappingPrescreeningDocument;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFMappingPrescreeningDocumentResponseDto>> Handle(RFMappingPrescreeningDocumentPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFMappingPrescreeningDocument = _mapper.Map<RFMappingPrescreeningDocument>(request);

                var returnedRFMappingPrescreeningDocument = await _RFMappingPrescreeningDocument.AddAsync(RFMappingPrescreeningDocument, callSave: false);

                // var response = _mapper.Map<RFMappingPrescreeningDocumentResponseDto>(returnedRFMappingPrescreeningDocument);
                var response = _mapper.Map<RFMappingPrescreeningDocumentResponseDto>(returnedRFMappingPrescreeningDocument);

                await _RFMappingPrescreeningDocument.SaveChangeAsync();
                return ServiceResponse<RFMappingPrescreeningDocumentResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFMappingPrescreeningDocumentResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}