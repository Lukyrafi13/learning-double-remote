using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFCaraPengikatans;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFCaraPengikatans.Queries
{
    public class RFCaraPengikatanGetQuery : RFCaraPengikatanFindRequestDto, IRequest<ServiceResponse<RFCaraPengikatanResponseDto>>
    {
    }

    public class RFCaraPengikatanGetQueryHandler : IRequestHandler<RFCaraPengikatanGetQuery, ServiceResponse<RFCaraPengikatanResponseDto>>
    {
        private IGenericRepositoryAsync<RFCaraPengikatan> _RFCaraPengikatan;
        private readonly IMapper _mapper;

        public RFCaraPengikatanGetQueryHandler(IGenericRepositoryAsync<RFCaraPengikatan> RFCaraPengikatan, IMapper mapper)
        {
            _RFCaraPengikatan = RFCaraPengikatan;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFCaraPengikatanResponseDto>> Handle(RFCaraPengikatanGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFCaraPengikatan.GetByIdAsync(request.PK_CODE, "PK_CODE");
                if (data == null)
                    return ServiceResponse<RFCaraPengikatanResponseDto>.Return404("Data RFCaraPengikatan not found");
                var response = _mapper.Map<RFCaraPengikatanResponseDto>(data);
                return ServiceResponse<RFCaraPengikatanResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFCaraPengikatanResponseDto>.ReturnException(ex);
            }
        }
    }
}