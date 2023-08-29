using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFRejects;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.Umkm.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFRejects.Queries
{
    public class RFRejectsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<RFRejectResponseDto>>>
    {
    }

    public class RFRejectsGetFilterQueryHandler : IRequestHandler<RFRejectsGetFilterQuery, PagedResponse<IEnumerable<RFRejectResponseDto>>>
    {
        private IGenericRepositoryAsync<RFReject> _RFReject;
        private readonly IMapper _mapper;

        public RFRejectsGetFilterQueryHandler(IGenericRepositoryAsync<RFReject> RFReject, IMapper mapper)
        {
            _RFReject = RFReject;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<RFRejectResponseDto>>> Handle(RFRejectsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
            };

            var data = await _RFReject.GetPagedReponseAsync(request);
            // var dataVm = _mapper.Map<IEnumerable<RFRejectResponseDto>>(data.Results);
            IEnumerable<RFRejectResponseDto> dataVm;
            var listResponse = new List<RFRejectResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<RFRejectResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<RFRejectResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}