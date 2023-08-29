// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.ArusKasMasuks;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System.Threading;
// using System.Threading.Tasks;

// namespace NewLMS.UMKM.MediatR.Features.ArusKasMasuks.Commands
// {
//     public class ArusKasMasukDeleteCommand : ArusKasMasukFindRequestDto, IRequest<ServiceResponse<Unit>>
//     {

//     }

//     public class DeleteArusKasMasukCommandHandler : IRequestHandler<ArusKasMasukDeleteCommand, ServiceResponse<Unit>>
//     {
//         private readonly IGenericRepositoryAsync<ArusKasMasuk> _ArusKasMasuk;
//         private readonly IMapper _mapper;

//         public DeleteArusKasMasukCommandHandler(IGenericRepositoryAsync<ArusKasMasuk> ArusKasMasuk, IMapper mapper)
//         {
//             _ArusKasMasuk = ArusKasMasuk;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<Unit>> Handle(ArusKasMasukDeleteCommand request, CancellationToken cancellationToken)
//         {
//             var rFProduct = await _ArusKasMasuk.GetByIdAsync(request.Id, "Id");
//             rFProduct.IsDeleted = true;
//             await _ArusKasMasuk.UpdateAsync(rFProduct);
//             return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
//         }
//     }
// }