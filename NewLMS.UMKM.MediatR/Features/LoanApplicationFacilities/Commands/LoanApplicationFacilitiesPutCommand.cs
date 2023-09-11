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
    public class LoanApplicationFacilitiesPutCommand : LoanApplicationFacilityRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class LoanApplicationFacilitiesPutCommandHandler : IRequestHandler<LoanApplicationFacilitiesPutCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<LoanApplicationFacility> _loanApplicationFacility;
        private readonly IMapper _mapper;

        public LoanApplicationFacilitiesPutCommandHandler(IGenericRepositoryAsync<LoanApplicationFacility> loanApplicationFacility, IMapper mapper)
        {
            _loanApplicationFacility = loanApplicationFacility;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(LoanApplicationFacilitiesPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var loanApplicationFacility = await _loanApplicationFacility.GetByPredicate(x => x.Id == request.Id);
                if (loanApplicationFacility != null)
                {
                    _mapper.Map(request, loanApplicationFacility);
                    await _loanApplicationFacility.UpdateAsync(loanApplicationFacility);
                }
                else
                {
                    return ServiceResponse<Unit>.Return404("Data LoanApplicationFacility Not Found");
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
