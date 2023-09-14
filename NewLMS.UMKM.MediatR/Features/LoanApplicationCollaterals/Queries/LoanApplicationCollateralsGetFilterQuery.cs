using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.LoanApplicationCollateralOwners;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.LoanApplicationCollaterals.Queries
{
    public class LoanApplicationCollateralsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<LoanApplicationCollateralResponse>>>
    {
    }

    public class LoanApplicationCollateralsGetFilterQueryHandler : IRequestHandler<LoanApplicationCollateralsGetFilterQuery, PagedResponse<IEnumerable<LoanApplicationCollateralResponse>>>
    {
        private IGenericRepositoryAsync<LoanApplicationCollateral> _core;
        private readonly IMapper _mapper;

        public LoanApplicationCollateralsGetFilterQueryHandler(IGenericRepositoryAsync<LoanApplicationCollateral> core, IMapper mapper)
        {
            _core = core;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<LoanApplicationCollateralResponse>>> Handle(LoanApplicationCollateralsGetFilterQuery request, CancellationToken cancellationToken)
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
                    "LoanApplicationCollateralOwner.RfRelationCollateral",
                    "LoanApplicationCollateralOwner.RfZipCode",
                    "LoanApplicationCollateralOwner.RfMarital",
                    "LoanApplicationCollateralOwner.RfZipCodeOwnerCouple",
                };
                var data = await _core.GetPagedReponseAsync(request, includes);
                var dataVm = _mapper.Map<IEnumerable<LoanApplicationCollateralResponse>>(data.Results);
                return new PagedResponse<IEnumerable<LoanApplicationCollateralResponse>>(dataVm, data.Info, request.Page, request.Length)
                {
                    StatusCode = (int)HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
