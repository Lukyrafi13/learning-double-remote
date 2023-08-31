using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.LoanApplicationKeyPersons;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.LoanApplicationKeyPersons.Queries
{
    public class LoanApplicationKeyPersonGetQuery : LoanApplicationKeyPersonFindRequestDto, IRequest<ServiceResponse<LoanApplicationKeyPersonResponseDto>>
    {
    }

    public class LoanApplicationKeyPersonGetQueryHandler : IRequestHandler<LoanApplicationKeyPersonGetQuery, ServiceResponse<LoanApplicationKeyPersonResponseDto>>
    {
        private IGenericRepositoryAsync<LoanApplicationKeyPerson> _LoanApplicationKeyPerson;
        private readonly IMapper _mapper;

        public LoanApplicationKeyPersonGetQueryHandler(IGenericRepositoryAsync<LoanApplicationKeyPerson> LoanApplicationKeyPerson, IMapper mapper)
        {
            _LoanApplicationKeyPerson = LoanApplicationKeyPerson;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<LoanApplicationKeyPersonResponseDto>> Handle(LoanApplicationKeyPersonGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                    "LoanApplication",
                    "RfEducation",
                    "RfMarital",
                    "RfZipCode",
                };

                var data = await _LoanApplicationKeyPerson.GetByIdAsync(request.Id, "Id", includes);
                if (data == null)
                    return ServiceResponse<LoanApplicationKeyPersonResponseDto>.Return404("Data LoanApplicationKeyPerson not found");
                var response = _mapper.Map<LoanApplicationKeyPersonResponseDto>(data);
                return ServiceResponse<LoanApplicationKeyPersonResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<LoanApplicationKeyPersonResponseDto>.ReturnException(ex);
            }
        }
    }
}