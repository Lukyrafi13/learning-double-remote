using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.Prospects;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using System;
using NewLMS.UMKM.Data.Entities;

namespace NewLMS.UMKM.MediatR.Features.Prospects.Queries
{
    public class ProspectsGetByIdQuery : ProspectFindRequestDto, IRequest<ServiceResponse<ProspectResponse>>
    {
    }

    public class ProspectGetByIdQueryHandler : IRequestHandler<ProspectsGetByIdQuery, ServiceResponse<ProspectResponse>>
    {
        private IGenericRepositoryAsync<Prospect> _prospect;
        private readonly IMapper _mapper;

        public ProspectGetByIdQueryHandler(IGenericRepositoryAsync<Prospect> prospect, IMapper mapper)
        {
            _prospect = prospect;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<ProspectResponse>> Handle(ProspectsGetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var prospect = await _prospect.GetByPredicate(x => x.Id.ToString() == request.Id,
                    new string[] {
                        "RfCompanyGroup",
                        "RfCompanyStatus",
                        "RfCompanyType",
                        "RfBranch",
                        "RfProduct",
                        "RfGender",
                        "RfCategory",
                        "RfSectorLBU3.RfSectorLBU2.RfSectorLBU1",
                        "RfOwnerCategory",
                        "RfZipCode",
                        "RfPlaceZipCode",
                        "RfCompanyZipCode",
                        "RfApplicationType",
                    }
                );
                if (prospect == null)
                    return ServiceResponse<ProspectResponse>.ReturnResultWith204();

                var response = _mapper.Map<ProspectResponse>(prospect);

                return ServiceResponse<ProspectResponse>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<ProspectResponse>.ReturnException(ex);
            }
        }
    }
}