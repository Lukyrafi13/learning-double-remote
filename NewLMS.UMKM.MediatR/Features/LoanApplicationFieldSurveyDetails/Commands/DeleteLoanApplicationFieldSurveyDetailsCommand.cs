﻿using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.LoanApplicationFieldSurveyDetails;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.LoanApplicationFieldSurveyDetails.Commands
{
    public class DeleteLoanApplicationFieldSurveyDetailsCommand : LoanApplicationFieldSurveyDetailsDeleteRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class DeleteLoanApplicationFieldSurveyDetailsCommandHandler : IRequestHandler<DeleteLoanApplicationFieldSurveyDetailsCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<LoanApplicationFieldSurveyDetail> _loanApplicattionFieldSurveyDetail;
        private readonly IMapper _mapper;

        public DeleteLoanApplicationFieldSurveyDetailsCommandHandler(IGenericRepositoryAsync<LoanApplicationFieldSurveyDetail> loanApplicationFieldSurveyDetail, IMapper mapper)
        {
            _loanApplicattionFieldSurveyDetail = loanApplicationFieldSurveyDetail;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Unit>> Handle(DeleteLoanApplicationFieldSurveyDetailsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var loanApplicationFieldSurveyDetail = await _loanApplicattionFieldSurveyDetail.GetByPredicate(x => x.Id == request.Id);
                await _loanApplicattionFieldSurveyDetail.DeleteAsync(loanApplicationFieldSurveyDetail);
                return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
            }
            catch (Exception ex)
            {
                return ServiceResponse<Unit>.ReturnException(ex);
            }

        }
    }
}
