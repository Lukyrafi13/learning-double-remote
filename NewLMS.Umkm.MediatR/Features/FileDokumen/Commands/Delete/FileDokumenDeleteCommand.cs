// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.FileDokumens;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.FileDokumens.Commands
// {
//     public class FileDokumenDeleteCommand : FileDokumenFindRequestDto, IRequest<ServiceResponse<Unit>>
//     {
        
//     }

//     public class DeleteFileDokumenCommandHandler : IRequestHandler<FileDokumenDeleteCommand, ServiceResponse<Unit>>
//     {
//         private readonly IGenericRepositoryAsync<FileDokumen> _FileDokumen;
//         private readonly IMapper _mapper;

//         public DeleteFileDokumenCommandHandler(IGenericRepositoryAsync<FileDokumen> FileDokumen, IMapper mapper){
//             _FileDokumen = FileDokumen;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<Unit>> Handle(FileDokumenDeleteCommand request, CancellationToken cancellationToken)
//         {
//             var rFProduct = await _FileDokumen.GetByIdAsync(request.Id, "Id");
//             rFProduct.IsDeleted = true;
//             await _FileDokumen.UpdateAsync(rFProduct);
//             return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
//         }
//     }
// }