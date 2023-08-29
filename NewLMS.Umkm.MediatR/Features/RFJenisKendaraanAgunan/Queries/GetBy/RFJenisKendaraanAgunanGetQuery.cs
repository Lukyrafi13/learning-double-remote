using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFJenisKendaraanAgunans;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFJenisKendaraanAgunans.Queries
{
    public class RFJenisKendaraanAgunanGetQuery : RFJenisKendaraanAgunanFindRequestDto, IRequest<ServiceResponse<RFJenisKendaraanAgunanResponseDto>>
    {
    }

    public class RFJenisKendaraanAgunanGetQueryHandler : IRequestHandler<RFJenisKendaraanAgunanGetQuery, ServiceResponse<RFJenisKendaraanAgunanResponseDto>>
    {
        private IGenericRepositoryAsync<RFJenisKendaraanAgunan> _RFJenisKendaraanAgunan;
        private readonly IMapper _mapper;

        public RFJenisKendaraanAgunanGetQueryHandler(IGenericRepositoryAsync<RFJenisKendaraanAgunan> RFJenisKendaraanAgunan, IMapper mapper)
        {
            _RFJenisKendaraanAgunan = RFJenisKendaraanAgunan;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFJenisKendaraanAgunanResponseDto>> Handle(RFJenisKendaraanAgunanGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFJenisKendaraanAgunan.GetByIdAsync(request.VEH_CODE, "VEH_CODE");
                if (data == null)
                    return ServiceResponse<RFJenisKendaraanAgunanResponseDto>.Return404("Data RFJenisKendaraanAgunan not found");
                var response = _mapper.Map<RFJenisKendaraanAgunanResponseDto>(data);
                return ServiceResponse<RFJenisKendaraanAgunanResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFJenisKendaraanAgunanResponseDto>.ReturnException(ex);
            }
        }
    }
}