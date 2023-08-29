using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFSCOHUTANGPIHAKLAINs;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFSCOHUTANGPIHAKLAINs.Queries
{
    public class RFSCOHUTANGPIHAKLAINsGetByCodeQuery : RFSCOHUTANGPIHAKLAINFindRequestDto, IRequest<ServiceResponse<RFSCOHUTANGPIHAKLAINResponseDto>>
    {
    }

    public class GetByCodeRFSCOHUTANGPIHAKLAINQueryHandler : IRequestHandler<RFSCOHUTANGPIHAKLAINsGetByCodeQuery, ServiceResponse<RFSCOHUTANGPIHAKLAINResponseDto>>
    {
        private IGenericRepositoryAsync<RFSCOHUTANGPIHAKLAIN> _RFSCOHUTANGPIHAKLAIN;
        private readonly IMapper _mapper;

        public GetByCodeRFSCOHUTANGPIHAKLAINQueryHandler(IGenericRepositoryAsync<RFSCOHUTANGPIHAKLAIN> RFSCOHUTANGPIHAKLAIN, IMapper mapper)
        {
            _RFSCOHUTANGPIHAKLAIN = RFSCOHUTANGPIHAKLAIN;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFSCOHUTANGPIHAKLAINResponseDto>> Handle(RFSCOHUTANGPIHAKLAINsGetByCodeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFSCOHUTANGPIHAKLAIN.GetByIdAsync(request.SCO_CODE, "SCO_CODE");
                if (data == null)
                    return ServiceResponse<RFSCOHUTANGPIHAKLAINResponseDto>.Return404("Data RFSCOHUTANGPIHAKLAIN not found");
                var response = _mapper.Map<RFSCOHUTANGPIHAKLAINResponseDto>(data);
                return ServiceResponse<RFSCOHUTANGPIHAKLAINResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSCOHUTANGPIHAKLAINResponseDto>.ReturnException(ex);
            }
        }
    }
}