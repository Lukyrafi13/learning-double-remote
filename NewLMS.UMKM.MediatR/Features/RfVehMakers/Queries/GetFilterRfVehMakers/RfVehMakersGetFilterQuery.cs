using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfVehMaker;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RfVehMakers.Queries.GetFilterRfVehMakers
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
                "RfCollateralBC",
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
