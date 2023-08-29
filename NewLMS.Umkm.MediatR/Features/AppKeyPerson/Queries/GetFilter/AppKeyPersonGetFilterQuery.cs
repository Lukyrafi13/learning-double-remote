// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.AppKeyPersons;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System.Threading;
// using System.Threading.Tasks;
// using NewLMS.UMKM.Common.GenericRespository;
// using System.Collections.Generic;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.AppKeyPersons.Queries
// {
//     public class AppKeyPersonsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<AppKeyPersonResponseDto>>>
//     {
//     }

//     public class GetFilterAppKeyPersonQueryHandler : IRequestHandler<AppKeyPersonsGetFilterQuery, PagedResponse<IEnumerable<AppKeyPersonResponseDto>>>
//     {
//         private IGenericRepositoryAsync<AppKeyPerson> _AppKeyPerson;
//         private readonly IMapper _mapper;

//         public GetFilterAppKeyPersonQueryHandler(IGenericRepositoryAsync<AppKeyPerson> AppKeyPerson, IMapper mapper)
//         {
//             _AppKeyPerson = AppKeyPerson;
//             _mapper = mapper;
//         }

//         public async Task<PagedResponse<IEnumerable<AppKeyPersonResponseDto>>> Handle(AppKeyPersonsGetFilterQuery request, CancellationToken cancellationToken)
//         {
//             var includes = new string[]{
//                     "App",
//                     "PendidikanTerakhir",
//                     "Status",
//                     "KodePos",
//                 };

//             var data = await _AppKeyPerson.GetPagedReponseAsync(request, includes);
//             // var dataVm = _mapper.Map<IEnumerable<AppKeyPersonResponseDto>>(data.Results);
//             IEnumerable<AppKeyPersonResponseDto> dataVm;
//             var listResponse = new List<AppKeyPersonResponseDto>();

//             foreach (var res in data.Results){
//                 var response = _mapper.Map<AppKeyPersonResponseDto>(res);

//                 listResponse.Add(response);
//             }

//             dataVm = listResponse.ToArray();
//             return new PagedResponse<IEnumerable<AppKeyPersonResponseDto>>(dataVm, data.Info, request.Page, request.Length)
//             {
//                 StatusCode = (int)HttpStatusCode.OK
//             };
//         }
//     }
// }