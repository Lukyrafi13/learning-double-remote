using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFSCOREPUTASITEMPATTINGGALs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFSCOREPUTASITEMPATTINGGALs.Queries
{
    public class RFSCOREPUTASITEMPATTINGGALsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFSCOREPUTASITEMPATTINGGALResponseDto>>>
    {
    }

    public class GetFilterRFSCOREPUTASITEMPATTINGGALQueryHandler : IRequestHandler<RFSCOREPUTASITEMPATTINGGALsGetFilterQuery, PagedResponse<IEnumerable<RFSCOREPUTASITEMPATTINGGALResponseDto>>>
    {
        private IGenericRepositoryAsync<RFSCOREPUTASITEMPATTINGGAL> _rfScoReputasiTempatTinggal;
        private readonly IMapper _mapper;

        public GetFilterRFSCOREPUTASITEMPATTINGGALQueryHandler(IGenericRepositoryAsync<RFSCOREPUTASITEMPATTINGGAL> rfScoReputasiTempatTinggal, IMapper mapper)
        {
            _rfScoReputasiTempatTinggal = rfScoReputasiTempatTinggal;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFSCOREPUTASITEMPATTINGGALResponseDto>>> Handle(RFSCOREPUTASITEMPATTINGGALsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfScoReputasiTempatTinggal.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFSCOREPUTASITEMPATTINGGALResponseDto>>(data.Results);
            IEnumerable<RFSCOREPUTASITEMPATTINGGALResponseDto> dataVm;
            var listResponse = new List<RFSCOREPUTASITEMPATTINGGALResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFSCOREPUTASITEMPATTINGGALResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFSCOREPUTASITEMPATTINGGALResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}