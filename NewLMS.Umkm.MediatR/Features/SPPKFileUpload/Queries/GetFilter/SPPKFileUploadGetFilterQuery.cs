// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.SPPKFileUploads;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System.Threading;
// using System.Threading.Tasks;
// using NewLMS.UMKM.Common.GenericRespository;
// using System.Collections.Generic;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.SPPKFileUploads.Queries
// {
//     public class SPPKFileUploadsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<SPPKFileUploadResponseDto>>>
//     {
//     }

//     public class GetFilterSPPKFileUploadQueryHandler : IRequestHandler<SPPKFileUploadsGetFilterQuery, PagedResponse<IEnumerable<SPPKFileUploadResponseDto>>>
//     {
//         private IGenericRepositoryAsync<SPPKFileUpload> _SPPKFileUpload;
//         private readonly IMapper _mapper;

//         public GetFilterSPPKFileUploadQueryHandler(IGenericRepositoryAsync<SPPKFileUpload> SPPKFileUpload, IMapper mapper)
//         {
//             _SPPKFileUpload = SPPKFileUpload;
//             _mapper = mapper;
//         }

//         public async Task<PagedResponse<IEnumerable<SPPKFileUploadResponseDto>>> Handle(SPPKFileUploadsGetFilterQuery request, CancellationToken cancellationToken)
//         {
//             var includes = new string[]{
//                     "SPPK",
//                     "FileUrl",
//                 };

//             var data = await _SPPKFileUpload.GetPagedReponseAsync(request, includes);
//             // var dataVm = _mapper.Map<IEnumerable<SPPKFileUploadResponseDto>>(data.Results);
//             IEnumerable<SPPKFileUploadResponseDto> dataVm;
//             var listResponse = new List<SPPKFileUploadResponseDto>();

//             foreach (var res in data.Results)
//             {
//                 var response = _mapper.Map<SPPKFileUploadResponseDto>(res);

//                 listResponse.Add(response);
//             }

//             dataVm = listResponse.ToArray();
//             return new PagedResponse<IEnumerable<SPPKFileUploadResponseDto>>(dataVm, data.Info, request.Page, request.Length)
//             {
//                 StatusCode = (int)HttpStatusCode.OK
//             };
//         }
//     }
// }