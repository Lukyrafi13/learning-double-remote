using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFPilihanPemutuss;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFPilihanPemutuss.Queries
{
    public class RFPilihanPemutusGetQuery : RFPilihanPemutusFindRequestDto, IRequest<ServiceResponse<RFPilihanPemutusResponseDto>>
    {
    }

    public class RFPilihanPemutusGetQueryHandler : IRequestHandler<RFPilihanPemutusGetQuery, ServiceResponse<RFPilihanPemutusResponseDto>>
    {
        private IGenericRepositoryAsync<RFPilihanPemutus> _RFPilihanPemutus;
        private readonly IMapper _mapper;

        public RFPilihanPemutusGetQueryHandler(IGenericRepositoryAsync<RFPilihanPemutus> RFPilihanPemutus, IMapper mapper)
        {
            _RFPilihanPemutus = RFPilihanPemutus;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFPilihanPemutusResponseDto>> Handle(RFPilihanPemutusGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                };

                var data = await _RFPilihanPemutus.GetByIdAsync(request.PemCode, "PemCode");
                if (data == null)
                    return ServiceResponse<RFPilihanPemutusResponseDto>.Return404("Data RFPilihanPemutus not found");
                var response = _mapper.Map<RFPilihanPemutusResponseDto>(data);
                return ServiceResponse<RFPilihanPemutusResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFPilihanPemutusResponseDto>.ReturnException(ex);
            }
        }
    }
}