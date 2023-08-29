using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFInsCompanys;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFInsCompanys.Queries
{
    public class RFInsCompanysGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFInsCompanyResponseDto>>>
    {
    }

    public class RFInsCompanysGetFilterQueryHandler : IRequestHandler<RFInsCompanysGetFilterQuery, PagedResponse<IEnumerable<RFInsCompanyResponseDto>>>
    {
        private IGenericRepositoryAsync<RFInsCompany> _RFInsCompany;
        private readonly IMapper _mapper;

        public RFInsCompanysGetFilterQueryHandler(IGenericRepositoryAsync<RFInsCompany> RFInsCompany, IMapper mapper)
        {
            _RFInsCompany = RFInsCompany;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFInsCompanyResponseDto>>> Handle(RFInsCompanysGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
            };

            var data = await _RFInsCompany.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFInsCompanyResponseDto>>(data.Results);
            IEnumerable<RFInsCompanyResponseDto> dataVm;
            var listResponse = new List<RFInsCompanyResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFInsCompanyResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFInsCompanyResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}