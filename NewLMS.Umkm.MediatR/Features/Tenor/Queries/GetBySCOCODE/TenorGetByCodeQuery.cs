// using AutoMapper;
// using MediatR;
// using NewLMS.Umkm.Data.Dto.Tenors;
// using NewLMS.Umkm.Data;
// using NewLMS.Umkm.Helper;
// using NewLMS.Umkm.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;

// namespace NewLMS.Umkm.MediatR.Features.Tenors.Queries
// {
//     public class TenorsGetByCodeQuery : TenorFindRequestDto, IRequest<ServiceResponse<TenorResponseDto>>
//     {
//     }

//     public class GetByCodeTenorQueryHandler : IRequestHandler<TenorsGetByCodeQuery, ServiceResponse<TenorResponseDto>>
//     {
//         private IGenericRepositoryAsync<Tenor> _Tenor;
//         private readonly IMapper _mapper;

//         public GetByCodeTenorQueryHandler(IGenericRepositoryAsync<Tenor> Tenor, IMapper mapper)
//         {
//             _Tenor = Tenor;
//             _mapper = mapper;
//         }
//         public async Task<ServiceResponse<TenorResponseDto>> Handle(TenorsGetByCodeQuery request, CancellationToken cancellationToken)
//         {
//             try
//             {
//                 var data = await _Tenor.GetByIdAsync(request.SCO_CODE, "SCO_CODE");
//                 if (data == null)
//                     return ServiceResponse<TenorResponseDto>.Return404("Data Tenor not found");
//                 var response = _mapper.Map<TenorResponseDto>(data);
//                 return ServiceResponse<TenorResponseDto>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<TenorResponseDto>.ReturnException(ex);
//             }
//         }
//     }
// }