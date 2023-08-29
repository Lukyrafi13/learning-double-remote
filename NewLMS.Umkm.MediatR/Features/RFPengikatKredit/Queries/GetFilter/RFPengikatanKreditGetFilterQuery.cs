using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFPengikatanKredits;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFPengikatanKredits.Queries
{
    public class RFPengikatanKreditGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFPengikatanKreditResponseDto>>>
    {
    }

    public class RFPengikatanKreditGetFilterQueryHandler : IRequestHandler<RFPengikatanKreditGetFilterQuery, PagedResponse<IEnumerable<RFPengikatanKreditResponseDto>>>
    {
        private IGenericRepositoryAsync<RFPengikatanKredit> _RFPengikatanKredit;
        private readonly IMapper _mapper;

        public RFPengikatanKreditGetFilterQueryHandler(IGenericRepositoryAsync<RFPengikatanKredit> RFPengikatanKredit, IMapper mapper)
        {
            _RFPengikatanKredit = RFPengikatanKredit;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFPengikatanKreditResponseDto>>> Handle(RFPengikatanKreditGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
            };

            var data = await _RFPengikatanKredit.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFPengikatanKreditResponseDto>>(data.Results);
            IEnumerable<RFPengikatanKreditResponseDto> dataVm;
            var listResponse = new List<RFPengikatanKreditResponseDto>();

            foreach (var res in data.Results)
            {
                var response = _mapper.Map<RFPengikatanKreditResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFPengikatanKreditResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}