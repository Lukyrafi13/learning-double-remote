// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.InformasiOmsets;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;

// namespace NewLMS.UMKM.MediatR.Features.InformasiOmsets.Queries
// {
//     public class InformasiOmsetGetQuery : InformasiOmsetFindRequestDto, IRequest<ServiceResponse<InformasiOmsetResponseDto>>
//     {
//     }

//     public class InformasiOmsetGetQueryHandler : IRequestHandler<InformasiOmsetGetQuery, ServiceResponse<InformasiOmsetResponseDto>>
//     {
//         private IGenericRepositoryAsync<InformasiOmset> _InformasiOmset;
//         private readonly IMapper _mapper;

//         public InformasiOmsetGetQueryHandler(IGenericRepositoryAsync<InformasiOmset> InformasiOmset, IMapper mapper)
//         {
//             _InformasiOmset = InformasiOmset;
//             _mapper = mapper;
//         }
//         public async Task<ServiceResponse<InformasiOmsetResponseDto>> Handle(InformasiOmsetGetQuery request, CancellationToken cancellationToken)
//         {
//             try
//             {
//                 var data = await _InformasiOmset.GetByIdAsync(request.Id, "Id");
//                 if (data == null)
//                     return ServiceResponse<InformasiOmsetResponseDto>.Return404("Data InformasiOmset not found");
//                 var response = _mapper.Map<InformasiOmsetResponseDto>(data);
//                 return ServiceResponse<InformasiOmsetResponseDto>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<InformasiOmsetResponseDto>.ReturnException(ex);
//             }
//         }
//     }
// }