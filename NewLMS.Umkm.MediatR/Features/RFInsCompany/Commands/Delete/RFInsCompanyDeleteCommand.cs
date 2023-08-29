using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFInsCompanys;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFInsCompanys.Commands
{
    public class RFInsCompanyDeleteCommand : RFInsCompanyFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteRFInsCompanyCommandHandler : IRequestHandler<RFInsCompanyDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<RFInsCompany> _RFInsCompany;
        private readonly IMapper _mapper;

        public DeleteRFInsCompanyCommandHandler(IGenericRepositoryAsync<RFInsCompany> RFInsCompany, IMapper mapper){
            _RFInsCompany = RFInsCompany;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(RFInsCompanyDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _RFInsCompany.GetByIdAsync(request.CompId, "CompId");
            rFProduct.IsDeleted = true;
            await _RFInsCompany.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}