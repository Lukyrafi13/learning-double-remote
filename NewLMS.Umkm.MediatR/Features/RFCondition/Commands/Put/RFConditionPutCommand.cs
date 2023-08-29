using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFConditions;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFConditions.Commands
{
    public class RFConditionPutCommand : RFConditionPutRequestDto, IRequest<ServiceResponse<RFConditionResponseDto>>
    {
    }

    public class PutRFConditionCommandHandler : IRequestHandler<RFConditionPutCommand, ServiceResponse<RFConditionResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFCondition> _RFCondition;
        private readonly IMapper _mapper;

        public PutRFConditionCommandHandler(IGenericRepositoryAsync<RFCondition> RFCondition, IMapper mapper)
        {
            _RFCondition = RFCondition;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFConditionResponseDto>> Handle(RFConditionPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFCondition = await _RFCondition.GetByIdAsync(request.ConditionCode, "ConditionCode");
                
                existingRFCondition = _mapper.Map<RFConditionPutRequestDto, RFCondition>(request, existingRFCondition);
                
                await _RFCondition.UpdateAsync(existingRFCondition);

                var response = _mapper.Map<RFConditionResponseDto>(existingRFCondition);

                return ServiceResponse<RFConditionResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFConditionResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}