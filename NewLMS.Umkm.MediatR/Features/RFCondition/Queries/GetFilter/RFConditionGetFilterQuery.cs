using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFConditions;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFConditions.Queries
{
    public class RFConditionsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFConditionResponseDto>>>
    {
    }

    public class RFConditionsGetFilterQueryHandler : IRequestHandler<RFConditionsGetFilterQuery, PagedResponse<IEnumerable<RFConditionResponseDto>>>
    {
        private IGenericRepositoryAsync<RFCondition> _RFCondition;
        private readonly IMapper _mapper;

        public RFConditionsGetFilterQueryHandler(IGenericRepositoryAsync<RFCondition> RFCondition, IMapper mapper)
        {
            _RFCondition = RFCondition;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFConditionResponseDto>>> Handle(RFConditionsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
            };

            var data = await _RFCondition.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFConditionResponseDto>>(data.Results);
            IEnumerable<RFConditionResponseDto> dataVm;
            var listResponse = new List<RFConditionResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFConditionResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFConditionResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}