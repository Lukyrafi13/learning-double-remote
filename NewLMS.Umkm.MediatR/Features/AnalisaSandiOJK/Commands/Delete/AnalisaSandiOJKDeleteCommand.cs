// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.AnalisaSandiOJKs;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.AnalisaSandiOJKs.Commands
// {
//     public class AnalisaSandiOJKDeleteCommand : AnalisaSandiOJKFindRequestDto, IRequest<ServiceResponse<Unit>>
//     {
        
//     }

//     public class DeleteAnalisaSandiOJKCommandHandler : IRequestHandler<AnalisaSandiOJKDeleteCommand, ServiceResponse<Unit>>
//     {
//         private readonly IGenericRepositoryAsync<AnalisaSandiOJK> _AnalisaSandiOJK;
//         private readonly IMapper _mapper;

//         public DeleteAnalisaSandiOJKCommandHandler(IGenericRepositoryAsync<AnalisaSandiOJK> AnalisaSandiOJK, IMapper mapper){
//             _AnalisaSandiOJK = AnalisaSandiOJK;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<Unit>> Handle(AnalisaSandiOJKDeleteCommand request, CancellationToken cancellationToken)
//         {
//             var rFProduct = await _AnalisaSandiOJK.GetByIdAsync(request.Id, "Id");
//             rFProduct.IsDeleted = true;
//             await _AnalisaSandiOJK.UpdateAsync(rFProduct);
//             return ServiceResponse<Unit>.ReturnResultWith200(Unit.Value);
//         }
//     }
// }