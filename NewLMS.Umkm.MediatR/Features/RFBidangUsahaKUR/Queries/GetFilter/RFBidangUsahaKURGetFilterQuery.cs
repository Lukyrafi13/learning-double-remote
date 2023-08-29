using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFBidangUsahaKURs;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFBidangUsahaKURs.Queries
{
    public class RFBidangUsahaKURsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFBidangUsahaKURResponseDto>>>
    {
    }

    public class RFBidangUsahaKURsGetFilterQueryHandler : IRequestHandler<RFBidangUsahaKURsGetFilterQuery, PagedResponse<IEnumerable<RFBidangUsahaKURResponseDto>>>
    {
        private IGenericRepositoryAsync<RFBidangUsahaKUR> _RFBidangUsahaKUR;
        private readonly IMapper _mapper;

        public RFBidangUsahaKURsGetFilterQueryHandler(IGenericRepositoryAsync<RFBidangUsahaKUR> RFBidangUsahaKUR, IMapper mapper)
        {
            _RFBidangUsahaKUR = RFBidangUsahaKUR;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFBidangUsahaKURResponseDto>>> Handle(RFBidangUsahaKURsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
            };

            var data = await _RFBidangUsahaKUR.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFBidangUsahaKURResponseDto>>(data.Results);
            IEnumerable<RFBidangUsahaKURResponseDto> dataVm;
            var listResponse = new List<RFBidangUsahaKURResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFBidangUsahaKURResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFBidangUsahaKURResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}