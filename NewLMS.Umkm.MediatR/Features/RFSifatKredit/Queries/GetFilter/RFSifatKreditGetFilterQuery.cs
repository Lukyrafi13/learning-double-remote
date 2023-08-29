using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFSifatKredits;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFSifatKredits.Queries
{
    public class RFSifatKreditsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFSifatKreditResponseDto>>>
    {
    }

    public class GetFilterRFSifatKreditQueryHandler : IRequestHandler<RFSifatKreditsGetFilterQuery, PagedResponse<IEnumerable<RFSifatKreditResponseDto>>>
    {
        private IGenericRepositoryAsync<RFSifatKredit> _RFSifatKredit;
        private readonly IMapper _mapper;

        public GetFilterRFSifatKreditQueryHandler(IGenericRepositoryAsync<RFSifatKredit> RFSifatKredit, IMapper mapper)
        {
            _RFSifatKredit = RFSifatKredit;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFSifatKreditResponseDto>>> Handle(RFSifatKreditsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFSifatKredit.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFSifatKreditResponseDto>>(data.Results);
            IEnumerable<RFSifatKreditResponseDto> dataVm;
            var listResponse = new List<RFSifatKreditResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFSifatKreditResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFSifatKreditResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}