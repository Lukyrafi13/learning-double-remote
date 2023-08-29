// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.SlikRequestObjects;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;

// namespace NewLMS.UMKM.MediatR.Features.SlikRequestObjects.Queries
// {
//     public class SlikRequestObjectGetQuery : SlikRequestObjectFindRequestDto, IRequest<ServiceResponse<SlikRequestObjectResponseDto>>
//     {
//     }

//     public class SlikRequestObjectGetQueryHandler : IRequestHandler<SlikRequestObjectGetQuery, ServiceResponse<SlikRequestObjectResponseDto>>
//     {
//         private IGenericRepositoryAsync<SlikRequestObject> _SlikRequestObject;
//         private readonly IMapper _mapper;

//         public SlikRequestObjectGetQueryHandler(IGenericRepositoryAsync<SlikRequestObject> SlikRequestObject, IMapper mapper)
//         {
//             _SlikRequestObject = SlikRequestObject;
//             _mapper = mapper;
//         }
//         public async Task<ServiceResponse<SlikRequestObjectResponseDto>> Handle(SlikRequestObjectGetQuery request, CancellationToken cancellationToken)
//         {
//             try
//             {
//                 var includes = new string[]{
//                     "SlikRequest",
//                     "SlikRequest.App",
//                     "SlikObjectType",
//                     "FileUrl",
//                 };

//                 var data = await _SlikRequestObject.GetByIdAsync(request.Id, "Id", includes);
//                 if (data == null)
//                     return ServiceResponse<SlikRequestObjectResponseDto>.Return404("Data SlikRequestObject not found");
//                 var response = _mapper.Map<SlikRequestObjectResponseDto>(data);
//                 return ServiceResponse<SlikRequestObjectResponseDto>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<SlikRequestObjectResponseDto>.ReturnException(ex);
//             }
//         }
//     }
// }