// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.FileDokumens;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System.Threading;
// using System.Threading.Tasks;
// using NewLMS.UMKM.Common.GenericRespository;
// using System.Collections.Generic;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.FileDokumens.Queries
// {
//     public class FileDokumensGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<FileDokumenResponseDto>>>
//     {
//     }

//     public class GetFilterFileDokumenQueryHandler : IRequestHandler<FileDokumensGetFilterQuery, PagedResponse<IEnumerable<FileDokumenResponseDto>>>
//     {
//         private IGenericRepositoryAsync<FileDokumen> _FileDokumen;
//         private readonly IMapper _mapper;

//         public GetFilterFileDokumenQueryHandler(IGenericRepositoryAsync<FileDokumen> FileDokumen, IMapper mapper)
//         {
//             _FileDokumen = FileDokumen;
//             _mapper = mapper;
//         }

//         public async Task<PagedResponse<IEnumerable<FileDokumenResponseDto>>> Handle(FileDokumensGetFilterQuery request, CancellationToken cancellationToken)
//         {
//             var includes = new string[]{
//                 "PrescreeningDokumen",
//                 "FileUrl",
//             };

//             var data = await _FileDokumen.GetPagedReponseAsync(request, includes);
//             // var dataVm = _mapper.Map<IEnumerable<FileDokumenResponseDto>>(data.Results);
//             IEnumerable<FileDokumenResponseDto> dataVm;
//             var listResponse = new List<FileDokumenResponseDto>();

//             foreach (var res in data.Results){
//                 var response = _mapper.Map<FileDokumenResponseDto>(res);

//                 listResponse.Add(response);
//             }

//             dataVm = listResponse.ToArray();
//             return new PagedResponse<IEnumerable<FileDokumenResponseDto>>(dataVm, data.Info, request.Page, request.Length)
//             {
//                 StatusCode = (int)HttpStatusCode.OK
//             };
//         }
//     }
// }