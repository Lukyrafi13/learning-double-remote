using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFVEHCLASSs;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFVEHCLASSs.Queries
{
    public class RFVEHCLASSsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFVEHCLASSResponseDto>>>
    {
    }

    public class GetFilterRFVEHCLASSQueryHandler : IRequestHandler<RFVEHCLASSsGetFilterQuery, PagedResponse<IEnumerable<RFVEHCLASSResponseDto>>>
    {
        private IGenericRepositoryAsync<RFVEHCLASS> _RFVEHCLASS;
        private readonly IMapper _mapper;

        public GetFilterRFVEHCLASSQueryHandler(IGenericRepositoryAsync<RFVEHCLASS> RFVEHCLASS, IMapper mapper)
        {
            _RFVEHCLASS = RFVEHCLASS;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFVEHCLASSResponseDto>>> Handle(RFVEHCLASSsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFVEHCLASS.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFVEHCLASSResponseDto>>(data.Results);
            IEnumerable<RFVEHCLASSResponseDto> dataVm;
            var listResponse = new List<RFVEHCLASSResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFVEHCLASSResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFVEHCLASSResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}