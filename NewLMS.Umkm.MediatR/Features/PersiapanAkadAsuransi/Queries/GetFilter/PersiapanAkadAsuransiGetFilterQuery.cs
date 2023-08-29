using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.PersiapanAkadAsuransis;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.PersiapanAkadAsuransis.Queries
{
    public class PersiapanAkadAsuransisGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<PersiapanAkadAsuransiResponseDto>>>
    {
    }

    public class GetFilterPersiapanAkadAsuransiQueryHandler : IRequestHandler<PersiapanAkadAsuransisGetFilterQuery, PagedResponse<IEnumerable<PersiapanAkadAsuransiResponseDto>>>
    {
        private IGenericRepositoryAsync<PersiapanAkadAsuransi> _PersiapanAkadAsuransi;
        private readonly IMapper _mapper;

        public GetFilterPersiapanAkadAsuransiQueryHandler(IGenericRepositoryAsync<PersiapanAkadAsuransi> PersiapanAkadAsuransi, IMapper mapper)
        {
            _PersiapanAkadAsuransi = PersiapanAkadAsuransi;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<PersiapanAkadAsuransiResponseDto>>> Handle(PersiapanAkadAsuransisGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
                    "PersiapanAkad",
                    "JenisAsuransi",
                    "ObjekPertanggunganKerugian",
                };

            var data = await _PersiapanAkadAsuransi.GetPagedReponseAsync(request, includes);
            // var dataVm = _mapper.Map<IEnumerable<PersiapanAkadAsuransiResponseDto>>(data.Results);
            IEnumerable<PersiapanAkadAsuransiResponseDto> dataVm;
            var listResponse = new List<PersiapanAkadAsuransiResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<PersiapanAkadAsuransiResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<PersiapanAkadAsuransiResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}