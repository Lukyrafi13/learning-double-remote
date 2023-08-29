// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.InformasiOmsets;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System.Threading;
// using System.Threading.Tasks;
// using NewLMS.UMKM.Common.GenericRespository;
// using System.Collections.Generic;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.InformasiOmsets.Queries
// {
//     public class InformasiOmsetsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<InformasiOmsetResponseDto>>>
//     {
//     }

//     public class GetFilterInformasiOmsetQueryHandler : IRequestHandler<InformasiOmsetsGetFilterQuery, PagedResponse<IEnumerable<InformasiOmsetResponseDto>>>
//     {
//         private IGenericRepositoryAsync<InformasiOmset> _InformasiOmset;
//         private readonly IMapper _mapper;

//         public GetFilterInformasiOmsetQueryHandler(IGenericRepositoryAsync<InformasiOmset> InformasiOmset, IMapper mapper)
//         {
//             _InformasiOmset = InformasiOmset;
//             _mapper = mapper;
//         }

//         public async Task<PagedResponse<IEnumerable<InformasiOmsetResponseDto>>> Handle(InformasiOmsetsGetFilterQuery request, CancellationToken cancellationToken)
//         {
//             var data = await _InformasiOmset.GetPagedReponseAsync(request);
//             // var dataVm = _mapper.Map<IEnumerable<InformasiOmsetResponseDto>>(data.Results);
//             IEnumerable<InformasiOmsetResponseDto> dataVm;
//             var listResponse = new List<InformasiOmsetResponseDto>();

//             foreach (var res in data.Results)
//             {
//                 var response = _mapper.Map<InformasiOmsetResponseDto>(res);

//                 listResponse.Add(response);
//             }

//             dataVm = listResponse.ToArray();
//             return new PagedResponse<IEnumerable<InformasiOmsetResponseDto>>(dataVm, data.Info, request.Page, request.Length)
//             {
//                 StatusCode = (int)HttpStatusCode.OK
//             };
//         }
//     }
// }