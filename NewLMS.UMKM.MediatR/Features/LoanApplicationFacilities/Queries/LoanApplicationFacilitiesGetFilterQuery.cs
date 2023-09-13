using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.LoanApplicationFacilities;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.LoanApplicationFacilities.Queries
{
    public class LoanApplicationFacilitiesGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<LoanApplicationFacilityResponse>>>
    {
    }

    public class LoanApplicationFacilitiesGetFilterQueryHandler : IRequestHandler<LoanApplicationFacilitiesGetFilterQuery, PagedResponse<IEnumerable<LoanApplicationFacilityResponse>>>
    {
        private IGenericRepositoryAsync<LoanApplicationFacility> _core;
        private readonly IMapper _mapper;

        public LoanApplicationFacilitiesGetFilterQueryHandler(IGenericRepositoryAsync<LoanApplicationFacility> core, IMapper mapper)
        {
            _core = core;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<LoanApplicationFacilityResponse>>> Handle(LoanApplicationFacilitiesGetFilterQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[] {
                    "ApplicationType",
                    "NatureOfCredit",
                    "LoanPurpose",
                    "RfSubProduct",
                    "RfSectorLBU3.RfSectorLBU2.RfSectorLBU1",
                    "RfTenor",
                    "RfPlacementCountry",
                };
                var data = await _core.GetPagedReponseAsync(request, includes);
                var dataVm = _mapper.Map<IEnumerable<LoanApplicationFacilityResponse>>(data.Results);
                return new PagedResponse<IEnumerable<LoanApplicationFacilityResponse>>(dataVm, data.Info, request.Page, request.Length)
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
