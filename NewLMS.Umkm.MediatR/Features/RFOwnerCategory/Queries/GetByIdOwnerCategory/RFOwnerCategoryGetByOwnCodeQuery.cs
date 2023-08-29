using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFOwnerCategories;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.Umkm.MediatR.Features.RFOwnerCategories.Queries
{
    public class RFOwnerCategoryGetByOwnCodeQuery : RFOwnerCategoryFindRequestDto, IRequest<ServiceResponse<RFOwnerCategoryResponseDto>>
    {
    }

    public class GetByOwnCodeRFOwnerCategoryQueryHandler : IRequestHandler<RFOwnerCategoryGetByOwnCodeQuery, ServiceResponse<RFOwnerCategoryResponseDto>>
    {
        private IGenericRepositoryAsync<RFOwnerCategory> _rfGender;
        private readonly IMapper _mapper;

        public GetByOwnCodeRFOwnerCategoryQueryHandler(IGenericRepositoryAsync<RFOwnerCategory> rfGender, IMapper mapper)
        {
            _rfGender = rfGender;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFOwnerCategoryResponseDto>> Handle(RFOwnerCategoryGetByOwnCodeQuery request, CancellationToken cancellationToken)
        {

            var data = await _rfGender.GetByIdAsync(request.OwnCode, "OwnCode");

            var response = new RFOwnerCategoryResponseDto();
            response.Id = data.Id;
            response.OwnCode = data.OwnCode;
            response.OwnDesc = data.OwnDesc;
            response.CoreCode = data.CoreCode;
            response.Active = data.Active;
            
            return ServiceResponse<RFOwnerCategoryResponseDto>.ReturnResultWith200(response);
        }
    }
}