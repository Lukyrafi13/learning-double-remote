using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.LoanApplicationFieldSurveyDetails;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.LoanApplicationFieldSurveyDetails.Commands
{
    public class PutLoanApplicationFieldSurveyDetailsCommand : LoanApplicationFIeldSurveyDetailsPutRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class PutLoanApplicationFieldSurveyDetailsCommandHandler : IRequestHandler<PutLoanApplicationFieldSurveyDetailsCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<LoanApplicationFieldSurveyDetail> _loanApplicationFieldSurveyDetail;
        private readonly IMapper _mapper;

        public PutLoanApplicationFieldSurveyDetailsCommandHandler(IGenericRepositoryAsync<LoanApplicationFieldSurveyDetail> loanApplicationFieldSurveyDetail, IMapper mapper)
        {
            _loanApplicationFieldSurveyDetail = loanApplicationFieldSurveyDetail;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(PutLoanApplicationFieldSurveyDetailsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var loanApplicationFieldSurveyDetail = await _loanApplicationFieldSurveyDetail.GetByPredicate(x => x.Id == request.Id);
                if (loanApplicationFieldSurveyDetail != null)
                {
                    _mapper.Map(request, loanApplicationFieldSurveyDetail);
                    await _loanApplicationFieldSurveyDetail.UpdateAsync(loanApplicationFieldSurveyDetail);
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
