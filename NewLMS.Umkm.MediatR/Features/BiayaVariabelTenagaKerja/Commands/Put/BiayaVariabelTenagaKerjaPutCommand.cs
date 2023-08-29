// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.BiayaVariabelTenagaKerjas;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.BiayaVariabelTenagaKerjas.Commands
// {
//     public class BiayaVariabelTenagaKerjaPutCommand : BiayaVariabelTenagaKerjaPutRequestDto, IRequest<ServiceResponse<BiayaVariabelTenagaKerjaResponseDto>>
//     {
//     }

//     public class PutBiayaVariabelTenagaKerjaCommandHandler : IRequestHandler<BiayaVariabelTenagaKerjaPutCommand, ServiceResponse<BiayaVariabelTenagaKerjaResponseDto>>
//     {
//         private readonly IGenericRepositoryAsync<BiayaVariabelTenagaKerja> _BiayaVariabelTenagaKerja;
//         private readonly IMapper _mapper;

//         public PutBiayaVariabelTenagaKerjaCommandHandler(IGenericRepositoryAsync<BiayaVariabelTenagaKerja> BiayaVariabelTenagaKerja, IMapper mapper)
//         {
//             _BiayaVariabelTenagaKerja = BiayaVariabelTenagaKerja;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<BiayaVariabelTenagaKerjaResponseDto>> Handle(BiayaVariabelTenagaKerjaPutCommand request, CancellationToken cancellationToken)
//         {
//             try
//             {
//                 var existingBiayaVariabelTenagaKerja = await _BiayaVariabelTenagaKerja.GetByIdAsync(request.Id, "Id");
//                 existingBiayaVariabelTenagaKerja.Keterangan = request.Keterangan;
//                 existingBiayaVariabelTenagaKerja.Jumlah = request.Jumlah;
//                 existingBiayaVariabelTenagaKerja.Satuan = request.Satuan;
//                 existingBiayaVariabelTenagaKerja.Harga = request.Harga;
//                 existingBiayaVariabelTenagaKerja.Total = request.Total;
//                 existingBiayaVariabelTenagaKerja.SurveyId = request.SurveyId;

//                 await _BiayaVariabelTenagaKerja.UpdateAsync(existingBiayaVariabelTenagaKerja);

//                 var response = _mapper.Map<BiayaVariabelTenagaKerjaResponseDto>(existingBiayaVariabelTenagaKerja);

//                 return ServiceResponse<BiayaVariabelTenagaKerjaResponseDto>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<BiayaVariabelTenagaKerjaResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
//             }
//         }
//     }
// }