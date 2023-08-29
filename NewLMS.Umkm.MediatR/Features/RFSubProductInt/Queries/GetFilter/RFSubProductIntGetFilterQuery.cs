using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFSubProductInts;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFSubProductInts.Queries
{
    public class RFSubProductIntsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFSubProductIntResponseDto>>>
    {
    }

    public class GetFilterRFSubProductIntQueryHandler : IRequestHandler<RFSubProductIntsGetFilterQuery, PagedResponse<IEnumerable<RFSubProductIntResponseDto>>>
    {
        private IGenericRepositoryAsync<RFSubProductInt> _RFSubProductInt;
        private readonly IMapper _mapper;

        public GetFilterRFSubProductIntQueryHandler(IGenericRepositoryAsync<RFSubProductInt> RFSubProductInt, IMapper mapper)
        {
            _RFSubProductInt = RFSubProductInt;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFSubProductIntResponseDto>>> Handle(RFSubProductIntsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFSubProductInt.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFSubProductIntResponseDto>>(data.Results);
            IEnumerable<RFSubProductIntResponseDto> dataVm;
            var listResponse = new List<RFSubProductIntResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFSubProductIntResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFSubProductIntResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}