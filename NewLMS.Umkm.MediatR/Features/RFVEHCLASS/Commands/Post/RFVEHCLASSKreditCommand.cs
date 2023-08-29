using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFVEHCLASSs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFVEHCLASSs.Commands
{
    public class RFVEHCLASSPostCommand : RFVEHCLASSPostRequestDto, IRequest<ServiceResponse<RFVEHCLASSResponseDto>>
    {

    }
    public class PostRFVEHCLASSCommandHandler : IRequestHandler<RFVEHCLASSPostCommand, ServiceResponse<RFVEHCLASSResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFVEHCLASS> _RFVEHCLASS;
        private readonly IMapper _mapper;

        public PostRFVEHCLASSCommandHandler(IGenericRepositoryAsync<RFVEHCLASS> RFVEHCLASS, IMapper mapper)
        {
            _RFVEHCLASS = RFVEHCLASS;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFVEHCLASSResponseDto>> Handle(RFVEHCLASSPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFVEHCLASS = _mapper.Map<RFVEHCLASS>(request);

                var returnedRFVEHCLASS = await _RFVEHCLASS.AddAsync(RFVEHCLASS, callSave: false);

                // var response = _mapper.Map<RFVEHCLASSResponseDto>(returnedRFVEHCLASS);
                var response = _mapper.Map<RFVEHCLASSResponseDto>(returnedRFVEHCLASS);

                await _RFVEHCLASS.SaveChangeAsync();
                return ServiceResponse<RFVEHCLASSResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFVEHCLASSResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}