using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFApprTanahLokasis;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFApprTanahLokasis.Queries
{
    public class RFApprTanahLokasisGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFApprTanahLokasiResponseDto>>>
    {
    }

    public class GetFilterRFApprTanahLokasiQueryHandler : IRequestHandler<RFApprTanahLokasisGetFilterQuery, PagedResponse<IEnumerable<RFApprTanahLokasiResponseDto>>>
    {
        private IGenericRepositoryAsync<RFApprTanahLokasi> _RFApprTanahLokasi;
        private readonly IMapper _mapper;

        public GetFilterRFApprTanahLokasiQueryHandler(IGenericRepositoryAsync<RFApprTanahLokasi> RFApprTanahLokasi, IMapper mapper)
        {
            _RFApprTanahLokasi = RFApprTanahLokasi;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFApprTanahLokasiResponseDto>>> Handle(RFApprTanahLokasisGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFApprTanahLokasi.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFApprTanahLokasiResponseDto>>(data.Results);
            IEnumerable<RFApprTanahLokasiResponseDto> dataVm;
            var listResponse = new List<RFApprTanahLokasiResponseDto>();

            foreach (var res in data.Results)
            {
                var response = _mapper.Map<RFApprTanahLokasiResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFApprTanahLokasiResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}