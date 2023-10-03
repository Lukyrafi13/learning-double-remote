using AutoMapper;
using MediatR;
using NewLMS.Umkm.Common.GenericRespository;
using NewLMS.Umkm.Data.Dto.RfBanks;
using NewLMS.Umkm.Data.Dto.RfBranches;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RfBanks.Queries
{
    public class RfBankGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfBankResponse>>>
    {
    }

    public class RfBankGetFilterQueryHandler : IRequestHandler<RfBankGetFilterQuery, PagedResponse<IEnumerable<RfBankResponse>>>
    {
        private IGenericRepositoryAsync<RfBank> _rfBank;
        private readonly IMapper _mapper;

        public RfBankGetFilterQueryHandler(IMapper mapper, IGenericRepositoryAsync<RfBank> rfBank)
        {
            _mapper = mapper;
            _rfBank = rfBank;
        }

        public async Task<PagedResponse<IEnumerable<RfBankResponse>>> Handle(RfBankGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfBank.GetPagedReponseAsync(request);
            var dataVm = _mapper.Map<IEnumerable<RfBankResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfBankResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
