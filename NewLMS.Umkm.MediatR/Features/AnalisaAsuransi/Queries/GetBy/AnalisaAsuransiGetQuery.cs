// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.AnalisaAsuransis;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;

// namespace NewLMS.UMKM.MediatR.Features.AnalisaAsuransis.Queries
// {
//     public class AnalisaAsuransiGetQuery : AnalisaAsuransiFindRequestDto, IRequest<ServiceResponse<AnalisaAsuransiResponseDto>>
//     {
//     }

//     public class AnalisaAsuransiGetQueryHandler : IRequestHandler<AnalisaAsuransiGetQuery, ServiceResponse<AnalisaAsuransiResponseDto>>
//     {
//         private IGenericRepositoryAsync<AnalisaAsuransi> _AnalisaAsuransi;
//         private readonly IMapper _mapper;

//         public AnalisaAsuransiGetQueryHandler(IGenericRepositoryAsync<AnalisaAsuransi> AnalisaAsuransi, IMapper mapper)
//         {
//             _AnalisaAsuransi = AnalisaAsuransi;
//             _mapper = mapper;
//         }
//         public async Task<ServiceResponse<AnalisaAsuransiResponseDto>> Handle(AnalisaAsuransiGetQuery request, CancellationToken cancellationToken)
//         {
//             try
//             {
//                 var includes = new string[]{
//                     "Analisa",
//                     "Analisa.Survey",
//                     "RFJenisAsuransi",
//                 };

//                 var data = await _AnalisaAsuransi.GetByIdAsync(request.Id, "Id", includes);
//                 if (data == null)
//                     return ServiceResponse<AnalisaAsuransiResponseDto>.Return404("Data AnalisaAsuransi not found");
//                 var response = _mapper.Map<AnalisaAsuransiResponseDto>(data);
//                 return ServiceResponse<AnalisaAsuransiResponseDto>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<AnalisaAsuransiResponseDto>.ReturnException(ex);
//             }
//         }
//     }
// }