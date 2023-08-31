using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.SIKPResponseDatas;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.SIKPResponseDatas.Queries
{
    public class SIKPResponseDatasGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<SIKPResponseDataResponseDto>>>
    {
    }

    public class GetFilterSIKPResponseDataQueryHandler : IRequestHandler<SIKPResponseDatasGetFilterQuery, PagedResponse<IEnumerable<SIKPResponseDataResponseDto>>>
    {
        private IGenericRepositoryAsync<SIKPResponseData> _SIKPResponseData;
        private readonly IMapper _mapper;

        public GetFilterSIKPResponseDataQueryHandler(IGenericRepositoryAsync<SIKPResponseData> SIKPResponseData, IMapper mapper)
        {
            _SIKPResponseData = SIKPResponseData;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<SIKPResponseDataResponseDto>>> Handle(SIKPResponseDatasGetFilterQuery request, CancellationToken cancellationToken)
        {
                var includes = new string[]{
                    "App",
                    "App.BookingOffice",
                    "App.JenisProduk",
                    // "App.Prospect",
                    // "App.Prospect.SektorEkonomi",
                    // "App.Prospect.SubSektorEkonomi",
                    // "App.Prospect.SubSubSektorEkonomi",
                    "TipeDebitur",
                    "SektorEkonomi",
                    "SubSektorEkonomi",
                    "SubSubSektorEkonomi",
                    "JenisKelamin",
                    "StatusPernikahan",
                    "PendidikanTerakhir",
                    "DataPekerjaan",
                    "KodePos",
                    "KodePosUsaha",
                    "Linkage",
                    "JenisKelaminSIKP",
                    "StatusPernikahanSIKP",
                    "PendidikanTerakhirSIKP",
                    "DataPekerjaanSIKP",
                    "KodePosUsahaSIKP",
                    "LinkageSIKP",
                    "App.Prospect.ProspectStageLogs",
                    "App.Prospect.ProspectStageLogs.RFStages",
                };

            var data = await _SIKPResponseData.GetPagedReponseAsync(request, includes);
            // var dataVm = _mapper.Map<IEnumerable<SIKPResponseDataResponseDto>>(data.Results);
            IEnumerable<SIKPResponseDataResponseDto> dataVm;
            var listResponse = new List<SIKPResponseDataResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<SIKPResponseDataResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<SIKPResponseDataResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}