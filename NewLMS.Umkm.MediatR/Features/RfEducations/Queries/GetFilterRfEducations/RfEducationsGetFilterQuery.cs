using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfEducation;
using NewLMS.UMKM.Data.Dto.RfProduct;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.MediatR.Features.RfProducts.Queries.GetFilterRfProducts;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfEducations.Queries.GetFilterRfEducations
{
    public class RfEducationsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfEducationResponse>>>
    {
    }

    public class RfEducationsGetFilterQueryHandler : IRequestHandler<RfEducationsGetFilterQuery, PagedResponse<IEnumerable<RfEducationResponse>>>
    {
        private IGenericRepositoryAsync<RfEducation> _rfEducation;
        private readonly IMapper _mapper;

        public RfEducationsGetFilterQueryHandler(IGenericRepositoryAsync<RfEducation> rfEducation, IMapper mapper)
        {
            _rfEducation = rfEducation;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfEducationResponse>>> Handle(RfEducationsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfEducation.GetPagedReponseAsync(request);
            var dataVm = _mapper.Map<IEnumerable<RfEducationResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfEducationResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
