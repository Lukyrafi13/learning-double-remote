// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.AppKeyPersons;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;

// namespace NewLMS.UMKM.MediatR.Features.AppKeyPersons.Queries
// {
//     public class AppKeyPersonGetQuery : AppKeyPersonFindRequestDto, IRequest<ServiceResponse<AppKeyPersonResponseDto>>
//     {
//     }

//     public class AppKeyPersonGetQueryHandler : IRequestHandler<AppKeyPersonGetQuery, ServiceResponse<AppKeyPersonResponseDto>>
//     {
//         private IGenericRepositoryAsync<AppKeyPerson> _AppKeyPerson;
//         private readonly IMapper _mapper;

//         public AppKeyPersonGetQueryHandler(IGenericRepositoryAsync<AppKeyPerson> AppKeyPerson, IMapper mapper)
//         {
//             _AppKeyPerson = AppKeyPerson;
//             _mapper = mapper;
//         }
//         public async Task<ServiceResponse<AppKeyPersonResponseDto>> Handle(AppKeyPersonGetQuery request, CancellationToken cancellationToken)
//         {
//             try
//             {
//                 var includes = new string[]{
//                     "App",
//                     "PendidikanTerakhir",
//                     "Status",
//                     "KodePos",
//                 };

//                 var data = await _AppKeyPerson.GetByIdAsync(request.Id, "Id", includes);
//                 if (data == null)
//                     return ServiceResponse<AppKeyPersonResponseDto>.Return404("Data AppKeyPerson not found");
//                 var response = _mapper.Map<AppKeyPersonResponseDto>(data);
//                 return ServiceResponse<AppKeyPersonResponseDto>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<AppKeyPersonResponseDto>.ReturnException(ex);
//             }
//         }
//     }
// }