using AutoMapper;
using MediatR;
using NewLMS.UMKM.Common.GenericRespository;
using NewLMS.UMKM.Data.Dto.RfOwnerCategory;
using NewLMS.UMKM.Data.Dto.RfProduct;
using NewLMS.UMKM.Data.Entities;
using NewLMS.UMKM.MediatR.Features.RfProducts.Queries.GetFilterRfProducts;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewLMS.UMKM.MediatR.Features.RfOwnerCategories.Queries.GetFilterRfOwnerCategories
{
    public class RfOwnerCategoriesGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfOwnerCategoryResponse>>>
    {
    }

    public class RfOwnerCategoriesGetFilterQueryHandler : IRequestHandler<RfOwnerCategoriesGetFilterQuery, PagedResponse<IEnumerable<RfOwnerCategoryResponse>>>
    {
        private IGenericRepositoryAsync<RfOwnerCategory> _rfOwnerCategory;
        private readonly IMapper _mapper;

        public RfOwnerCategoriesGetFilterQueryHandler(IGenericRepositoryAsync<RfOwnerCategory> rfOwnerCategory, IMapper mapper)
        {
            _rfOwnerCategory = rfOwnerCategory;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfOwnerCategoryResponse>>> Handle(RfOwnerCategoriesGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfOwnerCategory.GetPagedReponseAsync(request);
            var dataVm = _mapper.Map<IEnumerable<RfOwnerCategoryResponse>>(data.Results);
            return new PagedResponse<IEnumerable<RfOwnerCategoryResponse>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
