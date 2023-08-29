// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.BiayaTetaps;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System.Threading;
// using System.Threading.Tasks;

// namespace NewLMS.UMKM.MediatR.Features.BiayaTetaps.Commands
// {
//     public class BiayaTetapDeleteCommand : BiayaTetapFindRequestDto, IRequest<ServiceResponse<Unit>>
//     {

//     }

//     public class DeleteBiayaTetapCommandHandler : IRequestHandler<BiayaTetapDeleteCommand, ServiceResponse<Unit>>
//     {
//         private readonly IGenericRepositoryAsync<BiayaTetap> _BiayaTetap;
//         private readonly IMapper _mapper;

//         public DeleteBiayaTetapCommandHandler(IGenericRepositoryAsync<BiayaTetap> BiayaTetap, IMapper mapper)
//         {
//             _BiayaTetap = BiayaTetap;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<Unit>> Handle(BiayaTetapDeleteCommand request, CancellationToken cancellationToken)
//         {
//             var rFProduct = await _BiayaTetap.GetByIdAsync(request.Id, "Id");
//             rFProduct.IsDeleted = true;
//             await _BiayaTetap.UpdateAsync(rFProduct);
//             return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
//         }
//     }
// }