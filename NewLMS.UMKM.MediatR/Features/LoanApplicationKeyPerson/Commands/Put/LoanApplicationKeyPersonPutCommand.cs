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
    public class LoanApplicationKeyPersonPutCommand : LoanApplicationKeyPersonPutRequestDto, IRequest<ServiceResponse<LoanApplicationKeyPersonResponseDto>>
    {
    }

    public class PutLoanApplicationKeyPersonCommandHandler : IRequestHandler<LoanApplicationKeyPersonPutCommand, ServiceResponse<LoanApplicationKeyPersonResponseDto>>
    {
        private readonly IGenericRepositoryAsync<LoanApplicationKeyPerson> _LoanApplicationKeyPerson;
        private readonly IMapper _mapper;

        public PutLoanApplicationKeyPersonCommandHandler(IGenericRepositoryAsync<LoanApplicationKeyPerson> LoanApplicationKeyPerson, IMapper mapper)
        {
            _LoanApplicationKeyPerson = LoanApplicationKeyPerson;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<LoanApplicationKeyPersonResponseDto>> Handle(LoanApplicationKeyPersonPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingLoanApplicationKeyPerson = await _LoanApplicationKeyPerson.GetByIdAsync(request.Id, "Id");
                
                existingLoanApplicationKeyPerson = _mapper.Map<LoanApplicationKeyPersonPutRequestDto, LoanApplicationKeyPerson>(request, existingLoanApplicationKeyPerson);

                await _LoanApplicationKeyPerson.UpdateAsync(existingLoanApplicationKeyPerson);

                var response = _mapper.Map<LoanApplicationKeyPersonResponseDto>(existingLoanApplicationKeyPerson);

                return ServiceResponse<LoanApplicationKeyPersonResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<LoanApplicationKeyPersonResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}