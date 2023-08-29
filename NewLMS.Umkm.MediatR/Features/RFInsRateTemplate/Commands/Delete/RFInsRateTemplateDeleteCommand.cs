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
    public class RFInsRateTemplateDeleteCommand : RFInsRateTemplateFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFInsRateTemplateCommandHandler : IRequestHandler<RFInsRateTemplateDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFInsRateTemplate> _RFInsRateTemplate;
        private readonly IMapper _mapper;

        public DeleteRFInsRateTemplateCommandHandler(IGenericRepositoryAsync<RFInsRateTemplate> RFInsRateTemplate, IMapper mapper){
            _RFInsRateTemplate = RFInsRateTemplate;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFInsRateTemplateDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFInsRateTemplate.GetByIdAsync(request.TPLCode, "TPLCode");
            rFProduct.IsDeleted = true;
            await _RFInsRateTemplate.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}