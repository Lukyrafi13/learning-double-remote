using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFVEHICLETYPEs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFVEHICLETYPEss.Queries
{
    public class RFVEHICLETYPEsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFVEHICLETYPEResponseDto>>>
    {
    }

    public class GetFilterRFVEHICLETYPEQueryHandler : IRequestHandler<RFVEHICLETYPEsGetFilterQuery, PagedResponse<IEnumerable<RFVEHICLETYPEResponseDto>>>
    {
        private IGenericRepositoryAsync<RFVEHICLETYPEs> _RFVEHICLETYPE;
        private readonly IMapper _mapper;

        public GetFilterRFVEHICLETYPEQueryHandler(IGenericRepositoryAsync<RFVEHICLETYPEs> RFVEHICLETYPE, IMapper mapper)
        {
            _RFVEHICLETYPE = RFVEHICLETYPE;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFVEHICLETYPEResponseDto>>> Handle(RFVEHICLETYPEsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFVEHICLETYPE.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFVEHICLETYPEResponseDto>>(data.Results);
            IEnumerable<RFVEHICLETYPEResponseDto> dataVm;
            var listResponse = new List<RFVEHICLETYPEResponseDto>();

            foreach (var res in data.Results)
            {
                var response = _mapper.Map<RFVEHICLETYPEResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFVEHICLETYPEResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}