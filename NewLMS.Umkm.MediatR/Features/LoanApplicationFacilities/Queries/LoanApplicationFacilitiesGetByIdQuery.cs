﻿using AutoMapper;
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

namespace NewLMS.Umkm.MediatR.Features.LoanApplicationFacilities.Queries
{
    public class LoanApplicationFacilitiesGetByIdQuery : IRequest<ServiceResponse<LoanApplicationFacilityResponse>>
    {
        public Guid Id { get; set; }
    }

    public class LoanApplicationFacilitiesGetByIdQueryHandler : IRequestHandler<LoanApplicationFacilitiesGetByIdQuery, ServiceResponse<LoanApplicationFacilityResponse>>
    {
        private IGenericRepositoryAsync<LoanApplicationFacility> _core;
        private readonly IMapper _mapper;

        public LoanApplicationFacilitiesGetByIdQueryHandler(IGenericRepositoryAsync<LoanApplicationFacility> core, IMapper mapper)
        {
            _core = core;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<LoanApplicationFacilityResponse>> Handle(LoanApplicationFacilitiesGetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[] {
                    "ApplicationType",
                    "NatureOfCredit",
                    "LoanPurpose",
                    "RfSubProduct",
                    "RfTenor",
                    "RfSectorLBU3.RfSectorLBU2.RfSectorLBU1",
                    "RfPlacementCountry",
                };
                var data = await _core.GetByPredicate(x => x.Id == request.Id, includes);
                if (data == null)
                    return ServiceResponse<LoanApplicationFacilityResponse>.Return404("Data LoanApplicationFacility tidak ditemukan.");
                var dataVm = _mapper.Map<LoanApplicationFacilityResponse>(data);
                return ServiceResponse<LoanApplicationFacilityResponse>.ReturnResultWith200(dataVm);
            }
            catch (Exception ex)
            {
                return ServiceResponse<LoanApplicationFacilityResponse>.ReturnException(ex);
            }

        }
    }
}
