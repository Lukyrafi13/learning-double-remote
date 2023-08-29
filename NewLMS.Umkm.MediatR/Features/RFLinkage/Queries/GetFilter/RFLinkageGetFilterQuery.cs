using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFLinkages;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFLinkages.Queries
{
    public class RFLinkagesGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFLinkageResponseDto>>>
    {
    }

    public class RFLinkagesGetFilterQueryHandler : IRequestHandler<RFLinkagesGetFilterQuery, PagedResponse<IEnumerable<RFLinkageResponseDto>>>
    {
        private IGenericRepositoryAsync<RFLinkage> _RFLinkage;
        private readonly IMapper _mapper;

        public RFLinkagesGetFilterQueryHandler(IGenericRepositoryAsync<RFLinkage> RFLinkage, IMapper mapper)
        {
            _RFLinkage = RFLinkage;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFLinkageResponseDto>>> Handle(RFLinkagesGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
            };

            var data = await _RFLinkage.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFLinkageResponseDto>>(data.Results);
            IEnumerable<RFLinkageResponseDto> dataVm;
            var listResponse = new List<RFLinkageResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFLinkageResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFLinkageResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}