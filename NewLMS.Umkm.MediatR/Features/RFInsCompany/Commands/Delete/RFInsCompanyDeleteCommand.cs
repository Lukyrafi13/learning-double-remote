using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFInsCompanys;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFInsCompanys.Commands
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