using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.LoanApplicationKeyPersons;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.LoanApplicationKeyPersons.Commands
{
    public class LoanApplicationKeyPersonDeleteCommand : LoanApplicationKeyPersonDeleteRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class LoanApplicationKeyPersonDeleteCommandHandler : IRequestHandler<LoanApplicationKeyPersonDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<LoanApplicationKeyPerson> _loanApplicattionKeyPerson;
        private readonly IMapper _mapper;

        public LoanApplicationKeyPersonDeleteCommandHandler(IGenericRepositoryAsync<LoanApplicationKeyPerson> loanApplicationKeyPerson, IMapper mapper)
        {
            _loanApplicattionKeyPerson = loanApplicationKeyPerson;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(LoanApplicationKeyPersonDeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var loanApplicationKeyPerson = await _loanApplicattionKeyPerson.GetByPredicate(x => x.Id == request.Id);
                await _loanApplicattionKeyPerson.DeleteAsync(loanApplicationKeyPerson);
                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch(Exception ex)
            {
                return ServiceResponse<Unit>.ReturnException(ex);
            }
            
        }
    }
}
