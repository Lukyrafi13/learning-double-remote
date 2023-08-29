using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RfAppTypes;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RfAppTypes.Queries
{
    public class RfAppTypesGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RfAppTypeResponseDto>>>
    {
    }

    public class GetFilterRfAppTypeQueryHandler : IRequestHandler<RfAppTypesGetFilterQuery, PagedResponse<IEnumerable<RfAppTypeResponseDto>>>
    {
        private IGenericRepositoryAsync<RfAppType> _rfJenisPermohonan;
        private readonly IMapper _mapper;

        public GetFilterRfAppTypeQueryHandler(IGenericRepositoryAsync<RfAppType> rfJenisPermohonan, IMapper mapper)
        {
            _rfJenisPermohonan = rfJenisPermohonan;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RfAppTypeResponseDto>>> Handle(RfAppTypesGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfJenisPermohonan.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RfAppTypeResponseDto>>(data.Results);
            IEnumerable<RfAppTypeResponseDto> dataVm;
            var listResponse = new List<RfAppTypeResponseDto>();

            foreach (var permohonan in data.Results){

                var response = _mapper.Map<RfAppTypeResponseDto>(permohonan);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RfAppTypeResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}