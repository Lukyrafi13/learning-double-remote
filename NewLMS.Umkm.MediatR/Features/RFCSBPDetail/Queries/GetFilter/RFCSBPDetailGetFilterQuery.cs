using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFCSBPDetails;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFCSBPDetails.Queries
{
    public class RFCSBPDetailsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFCSBPDetailResponseDto>>>
    {
    }

    public class GetFilterRFCSBPDetailQueryHandler : IRequestHandler<RFCSBPDetailsGetFilterQuery, PagedResponse<IEnumerable<RFCSBPDetailResponseDto>>>
    {
        private IGenericRepositoryAsync<RFCSBPDetail> _RFCSBPDetail;
        private readonly IMapper _mapper;

        public GetFilterRFCSBPDetailQueryHandler(IGenericRepositoryAsync<RFCSBPDetail> RFCSBPDetail, IMapper mapper)
        {
            _RFCSBPDetail = RFCSBPDetail;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFCSBPDetailResponseDto>>> Handle(RFCSBPDetailsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFCSBPDetail.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFCSBPDetailResponseDto>>(data.Results);
            IEnumerable<RFCSBPDetailResponseDto> dataVm;
            var listResponse = new List<RFCSBPDetailResponseDto>();

            foreach (var res in data.Results)
            {
                var response = _mapper.Map<RFCSBPDetailResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFCSBPDetailResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}