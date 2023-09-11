using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.LoanApplicationFacilities;
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

namespace NewLMS.UMKM.MediatR.Features.LoanApplicationFacilities.Commands
{
    public class LoanApplicationFacilitiesPostCommand : LoanApplicationFacilityPostRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class LoanApplicationFacilitiesPostCommandHandler : IRequestHandler<LoanApplicationFacilitiesPostCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<LoanApplicationFacility> _loanApplicationFacility;
        private readonly IMapper _mapper;

        public LoanApplicationFacilitiesPostCommandHandler(IGenericRepositoryAsync<LoanApplicationFacility> loanApplicationFacility, IMapper mapper)
        {
            _loanApplicationFacility = loanApplicationFacility;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(LoanApplicationFacilitiesPostCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var loanApplicationFacility = _mapper.Map<LoanApplicationFacility>(request);
                await _loanApplicationFacility.AddAsync(loanApplicationFacility);

                return ServiceResponse<Unit>.ReturnResultWith201(Unit.Value);

            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }

        }
    }
}
