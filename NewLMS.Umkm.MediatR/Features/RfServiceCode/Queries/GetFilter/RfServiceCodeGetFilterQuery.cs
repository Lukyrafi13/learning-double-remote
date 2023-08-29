using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfServiceCodes;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RfServiceCodes.Queries
{
    public class RfServiceCodesGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfServiceCodeResponseDto>>>
    {
    }

    public class GetFilterRfServiceCodeQueryHandler : IRequestHandler<RfServiceCodesGetFilterQuery, PagedResponse<IEnumerable<RfServiceCodeResponseDto>>>
    {
        private IGenericRepositoryAsync<RfServiceCode> _RfServiceCode;
        private readonly IMapper _mapper;

        public GetFilterRfServiceCodeQueryHandler(IGenericRepositoryAsync<RfServiceCode> RfServiceCode, IMapper mapper)
        {
            _RfServiceCode = RfServiceCode;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfServiceCodeResponseDto>>> Handle(RfServiceCodesGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RfServiceCode.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RfServiceCodeResponseDto>>(data.Results);
            IEnumerable<RfServiceCodeResponseDto> dataVm;
            var listResponse = new List<RfServiceCodeResponseDto>();

            foreach (var result in data.Results){
                var response = _mapper.Map<RfServiceCodeResponseDto>(result);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RfServiceCodeResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}