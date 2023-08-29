using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFPolaPengembalians;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFPolaPengembalians.Queries
{
    public class RFPolaPengembaliansGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFPolaPengembalianResponseDto>>>
    {
    }

    public class RFPolaPengembaliansGetFilterQueryHandler : IRequestHandler<RFPolaPengembaliansGetFilterQuery, PagedResponse<IEnumerable<RFPolaPengembalianResponseDto>>>
    {
        private IGenericRepositoryAsync<RFPolaPengembalian> _RFPolaPengembalian;
        private readonly IMapper _mapper;

        public RFPolaPengembaliansGetFilterQueryHandler(IGenericRepositoryAsync<RFPolaPengembalian> RFPolaPengembalian, IMapper mapper)
        {
            _RFPolaPengembalian = RFPolaPengembalian;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFPolaPengembalianResponseDto>>> Handle(RFPolaPengembaliansGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
            };

            var data = await _RFPolaPengembalian.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFPolaPengembalianResponseDto>>(data.Results);
            IEnumerable<RFPolaPengembalianResponseDto> dataVm;
            var listResponse = new List<RFPolaPengembalianResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFPolaPengembalianResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFPolaPengembalianResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}