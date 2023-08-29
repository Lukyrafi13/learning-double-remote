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
//     public class AnalisaAsuransiPutCommand : AnalisaAsuransiPutRequestDto, IRequest<ServiceResponse<AnalisaAsuransiResponseDto>>
//     {
//     }

//     public class PutAnalisaAsuransiCommandHandler : IRequestHandler<AnalisaAsuransiPutCommand, ServiceResponse<AnalisaAsuransiResponseDto>>
//     {
//         private readonly IGenericRepositoryAsync<AnalisaAsuransi> _AnalisaAsuransi;
//         private readonly IMapper _mapper;

//         public PutAnalisaAsuransiCommandHandler(IGenericRepositoryAsync<AnalisaAsuransi> AnalisaAsuransi, IMapper mapper)
//         {
//             _AnalisaAsuransi = AnalisaAsuransi;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<AnalisaAsuransiResponseDto>> Handle(AnalisaAsuransiPutCommand request, CancellationToken cancellationToken)
//         {
//             try
//             {
//                 var existingAnalisaAsuransi = await _AnalisaAsuransi.GetByIdAsync(request.Id, "Id");
                
//                 existingAnalisaAsuransi = _mapper.Map<AnalisaAsuransiPutRequestDto, AnalisaAsuransi>(request, existingAnalisaAsuransi);

//                 await _AnalisaAsuransi.UpdateAsync(existingAnalisaAsuransi);

//                 var response = _mapper.Map<AnalisaAsuransiResponseDto>(existingAnalisaAsuransi);

//                 return ServiceResponse<AnalisaAsuransiResponseDto>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<AnalisaAsuransiResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
//             }
//         }
//     }
// }