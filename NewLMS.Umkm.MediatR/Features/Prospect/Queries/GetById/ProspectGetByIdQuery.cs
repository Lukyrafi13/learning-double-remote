using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.Prospects;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using NewLMS.UMKM.Data;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace NewLMS.UMKM.MediatR.Features.Prospects.Queries
{
    public class ProspectsGetByIdQuery : ProspectFindRequestDto, IRequest<ServiceResponse<ProspectResponseDto>>
    {
    }

    public class ProspectGetByIdQueryHandler : IRequestHandler<ProspectsGetByIdQuery, ServiceResponse<ProspectResponseDto>>
    {
        private IGenericRepositoryAsync<Prospect> _prospect;
        private readonly IMapper _mapper;

        public ProspectGetByIdQueryHandler(IGenericRepositoryAsync<Prospect> prospect, IMapper mapper)
        {
            _prospect = prospect;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<ProspectResponseDto>> Handle(ProspectsGetByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var prospect = await _prospect.GetByPredicate(x=>x.Id.ToString() == request.Id, 
                    new string[] {
                        "RfCompanyGroup",
                        "RfCompanyStatus",
                        "RfCompanyType",
                        "RfBranch",
                        "RfProduct",
                        "RfGender",
                        "RfSectorLBU3",
                        "RfOwnerCategory",
                        "RfZipCode",
                        "RfPlaceZipCode",
                        "RfCompanyZipCode",
                        "RfAppType",
                        "RfTargetStatus",
                    }
                );
                if (prospect == null)
                    return ServiceResponse<ProspectResponseDto>.Return404("Data Prospect not found");

                var response = _mapper.Map<ProspectResponseDto>(prospect);
                
                return ServiceResponse<ProspectResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<ProspectResponseDto>.ReturnException(ex);
            }
        }
    }
}