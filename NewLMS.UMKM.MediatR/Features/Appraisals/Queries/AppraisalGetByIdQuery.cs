using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.Appraisals;
using NewLMS.UMKM.Data.Dto.LoanApplicationCollateralOwners;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;   
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.Appraisals.Queries
{
    public class AppraisalGetByIdQuery : IRequest<ServiceResponse<LoanApplicationCollateralResponse>>
    {
        public Guid LoanApplicationCollateralId { get; set; }
    }

    public class AppraisalGetByIdQueryHandler : IRequestHandler<AppraisalGetByIdQuery, ServiceResponse<LoanApplicationCollateralResponse>>
    {
        private IGenericRepositoryAsync<LoanApplicationCollateral> _core;
        private readonly IMapper _mapper;

        public AppraisalGetByIdQueryHandler(IGenericRepositoryAsync<LoanApplicationCollateral> core, IMapper mapper)
        {
            _core = core;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<LoanApplicationCollateralResponse>> Handle(AppraisalGetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[] {
                    "LoanApplicationCollateralOwner",
                    "RfZipCode",
                    "RfVehMaker",
                    "RfVehClass",
                    "RfVehModel",
                    "RfDocument",
                    "RfTransportationType",
                    "RfCollateralBC",
                    "LoanApplicationCollateralOwner.RfRelationCollateral",
                    "LoanApplicationCollateralOwner.RfZipCode",
                    "LoanApplicationCollateralOwner.RfMarital",
                    "LoanApplicationCollateralOwner.RfZipCodeOwnerCouple",
                };
                var data = await _core.GetByPredicate(x => x.Id == request.LoanApplicationCollateralId, includes);
                if (data == null)
                    return ServiceResponse<LoanApplicationCollateralResponse>.Return404("Data LoanApplicationCollateral tidak ditemukan.");
                var dataVm = _mapper.Map<LoanApplicationCollateralResponse>(data);
                return ServiceResponse<LoanApplicationCollateralResponse>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {
                return ServiceResponse<LoanApplicationCollateralResponse>.ReturnException(ex);
            }

        }
    }
}
