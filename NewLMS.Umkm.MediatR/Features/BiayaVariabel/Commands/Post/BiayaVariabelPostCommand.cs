// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.BiayaVariabels;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.BiayaVariabels.Commands
// {
//     public class BiayaVariabelPostCommand : BiayaVariabelPostRequestDto, IRequest<ServiceResponse<BiayaVariabelResponseDto>>
//     {

//     }
//     public class PostBiayaVariabelCommandHandler : IRequestHandler<BiayaVariabelPostCommand, ServiceResponse<BiayaVariabelResponseDto>>
//     {
//         private readonly IGenericRepositoryAsync<BiayaVariabel> _BiayaVariabel;
//         private readonly IMapper _mapper;

//         public PostBiayaVariabelCommandHandler(IGenericRepositoryAsync<BiayaVariabel> BiayaVariabel, IMapper mapper)
//         {
//             _BiayaVariabel = BiayaVariabel;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<BiayaVariabelResponseDto>> Handle(BiayaVariabelPostCommand request, CancellationToken cancellationToken)
//         {

//             try
//             {
//                 var BiayaVariabel = _mapper.Map<BiayaVariabel>(request);

//                 var returnedBiayaVariabel = await _BiayaVariabel.AddAsync(BiayaVariabel, callSave: false);

//                 // var response = _mapper.Map<BiayaVariabelResponseDto>(returnedBiayaVariabel);
//                 var response = _mapper.Map<BiayaVariabelResponseDto>(returnedBiayaVariabel);

//                 await _BiayaVariabel.SaveChangeAsync();
//                 return ServiceResponse<BiayaVariabelResponseDto>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<BiayaVariabelResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
//             }
//         }
//     }
// }