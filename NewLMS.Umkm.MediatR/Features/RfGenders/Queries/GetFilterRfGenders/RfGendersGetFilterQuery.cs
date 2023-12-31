﻿using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfGenders;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RfGenders.Queries.GetFilterRfGenders
{
    public class RfGendersGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfGenderResponse>>>
    {
    }

    public class RfGendersGetFilterQueryHandler : IRequestHandler<RfGendersGetFilterQuery, PagedResponse<IEnumerable<RfGenderResponse>>>
    {
        private IGenericRepositoryAsync<RfGender> _rfGender;
        private readonly IMapper _mapper;

        public RfGendersGetFilterQueryHandler(IGenericRepositoryAsync<RfGender> rfGender, IMapper mapper)
        {
            _rfGender = rfGender;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfGenderResponse>>> Handle(RfGendersGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfGender.GetPagedReponseAsync(request);
            var dataVm = _mapper.Map<IEnumerable<RfGenderResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfGenderResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
