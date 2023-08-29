// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.BiayaVariabels;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System.Threading;
// using System.Threading.Tasks;

// namespace NewLMS.UMKM.MediatR.Features.BiayaVariabels.Commands
// {
//     public class BiayaVariabelDeleteCommand : BiayaVariabelFindRequestDto, IRequest<ServiceResponse<Unit>>
//     {

//     }

//     public class DeleteBiayaVariabelCommandHandler : IRequestHandler<BiayaVariabelDeleteCommand, ServiceResponse<Unit>>
//     {
//         private readonly IGenericRepositoryAsync<BiayaVariabel> _BiayaVariabel;
//         private readonly IMapper _mapper;

//         public DeleteBiayaVariabelCommandHandler(IGenericRepositoryAsync<BiayaVariabel> BiayaVariabel, IMapper mapper)
//         {
//             _BiayaVariabel = BiayaVariabel;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<Unit>> Handle(BiayaVariabelDeleteCommand request, CancellationToken cancellationToken)
//         {
//             var rFProduct = await _BiayaVariabel.GetByIdAsync(request.Id, "Id");
//             rFProduct.IsDeleted = true;
//             await _BiayaVariabel.UpdateAsync(rFProduct);
//             return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
//         }
//     }
// }