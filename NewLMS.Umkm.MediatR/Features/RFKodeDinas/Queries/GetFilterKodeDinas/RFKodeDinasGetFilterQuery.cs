using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFKodeDinass;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFKodeDinass.Queries
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