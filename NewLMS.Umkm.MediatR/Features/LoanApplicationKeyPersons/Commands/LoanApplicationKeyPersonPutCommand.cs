using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.LoanApplicationKeyPersons;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.LoanApplicationKeyPersons.Commands
{
    public class LoanApplicationKeyPersonPutCommand : LoanApplicationKeyPersonPutRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class LoanApplicationKeyPersonPutCommandHandler : IRequestHandler<LoanApplicationKeyPersonPutCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<LoanApplicationKeyPerson> _loanApplicationKeyPerson;
        private readonly IMapper _mapper;

        public LoanApplicationKeyPersonPutCommandHandler(IGenericRepositoryAsync<LoanApplicationKeyPerson> loanApplicationKeyPerson,IMapper mapper)
        {
            _loanApplicationKeyPerson = loanApplicationKeyPerson;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(LoanApplicationKeyPersonPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var loanApplicationKeyPerson = await _loanApplicationKeyPerson.GetByIdAsync(request.Id, "Id");
                if (loanApplicationKeyPerson != null)
                {
                    _mapper.Map(request, loanApplicationKeyPerson);
                    await _loanApplicationKeyPerson.UpdateAsync(loanApplicationKeyPerson);
                }
                else
                {
                    return ServiceResponse<Unit>.Return404("Data OtherFinance Not Found");
                }

                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);

            }
            catch (Exception ex)
            {

                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
