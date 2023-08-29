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