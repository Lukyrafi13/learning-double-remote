// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.SurveyFileUploads;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System.Threading;
// using System.Threading.Tasks;
// using NewLMS.UMKM.Common.GenericRespository;
// using System.Collections.Generic;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.SurveyFileUploads.Queries
// {
//     public class SurveyFileUploadsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<SurveyFileUploadResponseDto>>>
//     {
//     }

//     public class GetFilterSurveyFileUploadQueryHandler : IRequestHandler<SurveyFileUploadsGetFilterQuery, PagedResponse<IEnumerable<SurveyFileUploadResponseDto>>>
//     {
//         private IGenericRepositoryAsync<SurveyFileUpload> _SurveyFileUpload;
//         private readonly IMapper _mapper;

//         public GetFilterSurveyFileUploadQueryHandler(IGenericRepositoryAsync<SurveyFileUpload> SurveyFileUpload, IMapper mapper)
//         {
//             _SurveyFileUpload = SurveyFileUpload;
//             _mapper = mapper;
//         }

//         public async Task<PagedResponse<IEnumerable<SurveyFileUploadResponseDto>>> Handle(SurveyFileUploadsGetFilterQuery request, CancellationToken cancellationToken)
//         {
//             var includes = new string[]{
//                     "Survey",
//                     "FileUrl",
//                 };

//             var data = await _SurveyFileUpload.GetPagedReponseAsync(request, includes);
//             // var dataVm = _mapper.Map<IEnumerable<SurveyFileUploadResponseDto>>(data.Results);
//             IEnumerable<SurveyFileUploadResponseDto> dataVm;
//             var listResponse = new List<SurveyFileUploadResponseDto>();

//             foreach (var res in data.Results){
//                 var response = _mapper.Map<SurveyFileUploadResponseDto>(res);

//                 listResponse.Add(response);
//             }

//             dataVm = listResponse.ToArray();
//             return new PagedResponse<IEnumerable<SurveyFileUploadResponseDto>>(dataVm, data.Info, request.Page, request.Length)
//             {
//                 StatusCode = (int)HttpStatusCode.OK
//             };
//         }
//     }
// }