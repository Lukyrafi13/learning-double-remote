using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfAppraisalKJPPMasters;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfAppraisalKJPPMasters.Queries
{
    public class RfAppraisalKJPPMastersGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfAppraisalKJPPMastersResponse>>>
    {
    }

    public class RfAppraisalKJPPMastersGetFilterQueryHandler : IRequestHandler<RfAppraisalKJPPMastersGetFilterQuery, PagedResponse<IEnumerable<RfAppraisalKJPPMastersResponse>>>
    {
        private IGenericRepositoryAsync<RfAppraisalKJPPMaster> _rfAppraisalKJPPMaster;
        private readonly IMapper _mapper;

        public RfAppraisalKJPPMastersGetFilterQueryHandler(IGenericRepositoryAsync<RfAppraisalKJPPMaster> rfAppraisalKJPPMaster, IMapper mapper)
        {
            _rfAppraisalKJPPMaster = rfAppraisalKJPPMaster;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfAppraisalKJPPMastersResponse>>> Handle(RfAppraisalKJPPMastersGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfAppraisalKJPPMaster.GetPagedReponseAsync(request);
            var dataVm = _mapper.Map<IEnumerable<RfAppraisalKJPPMastersResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfAppraisalKJPPMastersResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
