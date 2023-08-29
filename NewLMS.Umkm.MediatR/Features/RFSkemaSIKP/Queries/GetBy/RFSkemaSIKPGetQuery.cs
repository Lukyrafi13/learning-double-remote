using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSkemaSIKPs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFSkemaSIKPs.Queries
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