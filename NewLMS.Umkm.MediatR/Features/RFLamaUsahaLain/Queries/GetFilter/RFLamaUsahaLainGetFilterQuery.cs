using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFLamaUsahaLains;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFLamaUsahaLains.Queries
{
    public class RFLamaUsahaLainsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFLamaUsahaLainResponseDto>>>
    {
    }

    public class RFLamaUsahaLainsGetFilterQueryHandler : IRequestHandler<RFLamaUsahaLainsGetFilterQuery, PagedResponse<IEnumerable<RFLamaUsahaLainResponseDto>>>
    {
        private IGenericRepositoryAsync<RFLamaUsahaLain> _RFLamaUsahaLain;
        private readonly IMapper _mapper;

        public RFLamaUsahaLainsGetFilterQueryHandler(IGenericRepositoryAsync<RFLamaUsahaLain> RFLamaUsahaLain, IMapper mapper)
        {
            _RFLamaUsahaLain = RFLamaUsahaLain;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFLamaUsahaLainResponseDto>>> Handle(RFLamaUsahaLainsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
            };

            var data = await _RFLamaUsahaLain.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFLamaUsahaLainResponseDto>>(data.Results);
            IEnumerable<RFLamaUsahaLainResponseDto> dataVm;
            var listResponse = new List<RFLamaUsahaLainResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFLamaUsahaLainResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFLamaUsahaLainResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}