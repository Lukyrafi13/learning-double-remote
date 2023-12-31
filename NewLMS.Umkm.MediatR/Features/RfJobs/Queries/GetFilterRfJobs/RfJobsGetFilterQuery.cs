﻿using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfJob;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RfJobs.Queries.GetFilterRfJobs
{
    public class RfJobsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfJobResponse>>>
    {
    }

    public class RfJobsGetFilterQueryHandler : IRequestHandler<RfJobsGetFilterQuery, PagedResponse<IEnumerable<RfJobResponse>>>
    {
        private IGenericRepositoryAsync<RfJob> _rfJob;
        private readonly IMapper _mapper;

        public RfJobsGetFilterQueryHandler(IGenericRepositoryAsync<RfJob> rfJob, IMapper mapper)
        {
            _rfJob = rfJob;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfJobResponse>>> Handle(RfJobsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[] {
                "RfProduct",
            };
            var data = await _rfJob.GetPagedReponseAsync(request, includes);
            var dataVm = _mapper.Map<IEnumerable<RfJobResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfJobResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
