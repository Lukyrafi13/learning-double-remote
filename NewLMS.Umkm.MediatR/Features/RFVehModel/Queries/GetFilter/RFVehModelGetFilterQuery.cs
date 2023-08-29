using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFVehModels;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFVehModels.Queries
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