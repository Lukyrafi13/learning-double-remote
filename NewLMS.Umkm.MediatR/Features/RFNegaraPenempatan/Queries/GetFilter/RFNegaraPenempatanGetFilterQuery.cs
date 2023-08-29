using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFNegaraPenempatans;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFNegaraPenempatans.Queries
{
    public class RFNegaraPenempatansGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFNegaraPenempatanResponseDto>>>
    {
    }

    public class GetFilterRFNegaraPenempatanQueryHandler : IRequestHandler<RFNegaraPenempatansGetFilterQuery, PagedResponse<IEnumerable<RFNegaraPenempatanResponseDto>>>
    {
        private IGenericRepositoryAsync<RFNegaraPenempatan> _RFNegaraPenempatan;
        private readonly IMapper _mapper;

        public GetFilterRFNegaraPenempatanQueryHandler(IGenericRepositoryAsync<RFNegaraPenempatan> RFNegaraPenempatan, IMapper mapper)
        {
            _RFNegaraPenempatan = RFNegaraPenempatan;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFNegaraPenempatanResponseDto>>> Handle(RFNegaraPenempatansGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFNegaraPenempatan.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFNegaraPenempatanResponseDto>>(data.Results);
            IEnumerable<RFNegaraPenempatanResponseDto> dataVm;
            var listResponse = new List<RFNegaraPenempatanResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFNegaraPenempatanResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFNegaraPenempatanResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}