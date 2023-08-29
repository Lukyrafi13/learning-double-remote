using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFDocuments;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFDocuments.Commands
{
    public class RFDocumentPutCommand : RFDocumentPutRequestDto, IRequest<ServiceResponse<RFDocumentResponseDto>>
    {
    }

    public class PutRFDocumentCommandHandler : IRequestHandler<RFDocumentPutCommand, ServiceResponse<RFDocumentResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFDocument> _RFDocument;
        private readonly IMapper _mapper;

        public PutRFDocumentCommandHandler(IGenericRepositoryAsync<RFDocument> RFDocument, IMapper mapper){
            _RFDocument = RFDocument;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFDocumentResponseDto>> Handle(RFDocumentPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFDocument = await _RFDocument.GetByIdAsync(request.DocCode, "DocCode");
                existingRFDocument.DocCode = request.DocCode;
                existingRFDocument.DocDesc = request.DocDesc;
                existingRFDocument.GroupCode = request.GroupCode;
                existingRFDocument.CoreCode = request.CoreCode;
                existingRFDocument.Active = request.Active;
                existingRFDocument.Due = request.Due;
                existingRFDocument.ManDocNo = request.ManDocNo;
                existingRFDocument.ISTBO = request.ISTBO;
                existingRFDocument.Mandatory = request.Mandatory;
                
                await _RFDocument.UpdateAsync(existingRFDocument);

                var response = _mapper.Map<RFDocumentResponseDto>(existingRFDocument);

                return ServiceResponse<RFDocumentResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFDocumentResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}