using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFAspekPemasarans;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFAspekPemasarans.Queries
{
    public class RFAspekPemasaransGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFAspekPemasaranResponseDto>>>
    {
    }

    public class GetFilterRFAspekPemasaranQueryHandler : IRequestHandler<RFAspekPemasaransGetFilterQuery, PagedResponse<IEnumerable<RFAspekPemasaranResponseDto>>>
    {
        private IGenericRepositoryAsync<RFAspekPemasaran> _RFAspekPemasaran;
        private readonly IMapper _mapper;

        public GetFilterRFAspekPemasaranQueryHandler(IGenericRepositoryAsync<RFAspekPemasaran> RFAspekPemasaran, IMapper mapper)
        {
            _RFAspekPemasaran = RFAspekPemasaran;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFAspekPemasaranResponseDto>>> Handle(RFAspekPemasaransGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFAspekPemasaran.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFAspekPemasaranResponseDto>>(data.Results);
            IEnumerable<RFAspekPemasaranResponseDto> dataVm;
            var listResponse = new List<RFAspekPemasaranResponseDto>();

            foreach (var res in data.Results)
            {
                var response = _mapper.Map<RFAspekPemasaranResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFAspekPemasaranResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}