using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSCOMUTASIPERBULANs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFSCOMUTASIPERBULANs.Commands
{
    public class RFSCOMUTASIPERBULANPostCommand : RFSCOMUTASIPERBULANPostRequestDto, IRequest<ServiceResponse<RFSCOMUTASIPERBULANResponseDto>>
    {

    }
    public class PostRFSCOMUTASIPERBULANCommandHandler : IRequestHandler<RFSCOMUTASIPERBULANPostCommand, ServiceResponse<RFSCOMUTASIPERBULANResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFSCOMUTASIPERBULAN> _RFSCOMUTASIPERBULAN;
        private readonly IMapper _mapper;

        public PostRFSCOMUTASIPERBULANCommandHandler(IGenericRepositoryAsync<RFSCOMUTASIPERBULAN> RFSCOMUTASIPERBULAN, IMapper mapper)
        {
            _RFSCOMUTASIPERBULAN = RFSCOMUTASIPERBULAN;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFSCOMUTASIPERBULANResponseDto>> Handle(RFSCOMUTASIPERBULANPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFSCOMUTASIPERBULAN = _mapper.Map<RFSCOMUTASIPERBULAN>(request);

                var returnedRFSCOMUTASIPERBULAN = await _RFSCOMUTASIPERBULAN.AddAsync(RFSCOMUTASIPERBULAN, callSave: false);

                // var response = _mapper.Map<RFSCOMUTASIPERBULANResponseDto>(returnedRFSCOMUTASIPERBULAN);
                var response = _mapper.Map<RFSCOMUTASIPERBULANResponseDto>(returnedRFSCOMUTASIPERBULAN);

                await _RFSCOMUTASIPERBULAN.SaveChangeAsync();
                return ServiceResponse<RFSCOMUTASIPERBULANResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSCOMUTASIPERBULANResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}