// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.BiayaVariabelTenagaKerjas;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;

// namespace NewLMS.UMKM.MediatR.Features.BiayaVariabelTenagaKerjas.Queries
// {
//     public class BiayaVariabelTenagaKerjaGetQuery : BiayaVariabelTenagaKerjaFindRequestDto, IRequest<ServiceResponse<BiayaVariabelTenagaKerjaResponseDto>>
//     {
//     }

//     public class BiayaVariabelTenagaKerjaGetQueryHandler : IRequestHandler<BiayaVariabelTenagaKerjaGetQuery, ServiceResponse<BiayaVariabelTenagaKerjaResponseDto>>
//     {
//         private IGenericRepositoryAsync<BiayaVariabelTenagaKerja> _BiayaVariabelTenagaKerja;
//         private readonly IMapper _mapper;

//         public BiayaVariabelTenagaKerjaGetQueryHandler(IGenericRepositoryAsync<BiayaVariabelTenagaKerja> BiayaVariabelTenagaKerja, IMapper mapper)
//         {
//             _BiayaVariabelTenagaKerja = BiayaVariabelTenagaKerja;
//             _mapper = mapper;
//         }
//         public async Task<ServiceResponse<BiayaVariabelTenagaKerjaResponseDto>> Handle(BiayaVariabelTenagaKerjaGetQuery request, CancellationToken cancellationToken)
//         {
//             try
//             {
//                 var data = await _BiayaVariabelTenagaKerja.GetByIdAsync(request.Id, "Id");
//                 if (data == null)
//                     return ServiceResponse<BiayaVariabelTenagaKerjaResponseDto>.Return404("Data BiayaVariabelTenagaKerja not found");
//                 var response = _mapper.Map<BiayaVariabelTenagaKerjaResponseDto>(data);
//                 return ServiceResponse<BiayaVariabelTenagaKerjaResponseDto>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<BiayaVariabelTenagaKerjaResponseDto>.ReturnException(ex);
//             }
//         }
//     }
// }