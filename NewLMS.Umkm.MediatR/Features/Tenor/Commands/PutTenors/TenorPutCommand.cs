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
//     public class TenorPutCommand : TenorPutRequestDto, IRequest<ServiceResponse<TenorResponseDto>>
//     {
//     }

//     public class PutTenorCommandHandler : IRequestHandler<TenorPutCommand, ServiceResponse<TenorResponseDto>>
//     {
//         private readonly IGenericRepositoryAsync<Tenor> _Tenor;
//         private readonly IMapper _mapper;

//         public PutTenorCommandHandler(IGenericRepositoryAsync<Tenor> Tenor, IMapper mapper){
//             _Tenor = Tenor;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<TenorResponseDto>> Handle(TenorPutCommand request, CancellationToken cancellationToken)
//         {
//             try
//             {
//                 var existingTenor = await _Tenor.GetByIdAsync(request.SCO_CODE, "SCO_CODE");
//                 existingTenor.SCO_CODE = request.SCO_CODE;
//                 existingTenor.SCO_DESC = request.SCO_DESC;
//                 existingTenor.CORE_DESC = request.CORE_DESC;
//                 existingTenor.ACTIVE = request.ACTIVE;
                
//                 await _Tenor.UpdateAsync(existingTenor);

//                 var response = _mapper.Map<TenorResponseDto>(existingTenor);

//                 return ServiceResponse<TenorResponseDto>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<TenorResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
//             }
//         }
//     }
// }