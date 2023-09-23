using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfMarital;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RfMaritals.Queries.GetFilterRfMaritals
{
    public class RfMaritalsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfMaritalResponse>>>
    {
    }

    public class RfMaritalsGetFilterQueryHandler : IRequestHandler<RfMaritalsGetFilterQuery, PagedResponse<IEnumerable<RfMaritalResponse>>>
    {
        private IGenericRepositoryAsync<RfMarital> _rfMarital;
        private readonly IMapper _mapper;

        public RfMaritalsGetFilterQueryHandler(IGenericRepositoryAsync<RfMarital> rfMarital, IMapper mapper)
        {
            _rfMarital = rfMarital;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfMaritalResponse>>> Handle(RfMaritalsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfMarital.GetPagedReponseAsync(request);
            var dataVm = _mapper.Map<IEnumerable<RfMaritalResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfMaritalResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
