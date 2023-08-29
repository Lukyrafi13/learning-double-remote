using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSCOMUTASIPERBULANs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFSCOMUTASIPERBULANs.Queries
{
    public class RFSCOMUTASIPERBULANsGetByCodeQuery : RFSCOMUTASIPERBULANFindRequestDto, IRequest<ServiceResponse<RFSCOMUTASIPERBULANResponseDto>>
    {
    }

    public class GetByCodeRFSCOMUTASIPERBULANQueryHandler : IRequestHandler<RFSCOMUTASIPERBULANsGetByCodeQuery, ServiceResponse<RFSCOMUTASIPERBULANResponseDto>>
    {
        private IGenericRepositoryAsync<RFSCOMUTASIPERBULAN> _RFSCOMUTASIPERBULAN;
        private readonly IMapper _mapper;

        public GetByCodeRFSCOMUTASIPERBULANQueryHandler(IGenericRepositoryAsync<RFSCOMUTASIPERBULAN> RFSCOMUTASIPERBULAN, IMapper mapper)
        {
            _RFSCOMUTASIPERBULAN = RFSCOMUTASIPERBULAN;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFSCOMUTASIPERBULANResponseDto>> Handle(RFSCOMUTASIPERBULANsGetByCodeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFSCOMUTASIPERBULAN.GetByIdAsync(request.SCO_CODE, "SCO_CODE");
                if (data == null)
                    return ServiceResponse<RFSCOMUTASIPERBULANResponseDto>.Return404("Data RFSCOMUTASIPERBULAN not found");
                var response = _mapper.Map<RFSCOMUTASIPERBULANResponseDto>(data);
                return ServiceResponse<RFSCOMUTASIPERBULANResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSCOMUTASIPERBULANResponseDto>.ReturnException(ex);
            }
        }
    }
}