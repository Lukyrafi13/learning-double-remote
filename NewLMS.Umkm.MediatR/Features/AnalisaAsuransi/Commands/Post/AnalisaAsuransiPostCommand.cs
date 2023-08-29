// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.AnalisaAsuransis;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.AnalisaAsuransis.Commands
// {
//     public class AnalisaAsuransiPostCommand : AnalisaAsuransiPostRequestDto, IRequest<ServiceResponse<AnalisaAsuransiResponseDto>>
//     {

//     }
//     public class AnalisaAsuransiPostCommandHandler : IRequestHandler<AnalisaAsuransiPostCommand, ServiceResponse<AnalisaAsuransiResponseDto>>
//     {
//         private readonly IGenericRepositoryAsync<AnalisaAsuransi> _AnalisaAsuransi;
//         private readonly IMapper _mapper;

//         public AnalisaAsuransiPostCommandHandler(IGenericRepositoryAsync<AnalisaAsuransi> AnalisaAsuransi, IMapper mapper)
//         {
//             _AnalisaAsuransi = AnalisaAsuransi;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<AnalisaAsuransiResponseDto>> Handle(AnalisaAsuransiPostCommand request, CancellationToken cancellationToken)
//         {

//             try
//             {
//                 var AnalisaAsuransi = _mapper.Map<AnalisaAsuransi>(request);

//                 var returnedAnalisaAsuransi = await _AnalisaAsuransi.AddAsync(AnalisaAsuransi, callSave: false);

//                 // var response = _mapper.Map<AnalisaAsuransiResponseDto>(returnedAnalisaAsuransi);
//                 var response = _mapper.Map<AnalisaAsuransiResponseDto>(returnedAnalisaAsuransi);

//                 await _AnalisaAsuransi.SaveChangeAsync();
//                 return ServiceResponse<AnalisaAsuransiResponseDto>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<AnalisaAsuransiResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
//             }
//         }
//     }
// }