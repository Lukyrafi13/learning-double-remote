using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFTermConditions;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFTermConditions.Queries
{
    public class RFTermConditionsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFTermConditionResponseDto>>>
    {
    }

    public class RFTermConditionsGetFilterQueryHandler : IRequestHandler<RFTermConditionsGetFilterQuery, PagedResponse<IEnumerable<RFTermConditionResponseDto>>>
    {
        private IGenericRepositoryAsync<RFTermCondition> _RFTermCondition;
        private readonly IMapper _mapper;

        public RFTermConditionsGetFilterQueryHandler(IGenericRepositoryAsync<RFTermCondition> RFTermCondition, IMapper mapper)
        {
            _RFTermCondition = RFTermCondition;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFTermConditionResponseDto>>> Handle(RFTermConditionsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
            };

            var data = await _RFTermCondition.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFTermConditionResponseDto>>(data.Results);
            IEnumerable<RFTermConditionResponseDto> dataVm;
            var listResponse = new List<RFTermConditionResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFTermConditionResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFTermConditionResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}