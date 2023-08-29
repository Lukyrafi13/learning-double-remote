using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFJenisSyaratKredits;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFJenisSyaratKredits.Queries
{
    public class RFJenisSyaratKreditsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFJenisSyaratKreditResponseDto>>>
    {
    }

    public class RFJenisSyaratKreditsGetFilterQueryHandler : IRequestHandler<RFJenisSyaratKreditsGetFilterQuery, PagedResponse<IEnumerable<RFJenisSyaratKreditResponseDto>>>
    {
        private IGenericRepositoryAsync<RFJenisSyaratKredit> _RFJenisSyaratKredit;
        private readonly IMapper _mapper;

        public RFJenisSyaratKreditsGetFilterQueryHandler(IGenericRepositoryAsync<RFJenisSyaratKredit> RFJenisSyaratKredit, IMapper mapper)
        {
            _RFJenisSyaratKredit = RFJenisSyaratKredit;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFJenisSyaratKreditResponseDto>>> Handle(RFJenisSyaratKreditsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
            };

            var data = await _RFJenisSyaratKredit.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFJenisSyaratKreditResponseDto>>(data.Results);
            IEnumerable<RFJenisSyaratKreditResponseDto> dataVm;
            var listResponse = new List<RFJenisSyaratKreditResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFJenisSyaratKreditResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFJenisSyaratKreditResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}