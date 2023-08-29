// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.PersiapanAkadAsuransis;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.PersiapanAkadAsuransis.Commands
// {
//     public class PersiapanAkadAsuransiPostCommand : PersiapanAkadAsuransiPostRequestDto, IRequest<ServiceResponse<PersiapanAkadAsuransiResponseDto>>
//     {

//     }
//     public class PersiapanAkadAsuransiPostCommandHandler : IRequestHandler<PersiapanAkadAsuransiPostCommand, ServiceResponse<PersiapanAkadAsuransiResponseDto>>
//     {
//         private readonly IGenericRepositoryAsync<PersiapanAkadAsuransi> _PersiapanAkadAsuransi;
//         private readonly IMapper _mapper;

//         public PersiapanAkadAsuransiPostCommandHandler(IGenericRepositoryAsync<PersiapanAkadAsuransi> PersiapanAkadAsuransi, IMapper mapper)
//         {
//             _PersiapanAkadAsuransi = PersiapanAkadAsuransi;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<PersiapanAkadAsuransiResponseDto>> Handle(PersiapanAkadAsuransiPostCommand request, CancellationToken cancellationToken)
//         {

//             try
//             {
//                 var PersiapanAkadAsuransi = _mapper.Map<PersiapanAkadAsuransi>(request);

//                 var returnedPersiapanAkadAsuransi = await _PersiapanAkadAsuransi.AddAsync(PersiapanAkadAsuransi, callSave: false);

//                 // var response = _mapper.Map<PersiapanAkadAsuransiResponseDto>(returnedPersiapanAkadAsuransi);
//                 var response = _mapper.Map<PersiapanAkadAsuransiResponseDto>(returnedPersiapanAkadAsuransi);

//                 await _PersiapanAkadAsuransi.SaveChangeAsync();
//                 return ServiceResponse<PersiapanAkadAsuransiResponseDto>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<PersiapanAkadAsuransiResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
//             }
//         }
//     }
// }