using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Data.Dto.RfInstituteCodes;
using NewLMS.Umkm.Data.Dto.RfJob;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.MediatR.Features.RfJobs.Queries.GetFilterRfJobs;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RfInstituteCodes.Queries.GetFilterRfInstituteCodes
{
    public class RfInstituteCodeGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfInstituteCodeResponse>>>
    {
    }

    public class RfInstituteCodeGetFilterQueryHandler : IRequestHandler<RfInstituteCodeGetFilterQuery, PagedResponse<IEnumerable<RfInstituteCodeResponse>>>
    {
        private IGenericRepositoryAsync<RfInstituteCode> _rfInstituteCode;
        private readonly IMapper _mapper;

        public RfInstituteCodeGetFilterQueryHandler(IGenericRepositoryAsync<RfInstituteCode> rfInstituteCode, IMapper mapper)
        {
            _rfInstituteCode = rfInstituteCode;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfInstituteCodeResponse>>> Handle(RfInstituteCodeGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfInstituteCode.GetPagedReponseAsync(request);
            var dataVm = _mapper.Map<IEnumerable<RfInstituteCodeResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfInstituteCodeResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
