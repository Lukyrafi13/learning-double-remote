using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.Analisas;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.Analisas.Commands
{
    public class AnalisaKemampuanMembayarPutCommand : AnalisaKemampuanMembayarPut, IRequest<ServiceResponse<AnalisaKemampuanMembayarResponse>>
    {
    }

    public class AnalisaKemampuanMembayarPutCommandHandler : IRequestHandler<AnalisaKemampuanMembayarPutCommand, ServiceResponse<AnalisaKemampuanMembayarResponse>>
    {
        private readonly IGenericRepositoryAsync<Analisa> _Analisa;
        private readonly IMapper _mapper;

        public AnalisaKemampuanMembayarPutCommandHandler(IGenericRepositoryAsync<Analisa> Analisa, IMapper mapper)
        {
            _Analisa = Analisa;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<AnalisaKemampuanMembayarResponse>> Handle(AnalisaKemampuanMembayarPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingAnalisa = await _Analisa.GetByIdAsync(request.Id, "Id");
                
                existingAnalisa.PenghasilanLainnya = request.PenghasilanLainnya;
                
                await _Analisa.UpdateAsync(existingAnalisa);

                var response = _mapper.Map<AnalisaKemampuanMembayarResponse>(existingAnalisa);

                return ServiceResponse<AnalisaKemampuanMembayarResponse>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<AnalisaKemampuanMembayarResponse>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}