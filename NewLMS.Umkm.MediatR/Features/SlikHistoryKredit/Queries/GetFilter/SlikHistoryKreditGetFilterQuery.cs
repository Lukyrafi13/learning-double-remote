using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.SlikHistoryKredits;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.SlikHistoryKredits.Queries
{
    public class SlikHistoryKreditsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<SlikHistoryKreditResponseDto>>>
    {
    }

    public class GetFilterSlikHistoryKreditQueryHandler : IRequestHandler<SlikHistoryKreditsGetFilterQuery, PagedResponse<IEnumerable<SlikHistoryKreditResponseDto>>>
    {
        private IGenericRepositoryAsync<SlikHistoryKredit> _SlikHistoryKredit;
        private readonly IMapper _mapper;

        public GetFilterSlikHistoryKreditQueryHandler(IGenericRepositoryAsync<SlikHistoryKredit> SlikHistoryKredit, IMapper mapper)
        {
            _SlikHistoryKredit = SlikHistoryKredit;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<SlikHistoryKreditResponseDto>>> Handle(SlikHistoryKreditsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
                "RfCreditType",
                "RfSandiBIEconomySectorClass",
                "RfSandiBIBehaviourClass",
                "RfSandiBIApplicationTypeClass",
                "RfSandiBICollectibilityClass",
                "RfCondition",
                "SlikRequest",
                "SlikObjectType",
            };

            var data = await _SlikHistoryKredit.GetPagedReponseAsync(request, includes);
            // var dataVm = _mapper.Map<IEnumerable<SlikHistoryKreditResponseDto>>(data.Results);
            IEnumerable<SlikHistoryKreditResponseDto> dataVm;
            var listResponse = new List<SlikHistoryKreditResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<SlikHistoryKreditResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<SlikHistoryKreditResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}