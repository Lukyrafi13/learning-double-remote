using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFDocumentAgunans;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFDocumentAgunans.Commands
{
    public class RFDocumentAgunanPutCommand : RFDocumentAgunanPutRequestDto, IRequest<ServiceResponse<RFDocumentAgunanResponseDto>>
    {
    }

    public class PutRFDocumentAgunanCommandHandler : IRequestHandler<RFDocumentAgunanPutCommand, ServiceResponse<RFDocumentAgunanResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFDocumentAgunan> _RFDocumentAgunan;
        private readonly IMapper _mapper;

        public PutRFDocumentAgunanCommandHandler(IGenericRepositoryAsync<RFDocumentAgunan> RFDocumentAgunan, IMapper mapper){
            _RFDocumentAgunan = RFDocumentAgunan;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFDocumentAgunanResponseDto>> Handle(RFDocumentAgunanPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFDocumentAgunan = await _RFDocumentAgunan.GetByIdAsync(request.DocCode, "DocCode");
                existingRFDocumentAgunan.DocCode = request.DocCode;
                existingRFDocumentAgunan.ColCode = request.ColCode;
                existingRFDocumentAgunan.Active = request.Active;
                
                await _RFDocumentAgunan.UpdateAsync(existingRFDocumentAgunan);

                var response = _mapper.Map<RFDocumentAgunanResponseDto>(existingRFDocumentAgunan);

                return ServiceResponse<RFDocumentAgunanResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFDocumentAgunanResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}