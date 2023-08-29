using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFOwnerCategories;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RFOwnerCategories.Queries
{
    public class RfOwnerCategoryGetByOwnCodeQuery : RfOwnerCategoryFindRequestDto, IRequest<ServiceResponse<RfOwnerCategoryResponseDto>>
    {
    }

    public class GetByOwnCodeRfOwnerCategoryQueryHandler : IRequestHandler<RfOwnerCategoryGetByOwnCodeQuery, ServiceResponse<RfOwnerCategoryResponseDto>>
    {
        private IGenericRepositoryAsync<RfOwnerCategory> _rfGender;
        private readonly IMapper _mapper;

        public GetByOwnCodeRfOwnerCategoryQueryHandler(IGenericRepositoryAsync<RfOwnerCategory> rfGender, IMapper mapper)
        {
            _rfGender = rfGender;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfOwnerCategoryResponseDto>> Handle(RfOwnerCategoryGetByOwnCodeQuery request, CancellationToken cancellationToken)
        {

            var data = await _rfGender.GetByIdAsync(request.OwnCode, "OwnCode");

            var response = new RfOwnerCategoryResponseDto();
            response.Id = data.Id;
            response.OwnCode = data.OwnCode;
            response.OwnDesc = data.OwnDesc;
            response.CoreCode = data.CoreCode;
            response.Active = data.Active;
            
            return ServiceResponse<RfOwnerCategoryResponseDto>.ReturnResultWith200(response);
        }
    }
}