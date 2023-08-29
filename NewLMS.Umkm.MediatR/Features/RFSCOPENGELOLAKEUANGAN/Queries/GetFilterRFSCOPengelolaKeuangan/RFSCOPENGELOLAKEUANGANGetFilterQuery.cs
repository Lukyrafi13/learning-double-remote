using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSCOPENGELOLAKEUANGANs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFSCOPENGELOLAKEUANGANs.Queries
{
    public class RFSCOPENGELOLAKEUANGANGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFSCOPENGELOLAKEUANGANResponseDto>>>
    {
    }

    public class GetFilterRFSCOPENGELOLAKEUANGANQueryHandler : IRequestHandler<RFSCOPENGELOLAKEUANGANGetFilterQuery, PagedResponse<IEnumerable<RFSCOPENGELOLAKEUANGANResponseDto>>>
    {
        private IGenericRepositoryAsync<RFSCOPENGELOLAKEUANGAN> _rfSCOPENGELOLAKEUANGAN;
        private readonly IMapper _mapper;

        public GetFilterRFSCOPENGELOLAKEUANGANQueryHandler(IGenericRepositoryAsync<RFSCOPENGELOLAKEUANGAN> rfSCOPENGELOLAKEUANGAN, IMapper mapper)
        {
            _rfSCOPENGELOLAKEUANGAN = rfSCOPENGELOLAKEUANGAN;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFSCOPENGELOLAKEUANGANResponseDto>>> Handle(RFSCOPENGELOLAKEUANGANGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfSCOPENGELOLAKEUANGAN.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFSCOPENGELOLAKEUANGANResponseDto>>(data.Results);
            IEnumerable<RFSCOPENGELOLAKEUANGANResponseDto> dataVm;
            var listResponse = new List<RFSCOPENGELOLAKEUANGANResponseDto>();

            foreach (var res in data.Results)
            {
                var response = _mapper.Map<RFSCOPENGELOLAKEUANGANResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFSCOPENGELOLAKEUANGANResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}