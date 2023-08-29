using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.SurveySuppliers;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.SurveySuppliers.Queries
{
    public class SurveySuppliersGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<SurveySupplierResponseDto>>>
    {
    }

    public class GetFilterSurveySupplierQueryHandler : IRequestHandler<SurveySuppliersGetFilterQuery, PagedResponse<IEnumerable<SurveySupplierResponseDto>>>
    {
        private IGenericRepositoryAsync<SurveySupplier> _SurveySupplier;
        private readonly IMapper _mapper;

        public GetFilterSurveySupplierQueryHandler(IGenericRepositoryAsync<SurveySupplier> SurveySupplier, IMapper mapper)
        {
            _SurveySupplier = SurveySupplier;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<SurveySupplierResponseDto>>> Handle(SurveySuppliersGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
                    "Survey",
                    "MetodePembayaran"
                };

            var data = await _SurveySupplier.GetPagedReponseAsync(request, includes);
            // var dataVm = _mapper.Map<IEnumerable<SurveySupplierResponseDto>>(data.Results);
            IEnumerable<SurveySupplierResponseDto> dataVm;
            var listResponse = new List<SurveySupplierResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<SurveySupplierResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<SurveySupplierResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}