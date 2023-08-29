// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.ArusKasMasuks;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.ArusKasMasuks.Commands
// {
//     public class ArusKasMasukPostCommand : ArusKasMasukPostRequestDto, IRequest<ServiceResponse<ArusKasMasukResponseDto>>
//     {

//     }
//     public class PostArusKasMasukCommandHandler : IRequestHandler<ArusKasMasukPostCommand, ServiceResponse<ArusKasMasukResponseDto>>
//     {
//         private readonly IGenericRepositoryAsync<ArusKasMasuk> _ArusKasMasuk;
//         private readonly IMapper _mapper;

//         public PostArusKasMasukCommandHandler(IGenericRepositoryAsync<ArusKasMasuk> ArusKasMasuk, IMapper mapper)
//         {
//             _ArusKasMasuk = ArusKasMasuk;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<ArusKasMasukResponseDto>> Handle(ArusKasMasukPostCommand request, CancellationToken cancellationToken)
//         {

//             try
//             {
//                 var ArusKasMasuk = _mapper.Map<ArusKasMasuk>(request);

//                 var returnedArusKasMasuk = await _ArusKasMasuk.AddAsync(ArusKasMasuk, callSave: false);

//                 // var response = _mapper.Map<ArusKasMasukResponseDto>(returnedArusKasMasuk);
//                 var response = _mapper.Map<ArusKasMasukResponseDto>(returnedArusKasMasuk);

//                 await _ArusKasMasuk.SaveChangeAsync();
//                 return ServiceResponse<ArusKasMasukResponseDto>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<ArusKasMasukResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
//             }
//         }
//     }
// }