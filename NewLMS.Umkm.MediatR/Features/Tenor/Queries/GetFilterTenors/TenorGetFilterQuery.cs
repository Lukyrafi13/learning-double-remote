// using AutoMapper;
// using MediatR;
// using NewLMS.Umkm.Data.Dto.Tenors;
// using NewLMS.Umkm.Data;
// using NewLMS.Umkm.Repository.GenericRepository;
// using System.Threading;
// using System.Threading.Tasks;
// using NewLMS.Umkm.Common.GenericRespository;
// using System.Collections.Generic;
// using System.Net;

// namespace NewLMS.Umkm.MediatR.Features.Tenors.Queries
// {
//     public class TenorsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<TenorResponseDto>>>
//     {
//     }

//     public class GetFilterTenorQueryHandler : IRequestHandler<TenorsGetFilterQuery, PagedResponse<IEnumerable<TenorResponseDto>>>
//     {
//         private IGenericRepositoryAsync<Tenor> _Tenor;
//         private readonly IMapper _mapper;

//         public GetFilterTenorQueryHandler(IGenericRepositoryAsync<Tenor> Tenor, IMapper mapper)
//         {
//             _Tenor = Tenor;
//             _mapper = mapper;
//         }

//         public async Task<PagedResponse<IEnumerable<TenorResponseDto>>> Handle(TenorsGetFilterQuery request, CancellationToken cancellationToken)
//         {
//             var data = await _Tenor.GetPagedReponseAsync(request);
//             // var dataVm = _mapper.Map<IEnumerable<TenorResponseDto>>(data.Results);
//             IEnumerable<TenorResponseDto> dataVm;
//             var listResponse = new List<TenorResponseDto>();

//             foreach (var res in data.Results){
//                 var response = _mapper.Map<TenorResponseDto>(res);

//                 listResponse.Add(response);
//             }

//             dataVm = listResponse.ToArray();
//             return new PagedResponse<IEnumerable<TenorResponseDto>>(dataVm, data.Info, request.Page, request.Length)
//             {
//                 StatusCode = (int)HttpStatusCode.OK
//             };
//         }
//     }
// }