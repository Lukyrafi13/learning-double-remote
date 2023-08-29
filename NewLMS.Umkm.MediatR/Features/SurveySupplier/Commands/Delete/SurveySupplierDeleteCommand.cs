using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.SurveySuppliers;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.SurveySuppliers.Commands
{
    public class SurveySupplierDeleteCommand : SurveySupplierFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteSurveySupplierCommandHandler : IRequestHandler<SurveySupplierDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<SurveySupplier> _SurveySupplier;
        private readonly IMapper _mapper;

        public DeleteSurveySupplierCommandHandler(IGenericRepositoryAsync<SurveySupplier> SurveySupplier, IMapper mapper){
            _SurveySupplier = SurveySupplier;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(SurveySupplierDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _SurveySupplier.GetByIdAsync(request.Id, "Id");
            rFProduct.IsDeleted = true;
            await _SurveySupplier.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}