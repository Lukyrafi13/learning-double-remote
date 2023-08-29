// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.AppContactPersons;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System.Threading;
// using System.Threading.Tasks;
// using NewLMS.UMKM.Common.GenericRespository;
// using System.Collections.Generic;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.AppContactPersons.Queries
// {
//     public class AppContactPersonsGetFilterQuery : RequestParameter, IRequest<PagedResponse<IEnumerable<AppContactPersonResponseDto>>>
//     {
//     }

//     public class GetFilterAppContactPersonQueryHandler : IRequestHandler<AppContactPersonsGetFilterQuery, PagedResponse<IEnumerable<AppContactPersonResponseDto>>>
//     {
//         private IGenericRepositoryAsync<AppContactPerson> _AppContactPerson;
//         private readonly IMapper _mapper;

//         public GetFilterAppContactPersonQueryHandler(IGenericRepositoryAsync<AppContactPerson> AppContactPerson, IMapper mapper)
//         {
//             _AppContactPerson = AppContactPerson;
//             _mapper = mapper;
//         }

//         public async Task<PagedResponse<IEnumerable<AppContactPersonResponseDto>>> Handle(AppContactPersonsGetFilterQuery request, CancellationToken cancellationToken)
//         {
//             var includes = new string[]{
//                     "App",
//                     "RFRelationCol",
//                     "RfGender",
//                 };

//             var data = await _AppContactPerson.GetPagedReponseAsync(request, includes);
//             // var dataVm = _mapper.Map<IEnumerable<AppContactPersonResponseDto>>(data.Results);
//             IEnumerable<AppContactPersonResponseDto> dataVm;
//             var listResponse = new List<AppContactPersonResponseDto>();

//             foreach (var res in data.Results){
//                 var response = _mapper.Map<AppContactPersonResponseDto>(res);

//                 listResponse.Add(response);
//             }

//             dataVm = listResponse.ToArray();
//             return new PagedResponse<IEnumerable<AppContactPersonResponseDto>>(dataVm, data.Info, request.Page, request.Length)
//             {
//                 StatusCode = (int)HttpStatusCode.OK
//             };
//         }
//     }
// }