﻿using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.LoanApplicationPrescreenings;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Domain.Context;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.MediatR.Helpers;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.LoanApplications.Commands
{
    public class UpsertLoanApplicationPrescreeningCommand : LoanApplicationPrescreeningUpsertRequest, IRequest<ServiceResponse<Unit>>
    {
    }

    public class UpsertLoanApplicationPrescreeningCommandHandler : IRequestHandler<UpsertLoanApplicationPrescreeningCommand, ServiceResponse<Unit>>
    {
        private readonly IGenericRepositoryAsync<LoanApplication> _loanApplication;
        private readonly IGenericRepositoryAsync<LoanApplicationRAC> _loanApplicationRAC;
        private readonly UserContext _userContext;
        private readonly IMapper _mapper;

        public UpsertLoanApplicationPrescreeningCommandHandler(
            IGenericRepositoryAsync<LoanApplication> loanApplication,
            IGenericRepositoryAsync<LoanApplicationRAC> loanApplicationRAC,
            IMapper mapper,
            UserContext userContext)
        {
            _loanApplication = loanApplication;
            _loanApplicationRAC = loanApplicationRAC;
            _mapper = mapper;
            _userContext = userContext;
        }

        public async Task<ServiceResponse<Unit>> Handle(UpsertLoanApplicationPrescreeningCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _userContext.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                var includes = IncludesGenerator.GetLoanApplicationIncludes(request.Tab);
                var loanApplication = await _loanApplication.GetByIdAsync(request.LoanApplicationGuid, "Id", includes.ToArray());
                var loanApplicationRAC = await _loanApplicationRAC.GetByPredicate(x => x.Id == request.LoanApplicationGuid);

                switch (request.Tab)
                {
                    case "loanapplication_rac":
                        if (loanApplicationRAC != null)
                        {
                            loanApplicationRAC = _mapper.Map(request.LoanApplicationRAC, loanApplicationRAC);
                            await _loanApplicationRAC.UpdateAsync(loanApplicationRAC);
                        }
                        if (loanApplicationRAC == null)
                        {
                            loanApplicationRAC = _mapper.Map(request.LoanApplicationRAC, loanApplicationRAC);
                            loanApplicationRAC.Id = request.LoanApplicationGuid;
                            await _loanApplicationRAC.AddAsync(loanApplicationRAC);
                        }
                        break;

                    case "prescreening_duplikasi":
                        if (loanApplication != null)
                        {
                            loanApplication.DuplicationsVerified = request.Duplication.DuplicationsVerified;
                            await _loanApplication.UpdateAsync(loanApplication);
                        }
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);

                return ServiceResponse<Unit>.ReturnException(ex);
            }

            await transaction.CommitAsync(cancellationToken);

            return ServiceResponse<Unit>.ReturnResultWith201(Unit.Value);
        }
    }
}
