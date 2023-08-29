using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFKepemilikanUsahas;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFKepemilikanUsahas.Queries
{
    public class RFKepemilikanUsahasGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFKepemilikanUsahaResponseDto>>>
    {
    }

    public class RFKepemilikanUsahasGetFilterQueryHandler : IRequestHandler<RFKepemilikanUsahasGetFilterQuery, PagedResponse<IEnumerable<RFKepemilikanUsahaResponseDto>>>
    {
        private IGenericRepositoryAsync<RFKepemilikanUsaha> _RFKepemilikanUsaha;
        private readonly IMapper _mapper;

        public RFKepemilikanUsahasGetFilterQueryHandler(IGenericRepositoryAsync<RFKepemilikanUsaha> RFKepemilikanUsaha, IMapper mapper)
        {
            _RFKepemilikanUsaha = RFKepemilikanUsaha;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFKepemilikanUsahaResponseDto>>> Handle(RFKepemilikanUsahasGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
            };

            var data = await _RFKepemilikanUsaha.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFKepemilikanUsahaResponseDto>>(data.Results);
            IEnumerable<RFKepemilikanUsahaResponseDto> dataVm;
            var listResponse = new List<RFKepemilikanUsahaResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFKepemilikanUsahaResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFKepemilikanUsahaResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}