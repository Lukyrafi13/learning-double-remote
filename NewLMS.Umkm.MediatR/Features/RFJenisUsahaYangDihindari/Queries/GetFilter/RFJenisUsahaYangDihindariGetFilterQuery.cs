using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfCompanyTypeYangDihindaris;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RfCompanyTypeYangDihindaris.Queries
{
    public class RfCompanyTypeYangDihindarisGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfCompanyTypeYangDihindariResponseDto>>>
    {
    }

    public class GetFilterRfCompanyTypeYangDihindariQueryHandler : IRequestHandler<RfCompanyTypeYangDihindarisGetFilterQuery, PagedResponse<IEnumerable<RfCompanyTypeYangDihindariResponseDto>>>
    {
        private IGenericRepositoryAsync<RfCompanyTypeYangDihindari> _RfCompanyTypeYangDihindari;
        private readonly IMapper _mapper;

        public GetFilterRfCompanyTypeYangDihindariQueryHandler(IGenericRepositoryAsync<RfCompanyTypeYangDihindari> RfCompanyTypeYangDihindari, IMapper mapper)
        {
            _RfCompanyTypeYangDihindari = RfCompanyTypeYangDihindari;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfCompanyTypeYangDihindariResponseDto>>> Handle(RfCompanyTypeYangDihindarisGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RfCompanyTypeYangDihindari.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RfCompanyTypeYangDihindariResponseDto>>(data.Results);
            IEnumerable<RfCompanyTypeYangDihindariResponseDto> dataVm;
            var listResponse = new List<RfCompanyTypeYangDihindariResponseDto>();

            foreach (var res in data.Results)
            {
                var response = _mapper.Map<RfCompanyTypeYangDihindariResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RfCompanyTypeYangDihindariResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}