using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfCategories;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfCategories.Queries
{
    public class RfCategoriesGetByCategoryCodeQuery : RfCategoryFindRequestDto, IRequest<ServiceResponse<RfCategoryResponseDto>>
    {
    }

    public class GetByIdRfCategoryQueryHandler : IRequestHandler<RfCategoriesGetByCategoryCodeQuery, ServiceResponse<RfCategoryResponseDto>>
    {
        private IGenericRepositoryAsync<RfCategory> _RfCategory;
        private readonly IMapper _mapper;

        public GetByIdRfCategoryQueryHandler(IGenericRepositoryAsync<RfCategory> RfCategory, IMapper mapper)
        {
            _RfCategory = RfCategory;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfCategoryResponseDto>> Handle(RfCategoriesGetByCategoryCodeQuery request, CancellationToken cancellationToken)
        {

            var data = await _RfCategory.GetByIdAsync(request.CategoryCode, "CategoryCode");

            var response = _mapper.Map<RfCategoryResponseDto>(data);
            
            return ServiceResponse<RfCategoryResponseDto>.ReturnResultWith200(response);
        }
    }
}