using AutoMapper;
using MediatR;
using NewLMS.Umkm.Data.Dto.RFJenisUsahaYangDihindaris;
using NewLMS.Umkm.Data;
using NewLMS.Umkm.Helper;
using NewLMS.Umkm.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.Umkm.MediatR.Features.RFJenisUsahaYangDihindaris.Commands
{
    public class RFJenisUsahaYangDihindariPutCommand : RFJenisUsahaYangDihindariPutRequestDto, IRequest<ServiceResponse<RFJenisUsahaYangDihindariResponseDto>>
    {
    }

    public class PutRFJenisUsahaYangDihindariCommandHandler : IRequestHandler<RFJenisUsahaYangDihindariPutCommand, ServiceResponse<RFJenisUsahaYangDihindariResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFJenisUsahaYangDihindari> _RFJenisUsahaYangDihindari;
        private readonly IMapper _mapper;

        public PutRFJenisUsahaYangDihindariCommandHandler(IGenericRepositoryAsync<RFJenisUsahaYangDihindari> RFJenisUsahaYangDihindari, IMapper mapper)
        {
            _RFJenisUsahaYangDihindari = RFJenisUsahaYangDihindari;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFJenisUsahaYangDihindariResponseDto>> Handle(RFJenisUsahaYangDihindariPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFJenisUsahaYangDihindari = await _RFJenisUsahaYangDihindari.GetByIdAsync(request.StatusJenisUsaha_Code, "StatusJenisUsaha_Code");
                existingRFJenisUsahaYangDihindari.StatusJenisUsaha_Code = request.StatusJenisUsaha_Code;
                existingRFJenisUsahaYangDihindari.StatusJenisUsaha_Desc = request.StatusJenisUsaha_Desc;

                await _RFJenisUsahaYangDihindari.UpdateAsync(existingRFJenisUsahaYangDihindari);

                var response = _mapper.Map<RFJenisUsahaYangDihindariResponseDto>(existingRFJenisUsahaYangDihindari);

                return ServiceResponse<RFJenisUsahaYangDihindariResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFJenisUsahaYangDihindariResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}