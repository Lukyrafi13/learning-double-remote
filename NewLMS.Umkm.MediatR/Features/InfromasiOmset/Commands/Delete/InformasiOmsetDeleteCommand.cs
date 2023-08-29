// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.InformasiOmsets;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System.Threading;
// using System.Threading.Tasks;

// namespace NewLMS.UMKM.MediatR.Features.InformasiOmsets.Commands
// {
//     public class InformasiOmsetDeleteCommand : InformasiOmsetFindRequestDto, IRequest<ServiceResponse<Unit>>
//     {

//     }

//     public class DeleteInformasiOmsetCommandHandler : IRequestHandler<InformasiOmsetDeleteCommand, ServiceResponse<Unit>>
//     {
//         private readonly IGenericRepositoryAsync<InformasiOmset> _InformasiOmset;
//         private readonly IMapper _mapper;

//         public DeleteInformasiOmsetCommandHandler(IGenericRepositoryAsync<InformasiOmset> InformasiOmset, IMapper mapper)
//         {
//             _InformasiOmset = InformasiOmset;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<Unit>> Handle(InformasiOmsetDeleteCommand request, CancellationToken cancellationToken)
//         {
//             var rFProduct = await _InformasiOmset.GetByIdAsync(request.Id, "Id");
//             rFProduct.IsDeleted = true;
//             await _InformasiOmset.UpdateAsync(rFProduct);
//             return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
//         }
//     }
// }