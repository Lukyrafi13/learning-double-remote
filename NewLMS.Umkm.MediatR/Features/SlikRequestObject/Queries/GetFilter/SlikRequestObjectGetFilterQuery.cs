using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.SlikRequestObjects;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Repository.GenericRepository;
using System.Threading;
using System.Threading.Tasks;
using NewLMS.UMKM.Common.GenericRespository;
using System.Collections.Generic;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.SlikRequestObjects.Queries
{
    public class SlikRequestObjectsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<SlikRequestObjectResponseDto>>>
    {
    }

    public class GetFilterSlikRequestObjectQueryHandler : IRequestHandler<SlikRequestObjectsGetFilterQuery, PagedResponse<IEnumerable<SlikRequestObjectResponseDto>>>
    {
        private IGenericRepositoryAsync<SlikRequestObject> _SlikRequestObject;
        private readonly IMapper _mapper;

        public GetFilterSlikRequestObjectQueryHandler(IGenericRepositoryAsync<SlikRequestObject> SlikRequestObject, IMapper mapper)
        {
            _SlikRequestObject = SlikRequestObject;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<SlikRequestObjectResponseDto>>> Handle(SlikRequestObjectsGetFilterQuery request, CancellationToken cancellationToken)
        {
            var includes = new string[]{
                "SlikRequest",
                "SlikRequest.LoanApplication",
                "SlikObjectType",
                "FileUrl",
            };

            var data = await _SlikRequestObject.GetPagedReponseAsync(request, includes);
            // var dataVm = _mapper.Map<IEnumerable<SlikRequestObjectResponseDto>>(data.Results);
            IEnumerable<SlikRequestObjectResponseDto> dataVm;
            var listResponse = new List<SlikRequestObjectResponseDto>();

            foreach (var res in data.Results){
                var response = _mapper.Map<SlikRequestObjectResponseDto>(res);

                listResponse.Add(response);
            }

            dataVm = listResponse.ToArray();
            return new PagedResponse<IEnumerable<SlikRequestObjectResponseDto>>(dataVm, data.Info, request.Page, request.Length)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}