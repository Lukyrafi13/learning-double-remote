using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSCORiwayatKreditBJBs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFSCORiwayatKreditBJBs.Queries
{
    public class RFSCORiwayatKreditBJBsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFSCORiwayatKreditBJBResponseDto>>>
    {
    }

    public class GetFilterRFSCORiwayatKreditBJBQueryHandler : IRequestHandler<RFSCORiwayatKreditBJBsGetFilterQuery, PagedResponse<IEnumerable<RFSCORiwayatKreditBJBResponseDto>>>
    {
        private IGenericRepositoryAsync<RFSCORiwayatKreditBJB> _RFSCORiwayatKreditBJB;
        private readonly IMapper _mapper;

        public GetFilterRFSCORiwayatKreditBJBQueryHandler(IGenericRepositoryAsync<RFSCORiwayatKreditBJB> RFSCORiwayatKreditBJB, IMapper mapper)
        {
            _RFSCORiwayatKreditBJB = RFSCORiwayatKreditBJB;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFSCORiwayatKreditBJBResponseDto>>> Handle(RFSCORiwayatKreditBJBsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFSCORiwayatKreditBJB.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFSCORiwayatKreditBJBResponseDto>>(data.Results);
            IEnumerable<RFSCORiwayatKreditBJBResponseDto> dataVm;
            var listResponse = new List<RFSCORiwayatKreditBJBResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFSCORiwayatKreditBJBResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFSCORiwayatKreditBJBResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}