﻿using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfBusinessPlaceType;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RfBusinessTypePlaces.Queries.GetFilterRfBusinessTypePlaces
{
    public class RfBusinessPlaceTypeGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfBusinessPlaceTypeResponse>>>
    {
    }

    public class RfBusinessPlaceTypeGetFilterQueryHandler : IRequestHandler<RfBusinessPlaceTypeGetFilterQuery, PagedResponse<IEnumerable<RfBusinessPlaceTypeResponse>>>
    {
        private IGenericRepositoryAsync<RfBusinessPlaceType> _rfBusinessPlaceType;
        private readonly IMapper _mapper;

        public RfBusinessPlaceTypeGetFilterQueryHandler(IGenericRepositoryAsync<RfBusinessPlaceType> rfBusinessPlaceType, IMapper mapper)
        {
            _rfBusinessPlaceType = rfBusinessPlaceType;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfBusinessPlaceTypeResponse>>> Handle(RfBusinessPlaceTypeGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfBusinessPlaceType.GetPagedReponseAsync(request);
            var dataVm = _mapper.Map<IEnumerable<RfBusinessPlaceTypeResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfBusinessPlaceTypeResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
