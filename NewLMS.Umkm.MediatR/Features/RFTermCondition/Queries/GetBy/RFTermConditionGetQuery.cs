using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFTermConditions;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFTermConditions.Queries
{
    public class RFTermConditionGetQuery : RFTermConditionFindRequestDto, IRequest<ServiceResponse<RFTermConditionResponseDto>>
    {
    }

    public class RFTermConditionGetQueryHandler : IRequestHandler<RFTermConditionGetQuery, ServiceResponse<RFTermConditionResponseDto>>
    {
        private IGenericRepositoryAsync<RFTermCondition> _RFTermCondition;
        private readonly IMapper _mapper;

        public RFTermConditionGetQueryHandler(IGenericRepositoryAsync<RFTermCondition> RFTermCondition, IMapper mapper)
        {
            _RFTermCondition = RFTermCondition;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFTermConditionResponseDto>> Handle(RFTermConditionGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                };

                var data = await _RFTermCondition.GetByIdAsync(request.TermCode, "TermCode");
                if (data == null)
                    return ServiceResponse<RFTermConditionResponseDto>.Return404("Data RFTermCondition not found");
                var response = _mapper.Map<RFTermConditionResponseDto>(data);
                return ServiceResponse<RFTermConditionResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFTermConditionResponseDto>.ReturnException(ex);
            }
        }
    }
}