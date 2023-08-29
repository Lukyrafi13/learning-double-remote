using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFInsRateTemplates;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFInsRateTemplates.Commands
{
    public class RFInsRateTemplatePutCommand : RFInsRateTemplatePutRequestDto, IRequest<ServiceResponse<RFInsRateTemplateResponseDto>>
    {
    }

    public class PutRFInsRateTemplateCommandHandler : IRequestHandler<RFInsRateTemplatePutCommand, ServiceResponse<RFInsRateTemplateResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFInsRateTemplate> _RFInsRateTemplate;
        private readonly IMapper _mapper;

        public PutRFInsRateTemplateCommandHandler(IGenericRepositoryAsync<RFInsRateTemplate> RFInsRateTemplate, IMapper mapper)
        {
            _RFInsRateTemplate = RFInsRateTemplate;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFInsRateTemplateResponseDto>> Handle(RFInsRateTemplatePutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFInsRateTemplate = await _RFInsRateTemplate.GetByIdAsync(request.TPLCode, "TPLCode");
                
                existingRFInsRateTemplate = _mapper.Map<RFInsRateTemplatePutRequestDto, RFInsRateTemplate>(request, existingRFInsRateTemplate);

                await _RFInsRateTemplate.UpdateAsync(existingRFInsRateTemplate);

                var response = _mapper.Map<RFInsRateTemplateResponseDto>(existingRFInsRateTemplate);

                return ServiceResponse<RFInsRateTemplateResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFInsRateTemplateResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}