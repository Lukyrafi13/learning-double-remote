using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.SurveyBuyers;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.SurveyBuyers.Commands
{
    public class SurveyBuyerPutCommand : SurveyBuyerPutRequestDto, IRequest<ServiceResponse<SurveyBuyerResponseDto>>
    {
    }

    public class PutSurveyBuyerCommandHandler : IRequestHandler<SurveyBuyerPutCommand, ServiceResponse<SurveyBuyerResponseDto>>
    {
        private readonly IGenericRepositoryAsync<SurveyBuyer> _SurveyBuyer;
        private readonly IMapper _mapper;

        public PutSurveyBuyerCommandHandler(IGenericRepositoryAsync<SurveyBuyer> SurveyBuyer, IMapper mapper)
        {
            _SurveyBuyer = SurveyBuyer;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<SurveyBuyerResponseDto>> Handle(SurveyBuyerPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingSurveyBuyer = await _SurveyBuyer.GetByIdAsync(request.Id, "Id");
                existingSurveyBuyer.NamaBuyer = request.NamaBuyer;
                existingSurveyBuyer.Alamat = request.Alamat;
                existingSurveyBuyer.Kota = request.Kota;
                existingSurveyBuyer.JenisProduk = request.JenisProduk;
                existingSurveyBuyer.NamaContactPerson = request.NamaContactPerson;
                existingSurveyBuyer.NoTelp = request.NoTelp;
                existingSurveyBuyer.LamaHubunganTahun = request.LamaHubunganTahun;
                existingSurveyBuyer.SurveyId = request.SurveyId;
                existingSurveyBuyer.RFPaymentMethodsId = request.RFPaymentMethodsId;

                await _SurveyBuyer.UpdateAsync(existingSurveyBuyer);

                var response = _mapper.Map<SurveyBuyerResponseDto>(existingSurveyBuyer);

                return ServiceResponse<SurveyBuyerResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<SurveyBuyerResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}