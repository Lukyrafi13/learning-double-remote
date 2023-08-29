// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.SPPKs;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.SPPKs.Commands
// {
//     public class SPPKHalamanUtamaPutCommand : SPPKHalamanUtamaPut, IRequest<ServiceResponse<SPPKHalamanUtamaResponse>>
//     {
//     }

//     public class SPPKHalamanUtamaPutCommandHandler : IRequestHandler<SPPKHalamanUtamaPutCommand, ServiceResponse<SPPKHalamanUtamaResponse>>
//     {
//         private readonly IGenericRepositoryAsync<SPPK> _SPPK;
//         private readonly IMapper _mapper;

//         public SPPKHalamanUtamaPutCommandHandler(IGenericRepositoryAsync<SPPK> SPPK, IMapper mapper)
//         {
//             _SPPK = SPPK;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<SPPKHalamanUtamaResponse>> Handle(SPPKHalamanUtamaPutCommand request, CancellationToken cancellationToken)
//         {
//             try
//             {
//                 var existingSPPK = await _SPPK.GetByIdAsync(request.Id, "Id");
                
//                 var updatedSPPK = _mapper.Map<SPPKHalamanUtamaPut, SPPK>(request, existingSPPK);

//                 await _SPPK.UpdateAsync(updatedSPPK);

//                 var response = _mapper.Map<SPPKHalamanUtamaResponse>(existingSPPK);

//                 return ServiceResponse<SPPKHalamanUtamaResponse>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<SPPKHalamanUtamaResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
//             }
//         }
//     }
// }