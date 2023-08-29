// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.ArusKasMasuks;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;

// namespace NewLMS.UMKM.MediatR.Features.ArusKasMasuks.Queries
// {
//     public class ArusKasMasukGetQuery : ArusKasMasukFindRequestDto, IRequest<ServiceResponse<ArusKasMasukResponseDto>>
//     {
//     }

//     public class ArusKasMasukGetQueryHandler : IRequestHandler<ArusKasMasukGetQuery, ServiceResponse<ArusKasMasukResponseDto>>
//     {
//         private IGenericRepositoryAsync<ArusKasMasuk> _ArusKasMasuk;
//         private readonly IMapper _mapper;

//         public ArusKasMasukGetQueryHandler(IGenericRepositoryAsync<ArusKasMasuk> ArusKasMasuk, IMapper mapper)
//         {
//             _ArusKasMasuk = ArusKasMasuk;
//             _mapper = mapper;
//         }
//         public async Task<ServiceResponse<ArusKasMasukResponseDto>> Handle(ArusKasMasukGetQuery request, CancellationToken cancellationToken)
//         {
//             try
//             {
//                 var data = await _ArusKasMasuk.GetByIdAsync(request.Id, "Id");
//                 if (data == null)
//                     return ServiceResponse<ArusKasMasukResponseDto>.Return404("Data ArusKasMasuk not found");
//                 var response = _mapper.Map<ArusKasMasukResponseDto>(data);
//                 return ServiceResponse<ArusKasMasukResponseDto>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<ArusKasMasukResponseDto>.ReturnException(ex);
//             }
//         }
//     }
// }