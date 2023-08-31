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
    public class LoanApplicationKeyPersonPostCommand : LoanApplicationKeyPersonPostRequestDto, IRequest<ServiceResponse<LoanApplicationKeyPersonResponseDto>>
    {

    }
    public class LoanApplicationKeyPersonPostCommandHandler : IRequestHandler<LoanApplicationKeyPersonPostCommand, ServiceResponse<LoanApplicationKeyPersonResponseDto>>
    {
        private readonly IGenericRepositoryAsync<LoanApplicationKeyPerson> _LoanApplicationKeyPerson;
        private readonly IMapper _mapper;

        public LoanApplicationKeyPersonPostCommandHandler(IGenericRepositoryAsync<LoanApplicationKeyPerson> LoanApplicationKeyPerson, IMapper mapper)
        {
            _LoanApplicationKeyPerson = LoanApplicationKeyPerson;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<LoanApplicationKeyPersonResponseDto>> Handle(LoanApplicationKeyPersonPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var LoanApplicationKeyPerson = _mapper.Map<LoanApplicationKeyPerson>(request);

                var returnedLoanApplicationKeyPerson = await _LoanApplicationKeyPerson.AddAsync(LoanApplicationKeyPerson, callSave: false);

                // var response = _mapper.Map<LoanApplicationKeyPersonResponseDto>(returnedLoanApplicationKeyPerson);
                var response = _mapper.Map<LoanApplicationKeyPersonResponseDto>(returnedLoanApplicationKeyPerson);

                await _LoanApplicationKeyPerson.SaveChangeAsync();
                return ServiceResponse<LoanApplicationKeyPersonResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<LoanApplicationKeyPersonResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}