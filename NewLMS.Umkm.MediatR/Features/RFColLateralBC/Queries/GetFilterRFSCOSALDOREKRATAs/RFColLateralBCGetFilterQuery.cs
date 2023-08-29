using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFColLateralBCs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFColLateralBCs.Queries
{
    public class RFColLateralBCsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFColLateralBCResponseDto>>>
    {
    }

    public class GetFilterRFColLateralBCQueryHandler : IRequestHandler<RFColLateralBCsGetFilterQuery, PagedResponse<IEnumerable<RFColLateralBCResponseDto>>>
    {
        private IGenericRepositoryAsync<RFColLateralBC> _RFColLateralBC;
        private readonly IMapper _mapper;

        public GetFilterRFColLateralBCQueryHandler(IGenericRepositoryAsync<RFColLateralBC> RFColLateralBC, IMapper mapper)
        {
            _RFColLateralBC = RFColLateralBC;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFColLateralBCResponseDto>>> Handle(RFColLateralBCsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFColLateralBC.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFColLateralBCResponseDto>>(data.Results);
            IEnumerable<RFColLateralBCResponseDto> dataVm;
            var listResponse = new List<RFColLateralBCResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFColLateralBCResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFColLateralBCResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}