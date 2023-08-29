using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfCategories;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RfCategories.Queries
{
    public class RfCategoriesGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfCategoryResponseDto>>>
    {
    }

    public class GetFilterRfCategoryQueryHandler : IRequestHandler<RfCategoriesGetFilterQuery, PagedResponse<IEnumerable<RfCategoryResponseDto>>>
    {
        private IGenericRepositoryAsync<RfCategory> _RfCategory;
        private readonly IMapper _mapper;

        public GetFilterRfCategoryQueryHandler(IGenericRepositoryAsync<RfCategory> RfCategory, IMapper mapper)
        {
            _RfCategory = RfCategory;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfCategoryResponseDto>>> Handle(RfCategoriesGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _RfCategory.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RfCategoryResponseDto>>(data.Results);
            IEnumerable<RfCategoryResponseDto> dataVm;
            var listResponse = new List<RfCategoryResponseDto>();

            foreach (var result in data.Results){
                var response = _mapper.Map<RfCategoryResponseDto>(result);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RfCategoryResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}