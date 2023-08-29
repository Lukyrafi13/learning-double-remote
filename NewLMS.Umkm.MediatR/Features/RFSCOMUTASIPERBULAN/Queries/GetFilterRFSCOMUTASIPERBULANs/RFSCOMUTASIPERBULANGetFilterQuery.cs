using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSCOMUTASIPERBULANs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFSCOMUTASIPERBULANs.Queries
{
    public class RFSCOMUTASIPERBULANsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFSCOMUTASIPERBULANResponseDto>>>
    {
    }

    public class GetFilterRFSCOMUTASIPERBULANQueryHandler : IRequestHandler<RFSCOMUTASIPERBULANsGetFilterQuery, PagedResponse<IEnumerable<RFSCOMUTASIPERBULANResponseDto>>>
    {
        private IGenericRepositoryAsync<RFSCOMUTASIPERBULAN> _RFSCOMUTASIPERBULAN;
        private readonly IMapper _mapper;

        public GetFilterRFSCOMUTASIPERBULANQueryHandler(IGenericRepositoryAsync<RFSCOMUTASIPERBULAN> RFSCOMUTASIPERBULAN, IMapper mapper)
        {
            _RFSCOMUTASIPERBULAN = RFSCOMUTASIPERBULAN;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFSCOMUTASIPERBULANResponseDto>>> Handle(RFSCOMUTASIPERBULANsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFSCOMUTASIPERBULAN.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFSCOMUTASIPERBULANResponseDto>>(data.Results);
            IEnumerable<RFSCOMUTASIPERBULANResponseDto> dataVm;
            var listResponse = new List<RFSCOMUTASIPERBULANResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFSCOMUTASIPERBULANResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFSCOMUTASIPERBULANResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}