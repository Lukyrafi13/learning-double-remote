﻿using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfScPosition;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RfScPositions.Queries.GetFilterRfScPositions
{
    public class RfScPositionsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfScPositionResponse>>>
    {
    }

    public class RfScPositionsGetFilterQueryHandler : IRequestHandler<RfScPositionsGetFilterQuery, PagedResponse<IEnumerable<RfScPositionResponse>>>
    {
        private IGenericRepositoryAsync<RfScPosition> _rfScPosition;
        private readonly IMapper _mapper;

        public RfScPositionsGetFilterQueryHandler(IGenericRepositoryAsync<RfScPosition> rfScPosition, IMapper mapper)
        {
            _rfScPosition = rfScPosition;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfScPositionResponse>>> Handle(RfScPositionsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[] {
                "RfDecisionLetter",
                "RfDecisionLetter.RfDecisionLeterType",
            };
            var data = await _rfScPosition.GetPagedReponseAsync(request, includes);
            var dataVm = _mapper.Map<IEnumerable<RfScPositionResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfScPositionResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
