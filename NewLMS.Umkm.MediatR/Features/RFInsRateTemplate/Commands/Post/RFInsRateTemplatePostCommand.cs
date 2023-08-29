using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFInsRateTemplates;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFInsRateTemplates.Commands
{
    public class RFInsRateTemplatePostCommand : RFInsRateTemplatePostRequestDto, IRequest<ServiceResponse<RFInsRateTemplateResponseDto>>
    {

    }
    public class RFInsRateTemplatePostCommandHandler : IRequestHandler<RFInsRateTemplatePostCommand, ServiceResponse<RFInsRateTemplateResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFInsRateTemplate> _RFInsRateTemplate;
        private readonly IMapper _mapper;

        public RFInsRateTemplatePostCommandHandler(IGenericRepositoryAsync<RFInsRateTemplate> RFInsRateTemplate, IMapper mapper)
        {
            _RFInsRateTemplate = RFInsRateTemplate;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFInsRateTemplateResponseDto>> Handle(RFInsRateTemplatePostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var RFInsRateTemplate = _mapper.Map<RFInsRateTemplate>(request);

                var returnedRFInsRateTemplate = await _RFInsRateTemplate.AddAsync(RFInsRateTemplate, callSave: false);

                // var response = _mapper.Map<RFInsRateTemplateResponseDto>(returnedRFInsRateTemplate);
                var response = _mapper.Map<RFInsRateTemplateResponseDto>(returnedRFInsRateTemplate);

                await _RFInsRateTemplate.SaveChangeAsync();
                return ServiceResponse<RFInsRateTemplateResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFInsRateTemplateResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}