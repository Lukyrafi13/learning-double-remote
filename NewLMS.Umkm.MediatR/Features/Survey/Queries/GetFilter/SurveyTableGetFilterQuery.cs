// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.Surveys;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System.Threading;
// using System.Threading.Tasks;
// using NewLMS.UMKM.Common.GenericRespository;
// using System.Collections.Generic;
// using System.Net;
// using System;

// namespace NewLMS.UMKM.MediatR.Features.Surveys.Queries
// {
//     public class SurveyTableGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<SurveyTableResponse>>>
//     {
//     }

//     public class SurveyTableGetFilterQueryHandler : IRequestHandler<SurveyTableGetFilterQuery, PagedResponse<IEnumerable<SurveyTableResponse>>>
//     {
//         private IGenericRepositoryAsync<Survey> _Survey;
//         private IGenericRepositoryAsync<ProspectStageLogs> _ProspectStageLogs;
//         private readonly IMapper _mapper;

//         public SurveyTableGetFilterQueryHandler(
//                 IGenericRepositoryAsync<Survey> Survey,
//                 IGenericRepositoryAsync<ProspectStageLogs> ProspectStageLogs,
//                 IMapper mapper
//             )
//         {
//             _Survey = Survey;
//             _ProspectStageLogs = ProspectStageLogs;
//             _mapper = mapper;
//         }

//         public async Task<PagedResponse<IEnumerable<SurveyTableResponse>>> Handle(SurveyTableGetFilterQuery request, CancellationToken cancellationToken)
//         {
//             var includes = new string[]{
//                 "App",
//                 "App.KodePos",
//                 "App.JenisProduk",
//                 "App.BookingOffice",
//                 "App.Prospect",
//                 "App.Prospect.ProspectStageLogs",
//                 "App.Prospect.ProspectStageLogs.RFStages",
//             };

//             var data = await _Survey.GetPagedReponseAsync(request, includes);
//             // var dataVm = _mapper.Map<IEnumerable<SurveyTableResponse>>(data.Results);
//             IEnumerable<SurveyTableResponse> dataVm;
//             var listResponse = new List<SurveyTableResponse>();

//             foreach (var res in data.Results){
//                 var response = new SurveyTableResponse();

//                 response.Id = res.Id;

//                 response.TanggalRequest = DateTime.Now;
//                 response.StatusSLIK = "1/1";

//                 response.App = res.App;
//                 response.Age = res.Age;
//                 response.InformasiOmsetId = res.InformasiOmset?.Id;
                
//                 listResponse.Add(response);
//             }

//             dataVm = listResponse.ToArray();
//             return new PagedResponse<IEnumerable<SurveyTableResponse>>(dataVm, data.Info, request.Page, request.Length)
//             {
//                 StatusCode = (int)HttpStatusCode.OK
//             };
//         }
//     }
// }