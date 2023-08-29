using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.Debiturs;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.Debiturs.Commands
{
    public class DebiturPostCommand : DebiturPostRequestDto, IRequest<ServiceResponse<DebiturResponseDto>>
    {

    }
    public class PostDebiturCommandHandler : IRequestHandler<DebiturPostCommand, ServiceResponse<DebiturResponseDto>>
    {
        private readonly IGenericRepositoryAsync<Debitur> _debitur;
        private readonly IGenericRepositoryAsync<RFZipCode> _zipCode;
        private readonly IMapper _mapper;

        public PostDebiturCommandHandler(
            IGenericRepositoryAsync<Debitur> debitur,
            IGenericRepositoryAsync<RFZipCode> zipCode,
            IMapper mapper)
        {
            _debitur = debitur;
            _zipCode = zipCode;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<DebiturResponseDto>> Handle(DebiturPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                // Get Tipe Debitur

                var debitur = _mapper.Map<Debitur>(request);
                
                // Get Kode Post
                var zipCode = await _zipCode.GetByIdAsync(request.KodePos, "ZipCode");

                debitur.RFZipCodeId = zipCode.Id;

                var returnedDebitur = await _debitur.AddAsync(debitur, callSave: false);

                // var response = _mapper.Map<DebiturResponseDto>(returnedDebitur);
                var response = _mapper.Map<DebiturResponseDto>(returnedDebitur);
                
                await _debitur.SaveChangeAsync();
                return ServiceResponse<DebiturResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<DebiturResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}