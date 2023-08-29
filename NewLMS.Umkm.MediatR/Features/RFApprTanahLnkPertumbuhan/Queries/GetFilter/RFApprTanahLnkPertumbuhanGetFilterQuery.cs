using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFApprTanahLnkPertumbuhans;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFApprTanahLnkPertumbuhans.Queries
{
    public class RFApprTanahLnkPertumbuhansGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFApprTanahLnkPertumbuhanResponseDto>>>
    {
    }

    public class GetFilterRFApprTanahLnkPertumbuhanQueryHandler : IRequestHandler<RFApprTanahLnkPertumbuhansGetFilterQuery, PagedResponse<IEnumerable<RFApprTanahLnkPertumbuhanResponseDto>>>
    {
        private IGenericRepositoryAsync<RFApprTanahLnkPertumbuhan> _RFApprTanahLnkPertumbuhan;
        private readonly IMapper _mapper;

        public GetFilterRFApprTanahLnkPertumbuhanQueryHandler(IGenericRepositoryAsync<RFApprTanahLnkPertumbuhan> RFApprTanahLnkPertumbuhan, IMapper mapper)
        {
            _RFApprTanahLnkPertumbuhan = RFApprTanahLnkPertumbuhan;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFApprTanahLnkPertumbuhanResponseDto>>> Handle(RFApprTanahLnkPertumbuhansGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFApprTanahLnkPertumbuhan.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFApprTanahLnkPertumbuhanResponseDto>>(data.Results);
            IEnumerable<RFApprTanahLnkPertumbuhanResponseDto> dataVm;
            var listResponse = new List<RFApprTanahLnkPertumbuhanResponseDto>();

            foreach (var res in data.Results)
            {
                var response = _mapper.Map<RFApprTanahLnkPertumbuhanResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFApprTanahLnkPertumbuhanResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}