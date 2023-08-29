using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFVehModels;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFVehModels.Queries
{
    public class RFVehModelsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFVehModelResponseDto>>>
    {
    }

    public class GetFilterRFVehModelQueryHandler : IRequestHandler<RFVehModelsGetFilterQuery, PagedResponse<IEnumerable<RFVehModelResponseDto>>>
    {
        private IGenericRepositoryAsync<RFVehModel> _RFVehModel;
        private readonly IMapper _mapper;

        public GetFilterRFVehModelQueryHandler(IGenericRepositoryAsync<RFVehModel> RFVehModel, IMapper mapper)
        {
            _RFVehModel = RFVehModel;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFVehModelResponseDto>>> Handle(RFVehModelsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RFVehModel.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFVehModelResponseDto>>(data.Results);
            IEnumerable<RFVehModelResponseDto> dataVm;
            var listResponse = new List<RFVehModelResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFVehModelResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFVehModelResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}