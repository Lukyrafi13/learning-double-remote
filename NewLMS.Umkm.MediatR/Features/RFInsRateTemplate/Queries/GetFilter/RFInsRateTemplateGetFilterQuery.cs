using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFInsRateTemplates;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFInsRateTemplates.Queries
{
    public class RFInsRateTemplatesGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFInsRateTemplateResponseDto>>>
    {
    }

    public class RFInsRateTemplatesGetFilterQueryHandler : IRequestHandler<RFInsRateTemplatesGetFilterQuery, PagedResponse<IEnumerable<RFInsRateTemplateResponseDto>>>
    {
        private IGenericRepositoryAsync<RFInsRateTemplate> _RFInsRateTemplate;
        private readonly IMapper _mapper;

        public RFInsRateTemplatesGetFilterQueryHandler(IGenericRepositoryAsync<RFInsRateTemplate> RFInsRateTemplate, IMapper mapper)
        {
            _RFInsRateTemplate = RFInsRateTemplate;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFInsRateTemplateResponseDto>>> Handle(RFInsRateTemplatesGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
            };

            var data = await _RFInsRateTemplate.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFInsRateTemplateResponseDto>>(data.Results);
            IEnumerable<RFInsRateTemplateResponseDto> dataVm;
            var listResponse = new List<RFInsRateTemplateResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFInsRateTemplateResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFInsRateTemplateResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}