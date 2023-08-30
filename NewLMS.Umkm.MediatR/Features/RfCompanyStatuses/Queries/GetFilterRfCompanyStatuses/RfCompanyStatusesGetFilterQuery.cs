using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Data.Dto.RfCompanyStatuses;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfCompanyStatuses.Queries.GetFilterRfCompanyStatuses
{
    public class RfCompanyStatusesGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfCompanyStatusResponse>>>
    {
    }

    public class RfCompanyStatusesGetFilterQueryHandler : IRequestHandler<RfCompanyStatusesGetFilterQuery, PagedResponse<IEnumerable<RfCompanyStatusResponse>>>
    {
        private IGenericRepositoryAsync<RfCompanyStatus> _RfCompanyStatus;
        private readonly IMapper _mapper;

        public RfCompanyStatusesGetFilterQueryHandler(IGenericRepositoryAsync<RfCompanyStatus> RfCompanyStatus, IMapper mapper)
        {
            _RfCompanyStatus = RfCompanyStatus;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfCompanyStatusResponse>>> Handle(RfCompanyStatusesGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RfCompanyStatus.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RfCompanyTypeResponseDto>>(data.Results);
            IEnumerable<RfCompanyStatusResponse> dataVm;
            var listResponse = new List<RfCompanyStatusResponse>();

            foreach (var res in data.Results)
            {
                var response = _mapper.Map<RfCompanyStatusResponse>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RfCompanyStatusResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
