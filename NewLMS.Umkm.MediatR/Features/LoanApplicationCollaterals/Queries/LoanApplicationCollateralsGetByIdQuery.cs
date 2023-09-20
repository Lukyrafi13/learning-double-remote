using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.LoanApplicationCollateralOwners;
using NewLMS.Umkm.Data.Entities;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.LoanApplicationCollaterals.Queries
{
    public class LoanApplicationCollateralsGetByIdQuery : IRequest<ServiceResponse<LoanApplicationCollateralResponse>>
    {
        public Guid Id { get; set; }
    }

    public class LoanApplicationCollateralsGetByIdQueryHandler : IRequestHandler<LoanApplicationCollateralsGetByIdQuery, ServiceResponse<LoanApplicationCollateralResponse>>
    {
        private IGenericRepositoryAsync<LoanApplicationCollateral> _core;
        private readonly IMapper _mapper;

        public LoanApplicationCollateralsGetByIdQueryHandler(IGenericRepositoryAsync<LoanApplicationCollateral> core, IMapper mapper)
        {
            _core = core;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<LoanApplicationCollateralResponse>> Handle(LoanApplicationCollateralsGetByIdQuery request, CancellationToken cancellationToken)
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
                    "TypeOfDeed",
                    "LoanApplicationCollateralOwner.RfRelationCollateral",
                    "LoanApplicationCollateralOwner.RfZipCode",
                    "LoanApplicationCollateralOwner.RfMarital",
                    "LoanApplicationCollateralOwner.RfZipCodeOwnerCouple",
                };
                var data = await _core.GetByPredicate(x => x.Id == request.Id, includes);
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
