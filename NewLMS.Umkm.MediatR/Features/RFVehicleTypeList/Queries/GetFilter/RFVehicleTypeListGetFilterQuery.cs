using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFVehicleTypeLists;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFVehicleTypeLists.Queries
{
    public class RFVehicleTypeListsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFVehicleTypeListResponseDto>>>
    {
    }

    public class GetFilterRFVehicleTypeListQueryHandler : IRequestHandler<RFVehicleTypeListsGetFilterQuery, PagedResponse<IEnumerable<RFVehicleTypeListResponseDto>>>
    {
        private IGenericRepositoryAsync<RFVehicleTypeList> _RFVehicleTypeList;
        private readonly IMapper _mapper;

        public GetFilterRFVehicleTypeListQueryHandler(IGenericRepositoryAsync<RFVehicleTypeList> RFVehicleTypeList, IMapper mapper)
        {
            _RFVehicleTypeList = RFVehicleTypeList;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFVehicleTypeListResponseDto>>> Handle(RFVehicleTypeListsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFVehicleTypeList.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFVehicleTypeListResponseDto>>(data.Results);
            IEnumerable<RFVehicleTypeListResponseDto> dataVm;
            var listResponse = new List<RFVehicleTypeListResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFVehicleTypeListResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFVehicleTypeListResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}