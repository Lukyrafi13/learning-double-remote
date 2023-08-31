using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.LoanApplicationCreditFacilities;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.LoanApplicationCreditFacilities.Commands
{
    public class LoanApplicationCreditFacilityDeleteCommand : LoanApplicationCreditFacilityFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteLoanApplicationCreditFacilityCommandHandler : IRequestHandler<LoanApplicationCreditFacilityDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<LoanApplicationCreditFacility> _LoanApplicationCreditFacility;
        private readonly IMapper _mapper;

        public DeleteLoanApplicationCreditFacilityCommandHandler(IGenericRepositoryAsync<LoanApplicationCreditFacility> LoanApplicationCreditFacility, IMapper mapper){
            _LoanApplicationCreditFacility = LoanApplicationCreditFacility;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(LoanApplicationCreditFacilityDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _LoanApplicationCreditFacility.GetByIdAsync(request.Id, "Id");
            rFProduct.IsDeleted = true;
            await _LoanApplicationCreditFacility.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}