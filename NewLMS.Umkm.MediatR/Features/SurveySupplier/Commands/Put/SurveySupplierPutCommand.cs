using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.SurveySuppliers;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.SurveySuppliers.Commands
{
    public class SurveySupplierPutCommand : SurveySupplierPutRequestDto, IRequest<ServiceResponse<SurveySupplierResponseDto>>
    {
    }

    public class PutSurveySupplierCommandHandler : IRequestHandler<SurveySupplierPutCommand, ServiceResponse<SurveySupplierResponseDto>>
    {
        private readonly IGenericRepositoryAsync<SurveySupplier> _SurveySupplier;
        private readonly IMapper _mapper;

        public PutSurveySupplierCommandHandler(IGenericRepositoryAsync<SurveySupplier> SurveySupplier, IMapper mapper)
        {
            _SurveySupplier = SurveySupplier;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<SurveySupplierResponseDto>> Handle(SurveySupplierPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingSurveySupplier = await _SurveySupplier.GetByIdAsync(request.Id, "Id");
                existingSurveySupplier.NamaSupplier = request.NamaSupplier;
                existingSurveySupplier.Alamat = request.Alamat;
                existingSurveySupplier.Kota = request.Kota;
                existingSurveySupplier.JenisProduk = request.JenisProduk;
                existingSurveySupplier.NamaContactPerson = request.NamaContactPerson;
                existingSurveySupplier.NoTelp = request.NoTelp;
                existingSurveySupplier.LamaHubunganTahun = request.LamaHubunganTahun;
                existingSurveySupplier.SurveyId = request.SurveyId;
                existingSurveySupplier.RFPaymentMethodsId = request.RFPaymentMethodsId;

                await _SurveySupplier.UpdateAsync(existingSurveySupplier);

                var response = _mapper.Map<SurveySupplierResponseDto>(existingSurveySupplier);

                return ServiceResponse<SurveySupplierResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<SurveySupplierResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}