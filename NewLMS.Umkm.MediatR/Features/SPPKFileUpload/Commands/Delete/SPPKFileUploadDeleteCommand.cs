// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.SPPKFileUploads;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.SPPKFileUploads.Commands
// {
//     public class SPPKFileUploadDeleteCommand : SPPKFileUploadFindRequestDto, IRequest<ServiceResponse<Unit>>
//     {

//     }

//     public class DeleteSPPKFileUploadCommandHandler : IRequestHandler<SPPKFileUploadDeleteCommand, ServiceResponse<Unit>>
//     {
//         private readonly IGenericRepositoryAsync<SPPKFileUpload> _SPPKFileUpload;
//         private readonly IMapper _mapper;

//         public DeleteSPPKFileUploadCommandHandler(IGenericRepositoryAsync<SPPKFileUpload> SPPKFileUpload, IMapper mapper)
//         {
//             _SPPKFileUpload = SPPKFileUpload;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<Unit>> Handle(SPPKFileUploadDeleteCommand request, CancellationToken cancellationToken)
//         {
//             var rFProduct = await _SPPKFileUpload.GetByIdAsync(request.Id, "Id");
//             rFProduct.IsDeleted = true;
//             await _SPPKFileUpload.UpdateAsync(rFProduct);
//             return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
//         }
//     }
// }