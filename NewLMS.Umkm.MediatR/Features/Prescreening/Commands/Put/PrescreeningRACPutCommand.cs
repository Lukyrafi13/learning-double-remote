// using AutoMapper;
// using MediatR;
// using NewLMS.UMKM.Data.Dto.Prescreenings;
// using NewLMS.UMKM.Data;
// using NewLMS.UMKM.Helper;
// using NewLMS.UMKM.Repository.GenericRepository;
// using System;
// using System.Threading;
// using System.Threading.Tasks;
// using System.Net;

// namespace NewLMS.UMKM.MediatR.Features.Prescreenings.Commands
// {
//     public class PrescreeningRACPutCommand : PrescreeningRACPut, IRequest<ServiceResponse<PrescreeningRACResponse>>
//     {
//     }

//     public class PrescreeningRACPutCommandHandler : IRequestHandler<PrescreeningRACPutCommand, ServiceResponse<PrescreeningRACResponse>>
//     {
//         private readonly IGenericRepositoryAsync<Prescreening> _Prescreening;
//         private readonly IMapper _mapper;

//         public PrescreeningRACPutCommandHandler(IGenericRepositoryAsync<Prescreening> Prescreening, IMapper mapper)
//         {
//             _Prescreening = Prescreening;
//             _mapper = mapper;
//         }

//         public async Task<ServiceResponse<PrescreeningRACResponse>> Handle(PrescreeningRACPutCommand request, CancellationToken cancellationToken)
//         {
//             try
//             {
//                 var existingPrescreening = await _Prescreening.GetByIdAsync(request.Id, "Id");
                
//                 existingPrescreening.RACUsiaMin = request.RACUsiaMin;
//                 existingPrescreening.RACUsiaMax = request.RACUsiaMax;
//                 existingPrescreening.RACeKTP = request.RACeKTP;
//                 existingPrescreening.RACNonDaftarHitam = request.RACNonDaftarHitam;
//                 existingPrescreening.RACKolektibilitas1 = request.RACKolektibilitas1;
//                 existingPrescreening.RACTidakKolektibilitas345 = request.RACTidakKolektibilitas345;
//                 existingPrescreening.RACMemilikiUsaha = request.RACMemilikiUsaha;
//                 existingPrescreening.RACTidakMemilikiFasilitasKreditLain = request.RACTidakMemilikiFasilitasKreditLain;
//                 existingPrescreening.TidakPernahMenerimaKredit = request.TidakPernahMenerimaKredit;
//                 existingPrescreening.PesertaBPJSTK = request.PesertaBPJSTK;

//                 await _Prescreening.UpdateAsync(existingPrescreening);

//                 var response = _mapper.Map<PrescreeningRACResponse>(existingPrescreening);

//                 return ServiceResponse<PrescreeningRACResponse>.ReturnResultWith200(response);
//             }
//             catch (Exception ex)
//             {
//                 return ServiceResponse<PrescreeningRACResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
//             }
//         }
//     }
// }