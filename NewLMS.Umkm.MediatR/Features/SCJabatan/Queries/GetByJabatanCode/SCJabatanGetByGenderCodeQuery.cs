using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.SCJabatans;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.SCJabatans.Queries
{
    public class SCJabatansGetByGenderCodeQuery : SCJabatanFindRequestDto, IRequest<ServiceResponse<SCJabatanResponseDto>>
    {
    }

    public class GetByIdSCJabatansQueryHandler : IRequestHandler<SCJabatansGetByGenderCodeQuery, ServiceResponse<SCJabatanResponseDto>>
    {
        private IGenericRepositoryAsync<SCJabatan> _SCJabatans;
        private readonly IMapper _mapper;

        public GetByIdSCJabatansQueryHandler(IGenericRepositoryAsync<SCJabatan> SCJabatans, IMapper mapper)
        {
            _SCJabatans = SCJabatans;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<SCJabatanResponseDto>> Handle(SCJabatansGetByGenderCodeQuery request, CancellationToken cancellationToken)
        {

            var data = await _SCJabatans.GetByIdAsync(request.JAB_CODE, "JAB_CODE");

            var response = new SCJabatanResponseDto();
            response.Id = data.Id;
            response.JAB_CODE = data.JAB_CODE;
            response.JAB_DESC = data.JAB_DESC;
            response.SK_CODE = data.SK_CODE;
            response.CORE_CODE = data.CORE_CODE;
            response.ACTIVE = data.ACTIVE;
            response.SK_LIMIT_CODE = data.SK_LIMIT_CODE;

            return ServiceResponse<SCJabatanResponseDto>.ReturnResultWith200(response);
        }
    }
}