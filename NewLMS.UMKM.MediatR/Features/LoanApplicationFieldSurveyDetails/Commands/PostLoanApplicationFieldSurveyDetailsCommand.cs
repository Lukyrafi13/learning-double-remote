using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.LoanApplicationSurvey;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.LoanApplicationFieldSurveyDetails.Commands
{
    public class PostLoanApplicationFieldSurveyDetailsCommand : LoanApplicationFieldSurveyPostRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class PostLoanApplicationFieldSurveyDetailsCommandHandler : IRequestHandler<PostLoanApplicationFieldSurveyDetailsCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<LoanApplicationFieldSurveyDetail> _loanApplicationFieldSurveyDetail;
        private readonly IMapper _mapper;

        public PostLoanApplicationFieldSurveyDetailsCommandHandler(IGenericRepositoryAsync<LoanApplicationFieldSurveyDetail> loanApplicationFieldSurveyDetal, IMapper mapper)
        {
            _loanApplicationFieldSurveyDetail = loanApplicationFieldSurveyDetal;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(PostLoanApplicationFieldSurveyDetailsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var loanApplicationFieldSurveyDetal = _mapper.Map<LoanApplicationFieldSurveyDetail>(request);
                await _loanApplicationFieldSurveyDetail.AddAsync(loanApplicationFieldSurveyDetal);

                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);

            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }

        }
    }
}
