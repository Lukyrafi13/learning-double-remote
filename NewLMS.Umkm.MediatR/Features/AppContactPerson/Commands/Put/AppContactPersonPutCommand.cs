// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.AppContactPersons;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.AppContactPersons.Commands
// {
//     public class AppContactPersonPutCommand : AppContactPersonPutRequestDto, IRequest<ServiceResponse<AppContactPersonResponseDto>>
//     {
//     }

//     public class PutAppContactPersonCommandHandler : IRequestHandler<AppContactPersonPutCommand, ServiceResponse<AppContactPersonResponseDto>>
//     {
//         private readonly IGenericRepositoryAsync<AppContactPerson> _AppContactPerson;
//         private readonly IMapper _mapper;

//         public PutAppContactPersonCommandHandler(IGenericRepositoryAsync<AppContactPerson> AppContactPerson, IMapper mapper)
//         {
//             _AppContactPerson = AppContactPerson;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<AppContactPersonResponseDto>> Handle(AppContactPersonPutCommand request, CancellationToken cancellationToken)
//         {
//             try
//             {
//                 var existingAppContactPerson = await _AppContactPerson.GetByIdAsync(request.Id, "Id");
//                 existingAppContactPerson.Nama = request.Nama;
//                 existingAppContactPerson.NomorHandphone = request.NomorHandphone;
//                 existingAppContactPerson.AlamatEmail = request.AlamatEmail;
//                 existingAppContactPerson.AppId = request.AppId;
//                 existingAppContactPerson.RFRelationColId = request.RFRelationColId;
//                 existingAppContactPerson.RfGenderId = request.RfGenderId;

//                 await _AppContactPerson.UpdateAsync(existingAppContactPerson);

//                 var response = _mapper.Map<AppContactPersonResponseDto>(existingAppContactPerson);

//                 return ServiceResponse<AppContactPersonResponseDto>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<AppContactPersonResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
//             }
//         }
//     }
// }