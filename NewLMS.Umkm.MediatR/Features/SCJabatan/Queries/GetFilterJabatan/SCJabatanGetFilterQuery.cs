using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.SCJabatans;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.SCJabatans.Queries
{
    public class SCJabatanGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<SCJabatanResponseDto>>>
    {
    }

    public class GetFilterSCJabatanQueryHandler : IRequestHandler<SCJabatanGetFilterQuery, PagedResponse<IEnumerable<SCJabatanResponseDto>>>
    {
        private IGenericRepositoryAsync<SCJabatan> _SCJabatan;
        private readonly IMapper _mapper;

        public GetFilterSCJabatanQueryHandler(IGenericRepositoryAsync<SCJabatan> SCJabatan, IMapper mapper)
        {
            _SCJabatan = SCJabatan;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<SCJabatanResponseDto>>> Handle(SCJabatanGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _SCJabatan.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<SCJabatanResponseDto>>(data.Results);
            IEnumerable<SCJabatanResponseDto> dataVm;
            var listResponse = new List<SCJabatanResponseDto>();

            foreach (var gender in data.Results)
            {
                var response = new SCJabatanResponseDto();

                response.Id = gender.Id;
                response.JAB_CODE = gender.JAB_CODE;
                response.JAB_DESC = gender.JAB_DESC;
                response.SK_CODE = gender.SK_CODE;
                response.CORE_CODE = gender.CORE_CODE;
                response.ACTIVE = gender.ACTIVE;
                response.SK_LIMIT_CODE = gender.SK_LIMIT_CODE;

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<SCJabatanResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}