// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.SlikRequestDuplikasis;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System.Threading;
// using System.Threading.Tasks;
// using NewLMS.UMKM.Common.GenericRespository;
// using System.Collections.Generic;
// using System.Net;
// using NewLMS.UMKM.Data.Dto.MSearchs;

// namespace NewLMS.UMKM.MediatR.Features.SlikRequestDuplikasis.Queries
// {
//     public class SlikRequestDuplikasisGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<MSearchResponse>>>
//     {
//     }

//     public class SlikRequestDuplikasisGetFilterQueryHandler : IRequestHandler<SlikRequestDuplikasisGetFilterQuery, PagedResponse<IEnumerable<MSearchResponse>>>
//     {
//         private IGenericRepositoryAsync<SlikRequestDuplikasi> _SlikRequestDuplikasi;
//         private readonly IMapper _mapper;

//         public SlikRequestDuplikasisGetFilterQueryHandler(IGenericRepositoryAsync<SlikRequestDuplikasi> SlikRequestDuplikasi, IMapper mapper)
//         {
//             _SlikRequestDuplikasi = SlikRequestDuplikasi;
//             _mapper = mapper;
//         }

//         public async Task<PagedResponse<IEnumerable<MSearchResponse>>> Handle(SlikRequestDuplikasisGetFilterQuery request, CancellationToken cancellationToken)
//         {
//             var includes = new string[] {
//             };
//             var data = await _SlikRequestDuplikasi.GetPagedReponseAsync(request, includes);
//             // var dataVm = _mapper.Map<IEnumerable<MSearchResponse>>(data.Results);
//             IEnumerable<MSearchResponse> dataVm;
//             var listResponse = new List<MSearchResponse>();

//             foreach (var res in data.Results)
//             {
//                 var response = _mapper.Map<MSearchResponse>(res);

//                 listResponse.Add(response);
//             }

//             dataVm = listResponse.ToArray();
//             return new PagedResponse<IEnumerable<MSearchResponse>>(dataVm, data.Info, request.Page, request.Length)
//             {
//                 StatusCode = (int)HttpStatusCode.OK
//             };
//         }
//     }
// }