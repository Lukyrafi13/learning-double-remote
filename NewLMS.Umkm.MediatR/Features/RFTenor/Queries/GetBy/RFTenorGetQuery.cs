using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFTenors;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFTenors.Queries
{
    public class RFTenorGetQuery : RFTenorFindRequestDto, IRequest<ServiceResponse<RFTenorResponseDto>>
    {
    }

    public class RFTenorGetQueryHandler : IRequestHandler<RFTenorGetQuery, ServiceResponse<RFTenorResponseDto>>
    {
        private IGenericRepositoryAsync<RFTenor> _RFTenor;
        private readonly IMapper _mapper;

        public RFTenorGetQueryHandler(IGenericRepositoryAsync<RFTenor> RFTenor, IMapper mapper)
        {
            _RFTenor = RFTenor;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFTenorResponseDto>> Handle(RFTenorGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFTenor.GetByIdAsync(request.TNCode, "TNCode");
                if (data == null)
                    return ServiceResponse<RFTenorResponseDto>.Return404("Data RFTenor not found");
                var response = _mapper.Map<RFTenorResponseDto>(data);
                return ServiceResponse<RFTenorResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFTenorResponseDto>.ReturnException(ex);
            }
        }
    }
}