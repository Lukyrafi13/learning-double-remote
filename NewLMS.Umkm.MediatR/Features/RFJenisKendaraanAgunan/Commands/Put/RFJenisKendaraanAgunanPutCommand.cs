using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFJenisKendaraanAgunans;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFJenisKendaraanAgunans.Commands
{
    public class RFJenisKendaraanAgunanPutCommand : RFJenisKendaraanAgunanPutRequestDto, IRequest<ServiceResponse<RFJenisKendaraanAgunanResponseDto>>
    {
    }

    public class PutRFJenisKendaraanAgunanCommandHandler : IRequestHandler<RFJenisKendaraanAgunanPutCommand, ServiceResponse<RFJenisKendaraanAgunanResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFJenisKendaraanAgunan> _RFJenisKendaraanAgunan;
        private readonly IMapper _mapper;

        public PutRFJenisKendaraanAgunanCommandHandler(IGenericRepositoryAsync<RFJenisKendaraanAgunan> RFJenisKendaraanAgunan, IMapper mapper){
            _RFJenisKendaraanAgunan = RFJenisKendaraanAgunan;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFJenisKendaraanAgunanResponseDto>> Handle(RFJenisKendaraanAgunanPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFJenisKendaraanAgunan = await _RFJenisKendaraanAgunan.GetByIdAsync(request.VEH_CODE, "VEH_CODE");
                existingRFJenisKendaraanAgunan.VEH_CODE = request.VEH_CODE;
                existingRFJenisKendaraanAgunan.VEH_DESC = request.VEH_DESC;
                
                await _RFJenisKendaraanAgunan.UpdateAsync(existingRFJenisKendaraanAgunan);

                var response = _mapper.Map<RFJenisKendaraanAgunanResponseDto>(existingRFJenisKendaraanAgunan);

                return ServiceResponse<RFJenisKendaraanAgunanResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFJenisKendaraanAgunanResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}