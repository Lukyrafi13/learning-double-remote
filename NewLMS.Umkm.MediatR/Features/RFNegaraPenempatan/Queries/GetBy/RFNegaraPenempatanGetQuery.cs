using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFNegaraPenempatans;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFNegaraPenempatans.Queries
{
    public class RFNegaraPenempatanGetQuery : RFPlacementCountryFindRequestDto, IRequest<ServiceResponse<RFPlacementCountryResponseDto>>
    {
    }

    public class RFNegaraPenempatanGetQueryHandler : IRequestHandler<RFNegaraPenempatanGetQuery, ServiceResponse<RFPlacementCountryResponseDto>>
    {
        private IGenericRepositoryAsync<RFPlacementCountry> _RFNegaraPenempatan;
        private readonly IMapper _mapper;

        public RFNegaraPenempatanGetQueryHandler(IGenericRepositoryAsync<RFPlacementCountry> RFNegaraPenempatan, IMapper mapper)
        {
            _RFNegaraPenempatan = RFNegaraPenempatan;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFPlacementCountryResponseDto>> Handle(RFNegaraPenempatanGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFNegaraPenempatan.GetByIdAsync(request.NegaraCode, "NegaraCode");
                if (data == null)
                    return ServiceResponse<RFPlacementCountryResponseDto>.Return404("Data RFNegaraPenempatan not found");
                var response = _mapper.Map<RFPlacementCountryResponseDto>(data);
                return ServiceResponse<RFPlacementCountryResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFPlacementCountryResponseDto>.ReturnException(ex);
            }
        }
    }
}