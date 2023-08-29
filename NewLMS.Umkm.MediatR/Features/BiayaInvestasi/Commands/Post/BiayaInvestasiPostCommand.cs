using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.BiayaInvestasis;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.BiayaInvestasis.Commands
{
    public class BiayaInvestasiPostCommand : BiayaInvestasiPostRequestDto, IRequest<ServiceResponse<BiayaInvestasiResponseDto>>
    {

    }
    public class PostBiayaInvestasiCommandHandler : IRequestHandler<BiayaInvestasiPostCommand, ServiceResponse<BiayaInvestasiResponseDto>>
    {
        private readonly IGenericRepositoryAsync<BiayaInvestasi> _BiayaInvestasi;
        private readonly IMapper _mapper;

        public PostBiayaInvestasiCommandHandler(IGenericRepositoryAsync<BiayaInvestasi> BiayaInvestasi, IMapper mapper)
        {
            _BiayaInvestasi = BiayaInvestasi;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<BiayaInvestasiResponseDto>> Handle(BiayaInvestasiPostCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var BiayaInvestasi = _mapper.Map<BiayaInvestasi>(request);

                var returnedBiayaInvestasi = await _BiayaInvestasi.AddAsync(BiayaInvestasi, callSave: false);

                // var response = _mapper.Map<BiayaInvestasiResponseDto>(returnedBiayaInvestasi);
                var response = _mapper.Map<BiayaInvestasiResponseDto>(returnedBiayaInvestasi);

                await _BiayaInvestasi.SaveChangeAsync();
                return ServiceResponse<BiayaInvestasiResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<BiayaInvestasiResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}