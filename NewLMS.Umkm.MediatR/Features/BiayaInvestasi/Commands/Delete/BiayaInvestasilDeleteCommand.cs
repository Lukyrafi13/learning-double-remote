// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.BiayaInvestasis;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System.Threading;
// using System.Threading.Tasks;

// namespace NewLMS.UMKM.MediatR.Features.BiayaInvestasis.Commands
// {
//     public class BiayaInvestasiDeleteCommand : BiayaInvestasiFindRequestDto, IRequest<ServiceResponse<Unit>>
//     {

//     }

//     public class DeleteBiayaInvestasiCommandHandler : IRequestHandler<BiayaInvestasiDeleteCommand, ServiceResponse<Unit>>
//     {
//         private readonly IGenericRepositoryAsync<BiayaInvestasi> _BiayaInvestasi;
//         private readonly IMapper _mapper;

//         public DeleteBiayaInvestasiCommandHandler(IGenericRepositoryAsync<BiayaInvestasi> BiayaInvestasi, IMapper mapper)
//         {
//             _BiayaInvestasi = BiayaInvestasi;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<Unit>> Handle(BiayaInvestasiDeleteCommand request, CancellationToken cancellationToken)
//         {
//             var rFProduct = await _BiayaInvestasi.GetByIdAsync(request.Id, "Id");
//             rFProduct.IsDeleted = true;
//             await _BiayaInvestasi.UpdateAsync(rFProduct);
//             return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
//         }
//     }
// }