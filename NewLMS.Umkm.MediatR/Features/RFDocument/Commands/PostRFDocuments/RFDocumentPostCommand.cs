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
    public class RFDocumentPostCommand : RFDocumentPostRequestDto, IRequest<ServiceResponse<RFDocumentResponseDto>>
    {

    }
    public class PostRFDocumentCommandHandler : IRequestHandler<RFDocumentPostCommand, ServiceResponse<RFDocumentResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFDocument> _RFDocument;
        private readonly IMapper _mapper;

        public PostRFDocumentCommandHandler(IGenericRepositoryAsync<RFDocument> RFDocument, IMapper mapper)
        {
            _RFDocument = RFDocument;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFDocumentResponseDto>> Handle(RFDocumentPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFDocument = _mapper.Map<RFDocument>(request);

                var returnedRFDocument = await _RFDocument.AddAsync(RFDocument, callSave: false);

                // var response = _mapper.Map<RFDocumentResponseDto>(returnedRFDocument);
                var response = _mapper.Map<RFDocumentResponseDto>(returnedRFDocument);

                await _RFDocument.SaveChangeAsync();
                return ServiceResponse<RFDocumentResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFDocumentResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}