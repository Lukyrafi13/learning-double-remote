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
//     public class PersiapanAkadAsuransiPutCommand : PersiapanAkadAsuransiPutRequestDto, IRequest<ServiceResponse<PersiapanAkadAsuransiResponseDto>>
//     {
//     }

//     public class PutPersiapanAkadAsuransiCommandHandler : IRequestHandler<PersiapanAkadAsuransiPutCommand, ServiceResponse<PersiapanAkadAsuransiResponseDto>>
//     {
//         private readonly IGenericRepositoryAsync<PersiapanAkadAsuransi> _PersiapanAkadAsuransi;
//         private readonly IMapper _mapper;

//         public PutPersiapanAkadAsuransiCommandHandler(IGenericRepositoryAsync<PersiapanAkadAsuransi> PersiapanAkadAsuransi, IMapper mapper)
//         {
//             _PersiapanAkadAsuransi = PersiapanAkadAsuransi;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<PersiapanAkadAsuransiResponseDto>> Handle(PersiapanAkadAsuransiPutCommand request, CancellationToken cancellationToken)
//         {
//             try
//             {
//                 var existingPersiapanAkadAsuransi = await _PersiapanAkadAsuransi.GetByIdAsync(request.Id, "Id");
                
//                 existingPersiapanAkadAsuransi = _mapper.Map<PersiapanAkadAsuransiPutRequestDto, PersiapanAkadAsuransi>(request, existingPersiapanAkadAsuransi);

//                 await _PersiapanAkadAsuransi.UpdateAsync(existingPersiapanAkadAsuransi);

//                 var response = _mapper.Map<PersiapanAkadAsuransiResponseDto>(existingPersiapanAkadAsuransi);

//                 return ServiceResponse<PersiapanAkadAsuransiResponseDto>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<PersiapanAkadAsuransiResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
//             }
//         }
//     }
// }