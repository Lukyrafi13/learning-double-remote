using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.AppAgunans;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.AppAgunans.Queries
{
    public class AppAgunansGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<AppAgunanResponseDto>>>
    {
    }

    public class GetFilterAppAgunanQueryHandler : IRequestHandler<AppAgunansGetFilterQuery, PagedResponse<IEnumerable<AppAgunanResponseDto>>>
    {
        private IGenericRepositoryAsync<AppAgunan> _AppAgunan;
        private readonly IMapper _mapper;

        public GetFilterAppAgunanQueryHandler(IGenericRepositoryAsync<AppAgunan> AppAgunan, IMapper mapper)
        {
            _AppAgunan = AppAgunan;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<AppAgunanResponseDto>>> Handle(AppAgunansGetFilterQuery request, CancellationToken cancellationToken)
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

            var data = await _AppAgunan.GetPagedReponseAsync(request, includes);
            // var dataVm = _mapper.Map<IEnumerable<AppAgunanResponseDto>>(data.Results);
            IEnumerable<AppAgunanResponseDto> dataVm;
            var listResponse = new List<AppAgunanResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<AppAgunanResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<AppAgunanResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}