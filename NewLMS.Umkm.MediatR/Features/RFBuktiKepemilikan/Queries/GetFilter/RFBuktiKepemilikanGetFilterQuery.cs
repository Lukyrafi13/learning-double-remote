using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFBuktiKepemilikans;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFBuktiKepemilikans.Queries
{
    public class RFBuktiKepemilikansGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFBuktiKepemilikanResponseDto>>>
    {
    }

    public class GetFilterRFBuktiKepemilikanQueryHandler : IRequestHandler<RFBuktiKepemilikansGetFilterQuery, PagedResponse<IEnumerable<RFBuktiKepemilikanResponseDto>>>
    {
        private IGenericRepositoryAsync<RFBuktiKepemilikan> _RFBuktiKepemilikan;
        private readonly IMapper _mapper;

        public GetFilterRFBuktiKepemilikanQueryHandler(IGenericRepositoryAsync<RFBuktiKepemilikan> RFBuktiKepemilikan, IMapper mapper)
        {
            _RFBuktiKepemilikan = RFBuktiKepemilikan;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFBuktiKepemilikanResponseDto>>> Handle(RFBuktiKepemilikansGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFBuktiKepemilikan.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFBuktiKepemilikanResponseDto>>(data.Results);
            IEnumerable<RFBuktiKepemilikanResponseDto> dataVm;
            var listResponse = new List<RFBuktiKepemilikanResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFBuktiKepemilikanResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFBuktiKepemilikanResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}