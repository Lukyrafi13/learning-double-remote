using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFSCOMUTASIPERBULANs;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFSCOMUTASIPERBULANs.Queries
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