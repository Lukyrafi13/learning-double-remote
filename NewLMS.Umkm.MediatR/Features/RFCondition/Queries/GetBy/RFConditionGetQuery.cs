using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFConditions;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFConditions.Queries
{
    public class RFConditionGetQuery : RFConditionFindRequestDto, IRequest<ServiceResponse<RFConditionResponseDto>>
    {
    }

    public class RFConditionGetQueryHandler : IRequestHandler<RFConditionGetQuery, ServiceResponse<RFConditionResponseDto>>
    {
        private IGenericRepositoryAsync<RFCondition> _RFCondition;
        private readonly IMapper _mapper;

        public RFConditionGetQueryHandler(IGenericRepositoryAsync<RFCondition> RFCondition, IMapper mapper)
        {
            _RFCondition = RFCondition;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFConditionResponseDto>> Handle(RFConditionGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                };

                var data = await _RFCondition.GetByIdAsync(request.ConditionCode, "ConditionCode");
                if (data == null)
                    return ServiceResponse<RFConditionResponseDto>.Return404("Data RFCondition not found");
                var response = _mapper.Map<RFConditionResponseDto>(data);
                return ServiceResponse<RFConditionResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFConditionResponseDto>.ReturnException(ex);
            }
        }
    }
}