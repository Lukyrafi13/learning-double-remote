using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFInsCompanys;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFInsCompanys.Queries
{
    public class RFInsCompanyGetQuery : RFInsCompanyFindRequestDto, IRequest<ServiceResponse<RFInsCompanyResponseDto>>
    {
    }

    public class RFInsCompanyGetQueryHandler : IRequestHandler<RFInsCompanyGetQuery, ServiceResponse<RFInsCompanyResponseDto>>
    {
        private IGenericRepositoryAsync<RFInsCompany> _RFInsCompany;
        private readonly IMapper _mapper;

        public RFInsCompanyGetQueryHandler(IGenericRepositoryAsync<RFInsCompany> RFInsCompany, IMapper mapper)
        {
            _RFInsCompany = RFInsCompany;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<RFInsCompanyResponseDto>> Handle(RFInsCompanyGetQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var includes = new string[]{
                };

                var data = await _RFInsCompany.GetByIdAsync(request.CompId, "CompId");
                if (data == null)
                    return ServiceResponse<RFInsCompanyResponseDto>.Return404("Data RFInsCompany not found");
                var response = _mapper.Map<RFInsCompanyResponseDto>(data);
                return ServiceResponse<RFInsCompanyResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFInsCompanyResponseDto>.ReturnException(ex);
            }
        }
    }
}