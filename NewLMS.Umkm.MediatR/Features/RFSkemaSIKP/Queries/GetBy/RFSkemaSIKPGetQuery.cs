using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFSkemaSIKPs;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFSkemaSIKPs.Queries
{
    public class RFSkemaSIKPGetQuery : RFSkemaSIKPFindRequestDto, IRequest<ServiceResponse<RFSkemaSIKPResponseDto>>
    {
    }

    public class RFSkemaSIKPGetQueryHandler : IRequestHandler<RFSkemaSIKPGetQuery, ServiceResponse<RFSkemaSIKPResponseDto>>
    {
        private IGenericRepositoryAsync<RFSkemaSIKP> _RFSkemaSIKP;
        private readonly IMapper _mapper;

        public RFSkemaSIKPGetQueryHandler(IGenericRepositoryAsync<RFSkemaSIKP> RFSkemaSIKP, IMapper mapper)
        {
            _RFSkemaSIKP = RFSkemaSIKP;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFSkemaSIKPResponseDto>> Handle(RFSkemaSIKPGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFSkemaSIKP.GetByIdAsync(request.SkemaCode, "SkemaCode");
                if (data == null)
                    return ServiceResponse<RFSkemaSIKPResponseDto>.Return404("Data RFSkemaSIKP not found");
                var response = _mapper.Map<RFSkemaSIKPResponseDto>(data);
                return ServiceResponse<RFSkemaSIKPResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFSkemaSIKPResponseDto>.ReturnException(ex);
            }
        }
    }
}