using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.LoanApplicationKeyPersons;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.LoanApplicationKeyPersons.Commands
{
    public class LoanApplicationKeyPersonDeleteCommand : LoanApplicationKeyPersonFindRequestDto, IRequest<ServiceResponse<Unit>>
    {
        
    }

    public class DeleteLoanApplicationKeyPersonCommandHandler : IRequestHandler<LoanApplicationKeyPersonDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<LoanApplicationKeyPerson> _LoanApplicationKeyPerson;
        private readonly IMapper _mapper;

        public DeleteLoanApplicationKeyPersonCommandHandler(IGenericRepositoryAsync<LoanApplicationKeyPerson> LoanApplicationKeyPerson, IMapper mapper){
            _LoanApplicationKeyPerson = LoanApplicationKeyPerson;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(LoanApplicationKeyPersonDeleteCommand request, CancellationToken cancellationToken)
        {
            var rFProduct = await _LoanApplicationKeyPerson.GetByIdAsync(request.Id, "Id");
            rFProduct.IsDeleted = true;
            await _LoanApplicationKeyPerson.UpdateAsync(rFProduct);
            return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
        }
    }
}