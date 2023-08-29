using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFStatusTargets;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFStatusTargets.Queries
{
    public class RFStatusTargetsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFStatusTargetResponseDto>>>
    {
    }

    public class GetFilterRFStatusTargetQueryHandler : IRequestHandler<RFStatusTargetsGetFilterQuery, PagedResponse<IEnumerable<RFStatusTargetResponseDto>>>
    {
        private IGenericRepositoryAsync<RFStatusTarget> _rfStatusTarget;
        private readonly IMapper _mapper;

        public GetFilterRFStatusTargetQueryHandler(IGenericRepositoryAsync<RFStatusTarget> rfStatusTarget, IMapper mapper)
        {
            _rfStatusTarget = rfStatusTarget;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFStatusTargetResponseDto>>> Handle(RFStatusTargetsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var data = await _rfStatusTarget.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFStatusTargetResponseDto>>(data.Results);
            IEnumerable<RFStatusTargetResponseDto> dataVm;
            var listResponse = new List<RFStatusTargetResponseDto>();

            foreach (var res in data.Results){
                var response = new RFStatusTargetResponseDto();
                
                response.Id = res.Id;
                response.Active = res.Active;
                response.StatusCode = res.StatusCode;
                response.StatusDesc = res.StatusDesc;

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFStatusTargetResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}