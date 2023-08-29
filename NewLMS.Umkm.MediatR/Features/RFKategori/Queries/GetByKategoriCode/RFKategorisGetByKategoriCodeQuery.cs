using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfCategorys;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfCategorys.Queries
{
    public class RfCategorysGetByKategoriCodeQuery : RfCategoryFindRequestDto, IRequest<ServiceResponse<RfCategoryResponseDto>>
    {
    }

    public class GetByIdRfCategoryQueryHandler : IRequestHandler<RfCategorysGetByKategoriCodeQuery, ServiceResponse<RfCategoryResponseDto>>
    {
        private IGenericRepositoryAsync<RfCategory> _RfCategory;
        private readonly IMapper _mapper;

        public GetByIdRfCategoryQueryHandler(IGenericRepositoryAsync<RfCategory> RfCategory, IMapper mapper)
        {
            _RfCategory = RfCategory;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RfCategoryResponseDto>> Handle(RfCategorysGetByKategoriCodeQuery request, CancellationToken cancellationToken)
        {

            var data = await _RfCategory.GetByIdAsync(request.KategoriCode, "KategoriCode");

            var response = _mapper.Map<RfCategoryResponseDto>(data);
            
            return ServiceResponse<RfCategoryResponseDto>.ReturnResultWith200(response);
        }
    }
}