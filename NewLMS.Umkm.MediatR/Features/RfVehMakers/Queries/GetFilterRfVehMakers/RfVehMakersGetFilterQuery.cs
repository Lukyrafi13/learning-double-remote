using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfVehMaker;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfVehMakers.Queries.GetFilterRfVehMakers
{
    public class RfVehMakersGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfVehMakerResponse>>>
    {
    }

    public class RfVehMakersGetFilterQueryHandler : IRequestHandler<RfVehMakersGetFilterQuery, PagedResponse<IEnumerable<RfVehMakerResponse>>>
    {
        private IGenericRepositoryAsync<RfVehMaker> _rfVehMaker;
        private readonly IMapper _mapper;

        public RfVehMakersGetFilterQueryHandler(IGenericRepositoryAsync<RfVehMaker> rfVehMaker, IMapper mapper)
        {
            _rfVehMaker = rfVehMaker;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfVehMakerResponse>>> Handle(RfVehMakersGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[] {
                "RfVehType",
                "RfVehCountry",
            };
            var data = await _rfVehMaker.GetPagedReponseAsync(request, includes);
            var dataVm = _mapper.Map<IEnumerable<RfVehMakerResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfVehMakerResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
