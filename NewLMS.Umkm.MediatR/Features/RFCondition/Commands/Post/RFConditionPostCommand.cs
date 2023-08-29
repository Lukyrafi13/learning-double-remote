using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFConditions;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFConditions.Commands
{
    public class RFConditionPostCommand : RFConditionPostRequestDto, IRequest<ServiceResponse<RFConditionResponseDto>>
    {

    }
    public class RFConditionPostCommandHandler : IRequestHandler<RFConditionPostCommand, ServiceResponse<RFConditionResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFCondition> _RFCondition;
        private readonly IMapper _mapper;

        public RFConditionPostCommandHandler(IGenericRepositoryAsync<RFCondition> RFCondition, IMapper mapper)
        {
            _RFCondition = RFCondition;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFConditionResponseDto>> Handle(RFConditionPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFCondition = _mapper.Map<RFCondition>(request);

                var returnedRFCondition = await _RFCondition.AddAsync(RFCondition, callSave: false);

                // var response = _mapper.Map<RFConditionResponseDto>(returnedRFCondition);
                var response = _mapper.Map<RFConditionResponseDto>(returnedRFCondition);

                await _RFCondition.SaveChangeAsync();
                return ServiceResponse<RFConditionResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFConditionResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}