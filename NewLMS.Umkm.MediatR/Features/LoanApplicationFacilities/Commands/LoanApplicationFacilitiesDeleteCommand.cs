using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.LoanApplicationFacilities;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.LoanApplicationFacilities.Commands
{
    public class LoanApplicationFacilitiesDeleteCommand : LoanApplicationFacilityDeleteRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class LoanApplicationFacilitiesDeleteCommandHandler : IRequestHandler<LoanApplicationFacilitiesDeleteCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<LoanApplicationFacility> _loanApplicationFacility;
        private readonly IMapper _mapper;

        public LoanApplicationFacilitiesDeleteCommandHandler(IGenericRepositoryAsync<LoanApplicationFacility> loanApplicationFacility, IMapper mapper)
        {
            _loanApplicationFacility = loanApplicationFacility;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(LoanApplicationFacilitiesDeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var loanApplicationFacility = await _loanApplicationFacility.GetByPredicate(x => x.Id == request.Id);
                await _loanApplicationFacility.DeleteAsync(loanApplicationFacility);
                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnException(ex);
            }

        }
    }
}
