using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFTempalateAkadKredits;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFTempalateAkadKredits.Queries
{
    public class RFTempalateAkadKreditsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFTempalateAkadKreditResponseDto>>>
    {
    }

    public class GetFilterRFTempalateAkadKreditQueryHandler : IRequestHandler<RFTempalateAkadKreditsGetFilterQuery, PagedResponse<IEnumerable<RFTempalateAkadKreditResponseDto>>>
    {
        private IGenericRepositoryAsync<RFTempalateAkadKredit> _RFTempalateAkadKredit;
        private readonly IMapper _mapper;

        public GetFilterRFTempalateAkadKreditQueryHandler(IGenericRepositoryAsync<RFTempalateAkadKredit> RFTempalateAkadKredit, IMapper mapper)
        {
            _RFTempalateAkadKredit = RFTempalateAkadKredit;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFTempalateAkadKreditResponseDto>>> Handle(RFTempalateAkadKreditsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFTempalateAkadKredit.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFTempalateAkadKreditResponseDto>>(data.Results);
            IEnumerable<RFTempalateAkadKreditResponseDto> dataVm;
            var listResponse = new List<RFTempalateAkadKreditResponseDto>();

            foreach (var res in data.Results)
            {
                var response = _mapper.Map<RFTempalateAkadKreditResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFTempalateAkadKreditResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}