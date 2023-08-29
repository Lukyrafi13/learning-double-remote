using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFInsRateTemplates;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFInsRateTemplates.Queries
{
    public class RFInsRateTemplateGetQuery : RFInsRateTemplateFindRequestDto, IRequest<ServiceResponse<RFInsRateTemplateResponseDto>>
    {
    }

    public class RFInsRateTemplateGetQueryHandler : IRequestHandler<RFInsRateTemplateGetQuery, ServiceResponse<RFInsRateTemplateResponseDto>>
    {
        private IGenericRepositoryAsync<RFInsRateTemplate> _RFInsRateTemplate;
        private readonly IMapper _mapper;

        public RFInsRateTemplateGetQueryHandler(IGenericRepositoryAsync<RFInsRateTemplate> RFInsRateTemplate, IMapper mapper)
        {
            _RFInsRateTemplate = RFInsRateTemplate;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFInsRateTemplateResponseDto>> Handle(RFInsRateTemplateGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                };

                var data = await _RFInsRateTemplate.GetByIdAsync(request.TPLCode, "TPLCode");
                if (data == null)
                    return ServiceResponse<RFInsRateTemplateResponseDto>.Return404("Data RFInsRateTemplate not found");
                var response = _mapper.Map<RFInsRateTemplateResponseDto>(data);
                return ServiceResponse<RFInsRateTemplateResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFInsRateTemplateResponseDto>.ReturnException(ex);
            }
        }
    }
}