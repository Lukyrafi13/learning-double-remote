using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFKodeDinass;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFKodeDinass.Queries
{
    public class RFKodeDinassGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFKodeDinasResponseDto>>>
    {
    }

    public class GetFilterRFKodeDinasQueryHandler : IRequestHandler<RFKodeDinassGetFilterQuery, PagedResponse<IEnumerable<RFKodeDinasResponseDto>>>
    {
        private IGenericRepositoryAsync<RFKodeDinas> _RFKodeDinas;
        private readonly IMapper _mapper;

        public GetFilterRFKodeDinasQueryHandler(IGenericRepositoryAsync<RFKodeDinas> RFKodeDinas, IMapper mapper)
        {
            _RFKodeDinas = RFKodeDinas;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFKodeDinasResponseDto>>> Handle(RFKodeDinassGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFKodeDinas.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFKodeDinasResponseDto>>(data.Results);
            IEnumerable<RFKodeDinasResponseDto> dataVm;
            var listResponse = new List<RFKodeDinasResponseDto>();

            foreach (var result in data.Results){
                var response = _mapper.Map<RFKodeDinasResponseDto>(result);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFKodeDinasResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}