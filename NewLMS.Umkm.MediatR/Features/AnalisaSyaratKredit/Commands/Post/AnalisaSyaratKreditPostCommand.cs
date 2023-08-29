// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.AnalisaSyaratKredits;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.AnalisaSyaratKredits.Commands
// {
//     public class AnalisaSyaratKreditPostCommand : AnalisaSyaratKreditPostRequestDto, IRequest<ServiceResponse<AnalisaSyaratKreditResponseDto>>
//     {

//     }
//     public class AnalisaSyaratKreditPostCommandHandler : IRequestHandler<AnalisaSyaratKreditPostCommand, ServiceResponse<AnalisaSyaratKreditResponseDto>>
//     {
//         private readonly IGenericRepositoryAsync<AnalisaSyaratKredit> _AnalisaSyaratKredit;
//         private readonly IMapper _mapper;

//         public AnalisaSyaratKreditPostCommandHandler(IGenericRepositoryAsync<AnalisaSyaratKredit> AnalisaSyaratKredit, IMapper mapper)
//         {
//             _AnalisaSyaratKredit = AnalisaSyaratKredit;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<AnalisaSyaratKreditResponseDto>> Handle(AnalisaSyaratKreditPostCommand request, CancellationToken cancellationToken)
//         {

//             try
//             {
//                 var AnalisaSyaratKredit = _mapper.Map<AnalisaSyaratKredit>(request);

//                 var returnedAnalisaSyaratKredit = await _AnalisaSyaratKredit.AddAsync(AnalisaSyaratKredit, callSave: false);

//                 // var response = _mapper.Map<AnalisaSyaratKreditResponseDto>(returnedAnalisaSyaratKredit);
//                 var response = _mapper.Map<AnalisaSyaratKreditResponseDto>(returnedAnalisaSyaratKredit);

//                 await _AnalisaSyaratKredit.SaveChangeAsync();
//                 return ServiceResponse<AnalisaSyaratKreditResponseDto>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<AnalisaSyaratKreditResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
//             }
//         }
//     }
// }