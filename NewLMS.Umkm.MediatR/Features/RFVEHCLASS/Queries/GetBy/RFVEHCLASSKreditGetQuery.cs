using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFVEHCLASSs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFVEHCLASSs.Queries
{
    public class RFVEHCLASSGetQuery : RFVEHCLASSFindRequestDto, IRequest<ServiceResponse<RFVEHCLASSResponseDto>>
    {
    }

    public class RFVEHCLASSGetQueryHandler : IRequestHandler<RFVEHCLASSGetQuery, ServiceResponse<RFVEHCLASSResponseDto>>
    {
        private IGenericRepositoryAsync<RFVEHCLASS> _RFVEHCLASS;
        private readonly IMapper _mapper;

        public RFVEHCLASSGetQueryHandler(IGenericRepositoryAsync<RFVEHCLASS> RFVEHCLASS, IMapper mapper)
        {
            _RFVEHCLASS = RFVEHCLASS;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFVEHCLASSResponseDto>> Handle(RFVEHCLASSGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFVEHCLASS.GetByIdAsync(request.VCLS_CODE, "VCLS_CODE");
                if (data == null)
                    return ServiceResponse<RFVEHCLASSResponseDto>.Return404("Data RFVEHCLASS not found");
                var response = _mapper.Map<RFVEHCLASSResponseDto>(data);
                return ServiceResponse<RFVEHCLASSResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFVEHCLASSResponseDto>.ReturnException(ex);
            }
        }
    }
}