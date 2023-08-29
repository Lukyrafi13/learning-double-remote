using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFDebiturMemilikiUsahaLains;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFDebiturMemilikiUsahaLains.Queries
{
    public class RFDebiturMemilikiUsahaLainsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFDebiturMemilikiUsahaLainResponseDto>>>
    {
    }

    public class GetFilterRFDebiturMemilikiUsahaLainQueryHandler : IRequestHandler<RFDebiturMemilikiUsahaLainsGetFilterQuery, PagedResponse<IEnumerable<RFDebiturMemilikiUsahaLainResponseDto>>>
    {
        private IGenericRepositoryAsync<DebiturMemilikiUsahaLain> _RFDebiturMemilikiUsahaLain;
        private readonly IMapper _mapper;

        public GetFilterRFDebiturMemilikiUsahaLainQueryHandler(IGenericRepositoryAsync<DebiturMemilikiUsahaLain> RFDebiturMemilikiUsahaLain, IMapper mapper)
        {
            _RFDebiturMemilikiUsahaLain = RFDebiturMemilikiUsahaLain;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFDebiturMemilikiUsahaLainResponseDto>>> Handle(RFDebiturMemilikiUsahaLainsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFDebiturMemilikiUsahaLain.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFDebiturMemilikiUsahaLainResponseDto>>(data.Results);
            IEnumerable<RFDebiturMemilikiUsahaLainResponseDto> dataVm;
            var listResponse = new List<RFDebiturMemilikiUsahaLainResponseDto>();

            foreach (var res in data.Results)
            {
                var response = _mapper.Map<RFDebiturMemilikiUsahaLainResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFDebiturMemilikiUsahaLainResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}