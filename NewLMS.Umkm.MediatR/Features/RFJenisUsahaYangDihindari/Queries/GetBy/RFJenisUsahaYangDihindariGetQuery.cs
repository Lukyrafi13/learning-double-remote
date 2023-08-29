using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfCompanyTypeYangDihindaris;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfCompanyTypeYangDihindaris.Queries
{
    public class RfCompanyTypeYangDihindariGetQuery : RfCompanyTypeYangDihindariFindRequestDto, IRequest<ServiceResponse<RfCompanyTypeYangDihindariResponseDto>>
    {
    }

    public class RfCompanyTypeYangDihindariGetQueryHandler : IRequestHandler<RfCompanyTypeYangDihindariGetQuery, ServiceResponse<RfCompanyTypeYangDihindariResponseDto>>
    {
        private IGenericRepositoryAsync<RfCompanyTypeYangDihindari> _RfCompanyTypeYangDihindari;
        private readonly IMapper _mapper;

        public RfCompanyTypeYangDihindariGetQueryHandler(IGenericRepositoryAsync<RfCompanyTypeYangDihindari> RfCompanyTypeYangDihindari, IMapper mapper)
        {
            _RfCompanyTypeYangDihindari = RfCompanyTypeYangDihindari;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RfCompanyTypeYangDihindariResponseDto>> Handle(RfCompanyTypeYangDihindariGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RfCompanyTypeYangDihindari.GetByIdAsync(request.StatusJenisUsaha_Code, "StatusJenisUsaha_Code");
                if (data == null)
                    return ServiceResponse<RfCompanyTypeYangDihindariResponseDto>.Return404("Data RfCompanyTypeYangDihindari not found");
                var response = _mapper.Map<RfCompanyTypeYangDihindariResponseDto>(data);
                return ServiceResponse<RfCompanyTypeYangDihindariResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RfCompanyTypeYangDihindariResponseDto>.ReturnException(ex);
            }
        }
    }
}