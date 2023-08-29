using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RFMARITALs;
using NewLMS.Umkm.Repository.GenericRepository;
using AutoMapper;
using NewLMS.Umkm.Data;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFMARITALs.Queries
{
    public class GetByRFMARITALFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFMARITALResponseDto>>>
    {
    }

    public class GetByRFMARITALFilterQueryHandler : IRequestHandler<GetByRFMARITALFilterQuery, PagedResponse<IEnumerable<RFMARITALResponseDto>>>
    {
        private IGenericRepositoryAsync<RFMARITAL> _RFMARITAL;
        private readonly IMapper _mapper;

        public GetByRFMARITALFilterQueryHandler(IGenericRepositoryAsync<RFMARITAL> RFMARITAL, IMapper mapper)
        {
            _RFMARITAL = RFMARITAL;
            _mapper = mapper;
        }
        public async
        Task<PagedResponse<IEnumerable<RFMARITALResponseDto>>> Handle(GetByRFMARITALFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFMARITAL.GetPagedReponseAsync(request);
            
            IEnumerable<RFMARITALResponseDto> dataVm;
            var listResponse = new List<RFMARITALResponseDto>();

            foreach (var res in data.Results)
            {
                var response = _mapper.Map<RFMARITALResponseDto>(res);
                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFMARITALResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}