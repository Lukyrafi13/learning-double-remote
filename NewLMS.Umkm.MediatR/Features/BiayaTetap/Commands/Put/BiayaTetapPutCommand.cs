// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.BiayaTetaps;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.BiayaTetaps.Commands
// {
//     public class BiayaTetapPutCommand : BiayaTetapPutRequestDto, IRequest<ServiceResponse<BiayaTetapResponseDto>>
//     {
//     }

//     public class PutBiayaTetapCommandHandler : IRequestHandler<BiayaTetapPutCommand, ServiceResponse<BiayaTetapResponseDto>>
//     {
//         private readonly IGenericRepositoryAsync<BiayaTetap> _BiayaTetap;
//         private readonly IMapper _mapper;

//         public PutBiayaTetapCommandHandler(IGenericRepositoryAsync<BiayaTetap> BiayaTetap, IMapper mapper)
//         {
//             _BiayaTetap = BiayaTetap;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<BiayaTetapResponseDto>> Handle(BiayaTetapPutCommand request, CancellationToken cancellationToken)
//         {
//             try
//             {
//                 var existingBiayaTetap = await _BiayaTetap.GetByIdAsync(request.Id, "Id");
//                 existingBiayaTetap.Keterangan = request.Keterangan;
//                 existingBiayaTetap.Jumlah = request.Jumlah;
//                 existingBiayaTetap.Satuan = request.Satuan;
//                 existingBiayaTetap.Harga = request.Harga;
//                 existingBiayaTetap.Total = request.Total;
//                 existingBiayaTetap.SurveyId = request.SurveyId;

//                 await _BiayaTetap.UpdateAsync(existingBiayaTetap);

//                 var response = _mapper.Map<BiayaTetapResponseDto>(existingBiayaTetap);

//                 return ServiceResponse<BiayaTetapResponseDto>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<BiayaTetapResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
//             }
//         }
//     }
// }