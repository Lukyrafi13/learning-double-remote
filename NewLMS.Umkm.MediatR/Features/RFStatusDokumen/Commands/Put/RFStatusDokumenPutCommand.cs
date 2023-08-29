using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFStatusDokumens;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFStatusDokumens.Commands
{
    public class RFStatusDokumenPutCommand : RFStatusDokumenPutRequestDto, IRequest<ServiceResponse<RFStatusDokumenResponseDto>>
    {
    }

    public class PutRFStatusDokumenCommandHandler : IRequestHandler<RFStatusDokumenPutCommand, ServiceResponse<RFStatusDokumenResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFStatusDokumen> _RFStatusDokumen;
        private readonly IMapper _mapper;

        public PutRFStatusDokumenCommandHandler(IGenericRepositoryAsync<RFStatusDokumen> RFStatusDokumen, IMapper mapper)
        {
            _RFStatusDokumen = RFStatusDokumen;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFStatusDokumenResponseDto>> Handle(RFStatusDokumenPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFStatusDokumen = await _RFStatusDokumen.GetByIdAsync(request.StatusCode, "StatusCode");
                
                existingRFStatusDokumen.StatusDesc = request.StatusDesc;
                existingRFStatusDokumen.Active = request.Active;
                await _RFStatusDokumen.UpdateAsync(existingRFStatusDokumen);

                var response = _mapper.Map<RFStatusDokumenResponseDto>(existingRFStatusDokumen);

                return ServiceResponse<RFStatusDokumenResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFStatusDokumenResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}