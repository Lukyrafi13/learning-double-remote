using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfCompanyTypes;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfCompanyTypes.Queries
{
    public class RfCompanyTypeGetQuery : RfCompanyTypeFindRequestDto, IRequest<ServiceResponse<RfCompanyTypeResponseDto>>
    {
    }

    public class RfCompanyTypeGetQueryHandler : IRequestHandler<RfCompanyTypeGetQuery, ServiceResponse<RfCompanyTypeResponseDto>>
    {
        private IGenericRepositoryAsync<RfCompanyType> _RfCompanyType;
        private readonly IMapper _mapper;

        public RfCompanyTypeGetQueryHandler(IGenericRepositoryAsync<RfCompanyType> RfCompanyType, IMapper mapper)
        {
            _RfCompanyType = RfCompanyType;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RfCompanyTypeResponseDto>> Handle(RfCompanyTypeGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _RfCompanyType.GetByIdAsync(request.AnlCode, "AnlCode");
                if (data == null)
                    return ServiceResponse<RfCompanyTypeResponseDto>.Return404("Data RfCompanyType not found");
                var response = _mapper.Map<RfCompanyTypeResponseDto>(data);
                return ServiceResponse<RfCompanyTypeResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RfCompanyTypeResponseDto>.ReturnException(ex);
            }
        }
    }
}