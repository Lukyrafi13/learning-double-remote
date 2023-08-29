// using AutoMapper;
// using MediatR;
// using NewLMS.Umkm.Data.Dto.Tenors;
// using NewLMS.Umkm.Data;
// using NewLMS.Umkm.Helper;
// using NewLMS.Umkm.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Net;

// namespace NewLMS.Umkm.MediatR.Features.Tenors.Commands
// {
//     public class TenorPostCommand : TenorPostRequestDto, IRequest<ServiceResponse<TenorResponseDto>>
//     {

//     }
//     public class PostTenorCommandHandler : IRequestHandler<TenorPostCommand, ServiceResponse<TenorResponseDto>>
//     {
//         private readonly IGenericRepositoryAsync<Tenor> _Tenor;
//         private readonly IMapper _mapper;

//         public PostTenorCommandHandler(IGenericRepositoryAsync<Tenor> Tenor, IMapper mapper)
//         {
//             _Tenor = Tenor;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<TenorResponseDto>> Handle(TenorPostCommand request, CancellationToken cancellationToken)
//         {

//             try
//             {
//                 var Tenor = _mapper.Map<Tenor>(request);

//                 var returnedTenor = await _Tenor.AddAsync(Tenor, callSave: false);

//                 // var response = _mapper.Map<TenorResponseDto>(returnedTenor);
//                 var response = _mapper.Map<TenorResponseDto>(returnedTenor);

//                 await _Tenor.SaveChangeAsync();
//                 return ServiceResponse<TenorResponseDto>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<TenorResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
//             }
//         }
//     }
// }