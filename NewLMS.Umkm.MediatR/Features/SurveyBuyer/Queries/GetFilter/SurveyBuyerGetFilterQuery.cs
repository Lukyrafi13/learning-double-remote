using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.SurveyBuyers;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.SurveyBuyers.Queries
{
    public class SurveyBuyersGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<SurveyBuyerResponseDto>>>
    {
    }

    public class GetFilterSurveyBuyerQueryHandler : IRequestHandler<SurveyBuyersGetFilterQuery, PagedResponse<IEnumerable<SurveyBuyerResponseDto>>>
    {
        private IGenericRepositoryAsync<SurveyBuyer> _SurveyBuyer;
        private readonly IMapper _mapper;

        public GetFilterSurveyBuyerQueryHandler(IGenericRepositoryAsync<SurveyBuyer> SurveyBuyer, IMapper mapper)
        {
            _SurveyBuyer = SurveyBuyer;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<SurveyBuyerResponseDto>>> Handle(SurveyBuyersGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
                    "Survey",
                    "MetodePembayaran"
                };

            var data = await _SurveyBuyer.GetPagedReponseAsync(request, includes);
            // var dataVm = _mapper.Map<IEnumerable<SurveyBuyerResponseDto>>(data.Results);
            IEnumerable<SurveyBuyerResponseDto> dataVm;
            var listResponse = new List<SurveyBuyerResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<SurveyBuyerResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<SurveyBuyerResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}