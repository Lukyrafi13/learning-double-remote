using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFHOMESTAs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFHOMESTAs.Queries
{
    public class RFHOMESTAsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFHOMESTAResponseDto>>>
    {
    }

    public class GetFilterRFHOMESTAQueryHandler : IRequestHandler<RFHOMESTAsGetFilterQuery, PagedResponse<IEnumerable<RFHOMESTAResponseDto>>>
    {
        private IGenericRepositoryAsync<RFHOMESTA> _RFHOMESTA;
        private readonly IMapper _mapper;

        public GetFilterRFHOMESTAQueryHandler(IGenericRepositoryAsync<RFHOMESTA> RFHOMESTA, IMapper mapper)
        {
            _RFHOMESTA = RFHOMESTA;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFHOMESTAResponseDto>>> Handle(RFHOMESTAsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFHOMESTA.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFHOMESTAResponseDto>>(data.Results);
            IEnumerable<RFHOMESTAResponseDto> dataVm;
            var listResponse = new List<RFHOMESTAResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFHOMESTAResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFHOMESTAResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}