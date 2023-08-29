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
    public class RFStatusDokumenPostCommand : RFStatusDokumenPostRequestDto, IRequest<ServiceResponse<RFStatusDokumenResponseDto>>
    {

    }
    public class RFStatusDokumenPostCommandHandler : IRequestHandler<RFStatusDokumenPostCommand, ServiceResponse<RFStatusDokumenResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFStatusDokumen> _RFStatusDokumen;
        private readonly IMapper _mapper;

        public RFStatusDokumenPostCommandHandler(IGenericRepositoryAsync<RFStatusDokumen> RFStatusDokumen, IMapper mapper)
        {
            _RFStatusDokumen = RFStatusDokumen;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFStatusDokumenResponseDto>> Handle(RFStatusDokumenPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFStatusDokumen = _mapper.Map<RFStatusDokumen>(request);

                var returnedRFStatusDokumen = await _RFStatusDokumen.AddAsync(RFStatusDokumen, callSave: false);

                // var response = _mapper.Map<RFStatusDokumenResponseDto>(returnedRFStatusDokumen);
                var response = _mapper.Map<RFStatusDokumenResponseDto>(returnedRFStatusDokumen);

                await _RFStatusDokumen.SaveChangeAsync();
                return ServiceResponse<RFStatusDokumenResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFStatusDokumenResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}