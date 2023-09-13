using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfVehModel;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfVehModels.Queries.GetFilterRfVehModels
{
    public class RfVehModelsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfVehModelResponse>>>
    {
    }

    public class RfVehModelsGetFilterQueryHandler : IRequestHandler<RfVehModelsGetFilterQuery, PagedResponse<IEnumerable<RfVehModelResponse>>>
    {
        private IGenericRepositoryAsync<RfVehModel> _rfVehModel;
        private readonly IMapper _mapper;

        public RfVehModelsGetFilterQueryHandler(IGenericRepositoryAsync<RfVehModel> rfVehModel, IMapper mapper)
        {
            _rfVehModel = rfVehModel;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfVehModelResponse>>> Handle(RfVehModelsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfVehModel.GetPagedReponseAsync(request);
            var dataVm = _mapper.Map<IEnumerable<RfVehModelResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfVehModelResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
