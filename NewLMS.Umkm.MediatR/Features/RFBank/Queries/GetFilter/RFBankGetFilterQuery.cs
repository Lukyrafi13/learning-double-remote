using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFBanks;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFBanks.Queries
{
    public class RFBanksGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFBankResponseDto>>>
    {
    }

    public class RFBanksGetFilterQueryHandler : IRequestHandler<RFBanksGetFilterQuery, PagedResponse<IEnumerable<RFBankResponseDto>>>
    {
        private IGenericRepositoryAsync<RFBank> _RFBank;
        private readonly IMapper _mapper;

        public RFBanksGetFilterQueryHandler(IGenericRepositoryAsync<RFBank> RFBank, IMapper mapper)
        {
            _RFBank = RFBank;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFBankResponseDto>>> Handle(RFBanksGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
            };

            var data = await _RFBank.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFBankResponseDto>>(data.Results);
            IEnumerable<RFBankResponseDto> dataVm;
            var listResponse = new List<RFBankResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFBankResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFBankResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}