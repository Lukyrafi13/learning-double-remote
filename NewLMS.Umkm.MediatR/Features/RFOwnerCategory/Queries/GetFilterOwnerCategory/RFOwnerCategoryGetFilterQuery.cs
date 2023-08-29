using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFOwnerCategories;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFOwnerCategories.Queries
{
    public class RFOwnerCategoriesGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfOwnerCategoryResponseDto>>>
    {
    }

    public class GetFilterRfOwnerCategoryQueryHandler : IRequestHandler<RFOwnerCategoriesGetFilterQuery, PagedResponse<IEnumerable<RfOwnerCategoryResponseDto>>>
    {
        private IGenericRepositoryAsync<RfOwnerCategory> _rfGender;
        private readonly IMapper _mapper;

        public GetFilterRfOwnerCategoryQueryHandler(IGenericRepositoryAsync<RfOwnerCategory> rfGender, IMapper mapper)
        {
            _rfGender = rfGender;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfOwnerCategoryResponseDto>>> Handle(RFOwnerCategoriesGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfGender.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RfOwnerCategoryResponseDto>>(data.Results);
            IEnumerable<RfOwnerCategoryResponseDto> dataVm;
            var listResponse = new List<RfOwnerCategoryResponseDto>();

            foreach (var gender in data.Results){
                var response = new RfOwnerCategoryResponseDto();
                
                response.Id = gender.Id;
                response.OwnCode = gender.OwnCode;
                response.OwnDesc = gender.OwnDesc;
                response.CoreCode = gender.CoreCode;
                response.Active = gender.Active;

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RfOwnerCategoryResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}