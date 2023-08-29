using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.AppAgunans;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.AppAgunans.Queries
{
    public class AppAgunanGetQuery : AppAgunanFindRequestDto, IRequest<ServiceResponse<AppAgunanResponseDto>>
    {
    }

    public class AppAgunanGetQueryHandler : IRequestHandler<AppAgunanGetQuery, ServiceResponse<AppAgunanResponseDto>>
    {
        private IGenericRepositoryAsync<AppAgunan> _AppAgunan;
        private readonly IMapper _mapper;

        public AppAgunanGetQueryHandler(IGenericRepositoryAsync<AppAgunan> AppAgunan, IMapper mapper)
        {
            _AppAgunan = AppAgunan;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<AppAgunanResponseDto>> Handle(AppAgunanGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                    "App",
                    "JenisJaminan",
                    "DokumenKepemilikan",
                    "Manufaktur",
                    "Type",
                    "Model",
                    "HubunganDenganDebitur",
                    "StatusPernikahan",
                    "JenisAkta",
                    "KodePos",
                    "KodePosAgunan",
                    "KodePosPasangan",
                };

                var data = await _AppAgunan.GetByIdAsync(request.Id, "Id", includes);
                if (data == null)
                    return ServiceResponse<AppAgunanResponseDto>.Return404("Data AppAgunan not found");
                var response = _mapper.Map<AppAgunanResponseDto>(data);
                return ServiceResponse<AppAgunanResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<AppAgunanResponseDto>.ReturnException(ex);
            }
        }
    }
}