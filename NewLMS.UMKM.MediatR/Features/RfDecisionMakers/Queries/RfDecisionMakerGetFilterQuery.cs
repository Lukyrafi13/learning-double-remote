using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfDecisionMakers;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfDecisionMakers.Queries
{
    public class RfDecisionMakerGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfDecisionMakerResponse>>>
    {
    }

    public class RfDecisionMakerGetFilterQueryHandler : IRequestHandler<RfDecisionMakerGetFilterQuery, PagedResponse<IEnumerable<RfDecisionMakerResponse>>>
    {
        private IGenericRepositoryAsync<RfDecisionMaker> _rfDecisionMaker;
        private readonly IMapper _mapper;

        public RfDecisionMakerGetFilterQueryHandler(IGenericRepositoryAsync<RfDecisionMaker> rfDecisionMaker, IMapper mapper)
        {
            _rfDecisionMaker = rfDecisionMaker;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfDecisionMakerResponse>>> Handle(RfDecisionMakerGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfDecisionMaker.GetPagedReponseAsync(request);
            var dataVm = _mapper.Map<IEnumerable<RfDecisionMakerResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfDecisionMakerResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
