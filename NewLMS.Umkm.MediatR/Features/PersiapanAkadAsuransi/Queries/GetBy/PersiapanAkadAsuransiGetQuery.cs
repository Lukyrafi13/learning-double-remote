// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.PersiapanAkadAsuransis;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;

// namespace NewLMS.UMKM.MediatR.Features.PersiapanAkadAsuransis.Queries
// {
//     public class PersiapanAkadAsuransiGetQuery : PersiapanAkadAsuransiFindRequestDto, IRequest<ServiceResponse<PersiapanAkadAsuransiResponseDto>>
//     {
//     }

//     public class PersiapanAkadAsuransiGetQueryHandler : IRequestHandler<PersiapanAkadAsuransiGetQuery, ServiceResponse<PersiapanAkadAsuransiResponseDto>>
//     {
//         private IGenericRepositoryAsync<PersiapanAkadAsuransi> _PersiapanAkadAsuransi;
//         private readonly IMapper _mapper;

//         public PersiapanAkadAsuransiGetQueryHandler(IGenericRepositoryAsync<PersiapanAkadAsuransi> PersiapanAkadAsuransi, IMapper mapper)
//         {
//             _PersiapanAkadAsuransi = PersiapanAkadAsuransi;
//             _mapper = mapper;
//         }
//         public async Task<ServiceResponse<PersiapanAkadAsuransiResponseDto>> Handle(PersiapanAkadAsuransiGetQuery request, CancellationToken cancellationToken)
//         {
//             try
//             {
//                 var includes = new string[]{
//                     "PersiapanAkad",
//                     "JenisAsuransi",
//                     "ObjekPertanggunganKerugian",
//                 };

//                 var data = await _PersiapanAkadAsuransi.GetByIdAsync(request.Id, "Id", includes);
//                 if (data == null)
//                     return ServiceResponse<PersiapanAkadAsuransiResponseDto>.Return404("Data PersiapanAkadAsuransi not found");
//                 var response = _mapper.Map<PersiapanAkadAsuransiResponseDto>(data);
//                 return ServiceResponse<PersiapanAkadAsuransiResponseDto>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<PersiapanAkadAsuransiResponseDto>.ReturnException(ex);
//             }
//         }
//     }
// }