using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFTermConditions;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFTermConditions.Commands
{
    public class RFTermConditionPostCommand : RFTermConditionPostRequestDto, IRequest<ServiceResponse<RFTermConditionResponseDto>>
    {

    }
    public class RFTermConditionPostCommandHandler : IRequestHandler<RFTermConditionPostCommand, ServiceResponse<RFTermConditionResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFTermCondition> _RFTermCondition;
        private readonly IMapper _mapper;

        public RFTermConditionPostCommandHandler(IGenericRepositoryAsync<RFTermCondition> RFTermCondition, IMapper mapper)
        {
            _RFTermCondition = RFTermCondition;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFTermConditionResponseDto>> Handle(RFTermConditionPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFTermCondition = _mapper.Map<RFTermCondition>(request);

                var returnedRFTermCondition = await _RFTermCondition.AddAsync(RFTermCondition, callSave: false);

                // var response = _mapper.Map<RFTermConditionResponseDto>(returnedRFTermCondition);
                var response = _mapper.Map<RFTermConditionResponseDto>(returnedRFTermCondition);

                await _RFTermCondition.SaveChangeAsync();
                return ServiceResponse<RFTermConditionResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFTermConditionResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}