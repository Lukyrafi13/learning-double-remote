using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFJenisUsahaMaps;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFJenisUsahaMaps.Queries
{
    public class RFJenisUsahaMapGetQuery : RFJenisUsahaMapFindRequestDto, IRequest<ServiceResponse<RFJenisUsahaMapResponseDto>>
    {
    }

    public class RFJenisUsahaMapGetQueryHandler : IRequestHandler<RFJenisUsahaMapGetQuery, ServiceResponse<RFJenisUsahaMapResponseDto>>
    {
        private IGenericRepositoryAsync<RFJenisUsahaMap> _RFJenisUsahaMap;
        private IGenericRepositoryAsync<RFJenisUsaha> _RFJenisUsaha;
        private readonly IMapper _mapper;

        public RFJenisUsahaMapGetQueryHandler(IGenericRepositoryAsync<RFJenisUsahaMap> RFJenisUsahaMap, IGenericRepositoryAsync<RFJenisUsaha> RFJenisUsaha, IMapper mapper)
        {
            _RFJenisUsahaMap = RFJenisUsahaMap;
            _RFJenisUsaha = RFJenisUsaha;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFJenisUsahaMapResponseDto>> Handle(RFJenisUsahaMapGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RFJenisUsahaMap.GetByIdAsync(request.Id, "Id");
                if (data == null)
                    return ServiceResponse<RFJenisUsahaMapResponseDto>.Return404("Data RFJenisUsahaMap not found");
                var response = _mapper.Map<RFJenisUsahaMapResponseDto>(data);

                var jenisUsaha = await _RFJenisUsaha.GetByIdAsync(response.ANL_CODE, "ANL_CODE");

                if (jenisUsaha != null){
                    response.ANL_DESC = jenisUsaha.ANL_DESC;
                    response.ANL_ACTIVE = jenisUsaha.ACTIVE??false;
                }

                return ServiceResponse<RFJenisUsahaMapResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFJenisUsahaMapResponseDto>.ReturnException(ex);
            }
        }
    }
}