﻿using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfLinkAge;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfLinkAges.Queries.GetFilterRfLinkAges
{
    public class RfLinkAgesGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfLinkAgeResponse>>>
    {
    }

    public class RfLinkAgesGetFilterQueryHandler : IRequestHandler<RfLinkAgesGetFilterQuery, PagedResponse<IEnumerable<RfLinkAgeResponse>>>
    {
        private IGenericRepositoryAsync<RfLinkAge> _rfLinkAge;
        private readonly IMapper _mapper;

        public RfLinkAgesGetFilterQueryHandler(IGenericRepositoryAsync<RfLinkAge> rfLinkAge, IMapper mapper)
        {
            _rfLinkAge = rfLinkAge;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfLinkAgeResponse>>> Handle(RfLinkAgesGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfLinkAge.GetPagedReponseAsync(request);
            var dataVm = _mapper.Map<IEnumerable<RfLinkAgeResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfLinkAgeResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
