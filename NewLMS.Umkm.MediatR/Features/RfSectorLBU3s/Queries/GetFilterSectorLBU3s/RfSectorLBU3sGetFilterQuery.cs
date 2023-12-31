﻿using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfSectorLBU3s;
using NewLMS.Umkm.Repository.GenericRepository;
using NewLMS.Umkm.Data.Entities;

namespace NewLMS.Umkm.MediatR.Features.RFSectorLBU3s.Queries
{
    public class RFSectorLBU3GetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfSectorLBU3Response>>>
    {
    }

    public class GetFilterRFSectorLBU3QueryHandler : IRequestHandler<RFSectorLBU3GetFilterQuery, PagedResponse<IEnumerable<RfSectorLBU3Response>>>
    {
        private IGenericRepositoryAsync<RfSectorLBU3> _rfSectorLBU3;
        private readonly IMapper _mapper;

        public GetFilterRFSectorLBU3QueryHandler(IGenericRepositoryAsync<RfSectorLBU3> rfSectorLBU3, IMapper mapper)
        {
            _rfSectorLBU3 = rfSectorLBU3;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfSectorLBU3Response>>> Handle(RFSectorLBU3GetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[] { "RfSectorLBU2", "RfSectorLBU2.RfSectorLBU1" };
            var data = await _rfSectorLBU3.GetPagedReponseAsync(request, includes);
            var dataVm = _mapper.Map<IEnumerable<RfSectorLBU3Response>>(data.Results);
            return new PagedResponse<IEnumerable<RfSectorLBU3Response>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
