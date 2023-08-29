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
    public class RFTermConditionPutCommand : RFTermConditionPutRequestDto, IRequest<ServiceResponse<RFTermConditionResponseDto>>
    {
    }

    public class PutRFTermConditionCommandHandler : IRequestHandler<RFTermConditionPutCommand, ServiceResponse<RFTermConditionResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFTermCondition> _RFTermCondition;
        private readonly IMapper _mapper;

        public PutRFTermConditionCommandHandler(IGenericRepositoryAsync<RFTermCondition> RFTermCondition, IMapper mapper)
        {
            _RFTermCondition = RFTermCondition;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFTermConditionResponseDto>> Handle(RFTermConditionPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFTermCondition = await _RFTermCondition.GetByIdAsync(request.TermCode, "TermCode");
                
                existingRFTermCondition.TermDesc = request.TermDesc;
                existingRFTermCondition.TemplateCode = request.TemplateCode;
                existingRFTermCondition.CoreCode = request.CoreCode;
                existingRFTermCondition.SIKPCode = request.SIKPCode;
                existingRFTermCondition.Active = request.Active;
                existingRFTermCondition.SyaratBTB = request.SyaratBTB;
                existingRFTermCondition.Note = request.Note;
                existingRFTermCondition.Verified = request.Verified;
                existingRFTermCondition.Locked = request.Locked;
                
                await _RFTermCondition.UpdateAsync(existingRFTermCondition);

                var response = _mapper.Map<RFTermConditionResponseDto>(existingRFTermCondition);

                return ServiceResponse<RFTermConditionResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFTermConditionResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}