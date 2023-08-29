using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFBentukLahans;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFBentukLahans.Queries
{
    public class RFBentukLahanGetQuery : RFBentukLahanFindRequestDto, IRequest<ServiceResponse<RFBentukLahanResponseDto>>
    {
    }

    public class RFBentukLahanGetQueryHandler : IRequestHandler<RFBentukLahanGetQuery, ServiceResponse<RFBentukLahanResponseDto>>
    {
        private IGenericRepositoryAsync<RFBentukLahan> _RFBentukLahan;
        private readonly IMapper _mapper;

        public RFBentukLahanGetQueryHandler(IGenericRepositoryAsync<RFBentukLahan> RFBentukLahan, IMapper mapper)
        {
            _RFBentukLahan = RFBentukLahan;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFBentukLahanResponseDto>> Handle(RFBentukLahanGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFBentukLahan.GetByIdAsync(request.BentukLahan_Id, "BentukLahan_Id");
                if (data == null)
                    return ServiceResponse<RFBentukLahanResponseDto>.Return404("Data RFBentukLahan not found");
                var response = _mapper.Map<RFBentukLahanResponseDto>(data);
                return ServiceResponse<RFBentukLahanResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFBentukLahanResponseDto>.ReturnException(ex);
            }
        }
    }
}