using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.LoanApplicationKeyPersons;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.LoanApplicationKeyPersons.Commands
{
    public class LoanApplicationKeyPersonPostCommand : LoanApplicationKeyPersonPostRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class LoanApplicationKeyPersonPostCommandHandler : IRequestHandler<LoanApplicationKeyPersonPostCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<LoanApplicationKeyPerson> _loanApplicationKeyPerson;
        private readonly IMapper _mapper;

        public LoanApplicationKeyPersonPostCommandHandler(IGenericRepositoryAsync<LoanApplicationKeyPerson> loanApplicationKeyPerson, IMapper mapper)
        {
            _loanApplicationKeyPerson = loanApplicationKeyPerson;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(LoanApplicationKeyPersonPostCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var loanApplicationKeyPerson = _mapper.Map<LoanApplicationKeyPerson>(request);
                await _loanApplicationKeyPerson.AddAsync(loanApplicationKeyPerson);

                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);

            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }

        }
    }
}
