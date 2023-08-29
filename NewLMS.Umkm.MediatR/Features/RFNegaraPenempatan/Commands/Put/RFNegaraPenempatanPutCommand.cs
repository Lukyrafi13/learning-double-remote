using AutoMapper;
using MediatR;
using NewLMS.UMKM.Data.Dto.RFNegaraPenempatans;
using NewLMS.UMKM.Data;
using NewLMS.UMKM.Helper;
using NewLMS.UMKM.Repository.GenericRepository;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace NewLMS.UMKM.MediatR.Features.RFNegaraPenempatans.Commands
{
    public class RFNegaraPenempatanPutCommand : RFNegaraPenempatanPutRequestDto, IRequest<ServiceResponse<RFNegaraPenempatanResponseDto>>
    {
    }

    public class PutRFNegaraPenempatanCommandHandler : IRequestHandler<RFNegaraPenempatanPutCommand, ServiceResponse<RFNegaraPenempatanResponseDto>>
    {
        private readonly IGenericRepositoryAsync<RFNegaraPenempatan> _RFNegaraPenempatan;
        private readonly IMapper _mapper;

        public PutRFNegaraPenempatanCommandHandler(IGenericRepositoryAsync<RFNegaraPenempatan> RFNegaraPenempatan, IMapper mapper){
            _RFNegaraPenempatan = RFNegaraPenempatan;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RFNegaraPenempatanResponseDto>> Handle(RFNegaraPenempatanPutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existingRFNegaraPenempatan = await _RFNegaraPenempatan.GetByIdAsync(request.NegaraCode, "ANL_CODE");
                existingRFNegaraPenempatan.NegaraCode = request.NegaraCode;
                existingRFNegaraPenempatan.NegaraDesc = request.NegaraDesc;
                existingRFNegaraPenempatan.CoreCode = request.CoreCode;
                existingRFNegaraPenempatan.ShowKUR = request.ShowKUR;
                existingRFNegaraPenempatan.Kurs = request.Kurs;
                existingRFNegaraPenempatan.Active = request.Active;
                
                await _RFNegaraPenempatan.UpdateAsync(existingRFNegaraPenempatan);

                var response = _mapper.Map<RFNegaraPenempatanResponseDto>(existingRFNegaraPenempatan);

                return ServiceResponse<RFNegaraPenempatanResponseDto>.ReturnResultWith200(response);
            }
            catch (Exception ex)
            {
                return ServiceResponse<RFNegaraPenempatanResponseDto>.ReturnFailed((int)HttpStatusCode.BadRequest, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}