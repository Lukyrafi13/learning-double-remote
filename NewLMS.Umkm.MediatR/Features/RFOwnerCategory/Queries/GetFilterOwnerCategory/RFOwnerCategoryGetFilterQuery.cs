using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFOwnerCategories;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFOwnerCategories.Queries
{
    public class RFOwnerCategoriesGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFOwnerCategoryResponseDto>>>
    {
    }

    public class GetFilterRFOwnerCategoryQueryHandler : IRequestHandler<RFOwnerCategoriesGetFilterQuery, PagedResponse<IEnumerable<RFOwnerCategoryResponseDto>>>
    {
        private IGenericRepositoryAsync<RFOwnerCategory> _rfGender;
        private readonly IMapper _mapper;

        public GetFilterRFOwnerCategoryQueryHandler(IGenericRepositoryAsync<RFOwnerCategory> rfGender, IMapper mapper)
        {
            _rfGender = rfGender;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFOwnerCategoryResponseDto>>> Handle(RFOwnerCategoriesGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfGender.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFOwnerCategoryResponseDto>>(data.Results);
            IEnumerable<RFOwnerCategoryResponseDto> dataVm;
            var listResponse = new List<RFOwnerCategoryResponseDto>();

            foreach (var gender in data.Results){
                var response = new RFOwnerCategoryResponseDto();
                
                response.Id = gender.Id;
                response.OwnCode = gender.OwnCode;
                response.OwnDesc = gender.OwnDesc;
                response.CoreCode = gender.CoreCode;
                response.Active = gender.Active;

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFOwnerCategoryResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}